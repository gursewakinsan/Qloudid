using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class AddNewCardPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddNewCardPageViewModel(INavigation navigation)
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
				Models.AddNewCardRequest request = new Models.AddNewCardRequest()
				{
					UserId = Helper.Helper.UserId,
					certi = Helper.Helper.QrCertificateKey,
					CardNumber = CardNumber,
					CardHolderName = CardHolderName,
					ExpirationMonth = ExpirationMonth,
					ExpirationYear = ExpirationYear,
					Cvv = Cvv
				};
				int response = await service.AddNewCardAsync(request);
				if (response == 0)
					await Helper.Alert.DisplayAlert("Something went wrong, Please try again.");
				else if (response == 1)
				{
					if (Helper.Helper.IsAddMoreCard)
					{
						Helper.Helper.IsAddMoreCard = false;
						await Navigation.PopAsync();
					}
					else
						Application.Current.MainPage = new NavigationPage(new Views.AddDeliveryAddressPage());
				}
				else if (response == 2)
					await Helper.Alert.DisplayAlert("You have entered wrong card number, Please try another card.");
				else if (response == 3 || response == 4)
				{
					ILoginService loginService = new LoginService();
					var checkValidQrResponse = await loginService.CheckValidQrAsync(Helper.Helper.QrCertificateKey);
					if (checkValidQrResponse?.result > 0)
					{
						Helper.Helper.CountryCode = checkValidQrResponse.country_code;
						Helper.Helper.GenerateCertificateIdentificatorValue = checkValidQrResponse.identificator;
						Application.Current.MainPage = new NavigationPage(new Views.Info.WantToCompleteCheckInInfoPage());
					}
				}
				else if (response == 5)
					Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Back Button Control Command.
		private ICommand backButtonControlCommand;
		public ICommand BackButtonControlCommand
		{
			get => backButtonControlCommand ?? (backButtonControlCommand = new Command(async () => await ExecuteBackButtonControlCommand()));
		}
		private async Task ExecuteBackButtonControlCommand()
		{
			if (IsCloseShow)
				await Navigation.PopAsync();
		}
		#endregion

		#region Is Name On Card Command.
		private ICommand isNameOnCardCommand;
		public ICommand IsNameOnCardCommand
		{
			get => isNameOnCardCommand ?? (isNameOnCardCommand = new Command( () =>  ExecuteIsNameOnCardCommand()));
		}
		private void ExecuteIsNameOnCardCommand()
		{
			IsNameOnCard = !IsNameOnCard;
		}
		#endregion

		#region Properties.
		public bool IsCloseShow=> Helper.Helper.IsAddMoreCard;
		public string CardNumber { get; set; }
		public string CardHolderName => Helper.Helper.UserInfo.DisplayUserName;
		public string ExpirationMonth { get; set; }
		public string ExpirationYear { get; set; }
		public string Cvv { get; set; }
		public List<string> ExpirationYearList { get; set; }

		private bool isNameOnCard;
		public bool IsNameOnCard
		{
			get => isNameOnCard;
			set
			{
				isNameOnCard = value;
				OnPropertyChanged("IsNameOnCard");
			}
		}
		#endregion
	}
}
