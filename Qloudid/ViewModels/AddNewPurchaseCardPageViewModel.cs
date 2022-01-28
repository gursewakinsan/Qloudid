using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class AddNewPurchaseCardPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddNewPurchaseCardPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			ExpirationYearList = new List<string>();
			int currentYear = DateTime.Today.Year;
			for (int i = 0; i < 50; i++)
			{
				ExpirationYearList.Add($"{currentYear}");
				currentYear = currentYear + 1;
			}
		}
		#endregion

		#region Add New Card Command.
		private ICommand addNewCardCommand;
		public ICommand AddNewCardCommand
		{
			get => addNewCardCommand ?? (addNewCardCommand = new Command(async () => await ExecuteAddNewCardCommand()));
		}
		private async Task ExecuteAddNewCardCommand()
		{
			if (string.IsNullOrWhiteSpace(CardNumber))
				await Helper.Alert.DisplayAlert("Card number is required.");
			else if (CardNumber.Length < 16)
				await Helper.Alert.DisplayAlert("Please enter 16 digits card number.");
			else if (string.IsNullOrWhiteSpace(CardHolderName))
				await Helper.Alert.DisplayAlert("Card holder name is required.");
			else if (string.IsNullOrWhiteSpace(ExpirationMonth))
				await Helper.Alert.DisplayAlert("Expiration month is required.");
			else if (string.IsNullOrWhiteSpace(ExpirationYear))
				await Helper.Alert.DisplayAlert("Expiration year is required.");
			else if (string.IsNullOrWhiteSpace(Cvv))
				await Helper.Alert.DisplayAlert("Cvv is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				ICreateAccountService service = new CreateAccountService();
				Models.AddNewPurchaseCardRequest request = new Models.AddNewPurchaseCardRequest()
				{
					UserId = Helper.Helper.UserId,
					CardNumber = CardNumber,
					CardHolderName = CardHolderName,
					ExpirationMonth = ExpirationMonth,
					ExpirationYear = ExpirationYear,
					Cvv = Cvv,
					certificate_key = Helper.Helper.QrCertificateKey
				};
				int response = await service.SavePurchaseCardDetailsAsync(request);
				if (response == 0)
					await Helper.Alert.DisplayAlert("Something went wrong, Please try again.");
				else if (response == 1)
				{
					if (Helper.Helper.IsThirdPartyWebLogin)
					{
						Helper.Helper.IsThirdPartyWebLogin = false;
						Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
						if (Helper.Helper.PurchaseIndex == 1)
						{
							string url = $"https://www.qloudid.com/user/index.php/LoginAccount/loginPurchaseVerify?response_type=code&client_id={Helper.Helper.VerifyUserConsentClientId}&state=xyz&purchase=1";
							await Xamarin.Essentials.Launcher.OpenAsync(url);//"https://www.qloudid.com/user/index.php/LoginAccount/loginPurchaseVerify");
						}
						else
						{
							string url = $"https://www.qloudid.com/user/index.php/LoginAccount/loginPurchase/{Helper.Helper.VerifyUserConsentClientId}";
							await Xamarin.Essentials.Launcher.OpenAsync(url);//"https://www.qloudid.com/user/index.php/LoginAccount/loginPurchase");
						}
					}
					else
						Application.Current.MainPage = new NavigationPage(new Views.PurchaseSuccessfulPage());
				}
				else if (response == 2)
					await Helper.Alert.DisplayAlert("You have entered wrong card number, Please try another card.");
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		public string CardNumber { get; set; }
		public string CardHolderName => Helper.Helper.UserInfo.DisplayUserName;
		public string ExpirationMonth { get; set; }
		public string ExpirationYear { get; set; }
		public string Cvv { get; set; }
		public List<string> ExpirationYearList { get; set; }
		#endregion
	}
}
