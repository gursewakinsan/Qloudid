using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class AddNewCardToPayPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddNewCardToPayPageViewModel(INavigation navigation)
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
				else
				{
					Helper.Helper.CardDetail = new Models.CardDetailResponse();
					Helper.Helper.CardDetail.card_number2 = CardNumber;
					Helper.Helper.CardDetail.card_type = "Visa";
					Application.Current.MainPage = new NavigationPage(new Views.Hotel.HotelYourSignaturePage());
				}
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
