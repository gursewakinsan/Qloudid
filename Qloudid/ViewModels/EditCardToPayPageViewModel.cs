using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class EditCardToPayPageViewModel : BaseViewModel
	{
		#region Constructor.
		public EditCardToPayPageViewModel(INavigation navigation)
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

		#region Update Card Command.
		private ICommand updateCardCommand;
		public ICommand UpdateCardCommand
		{
			get => updateCardCommand ?? (updateCardCommand = new Command(async () => await ExecuteUpdateCardCommand()));
		}
		private async Task ExecuteUpdateCardCommand()
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
				Models.EditCardRequest request = new Models.EditCardRequest()
				{
					CardId = CardDetailForEdit.id,
					CardNumber = CardNumber,
					CardHolderName = CardHolderName,
					ExpirationMonth = ExpirationMonth,
					ExpirationYear = ExpirationYear,
					Cvv = Cvv,
					Certificatekey = Helper.Helper.QrCertificateKey
				};
				int response = await service.UpdateCardAsync(request);
				if (response == 0)
					await Helper.Alert.DisplayAlert("Something went wrong, Please try again.");
				else
				{
					Helper.Helper.CardDetail = new Models.CardDetailResponse();
					Helper.Helper.CardDetail.card_number2 = CardNumber;
					Application.Current.MainPage = new NavigationPage(new Views.YourSignaturePage());
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Bind Card Detail Command.
		private ICommand bindCardDetailCommand;
		public ICommand BindCardDetailCommand
		{
			get => bindCardDetailCommand ?? (bindCardDetailCommand = new Command(async () => await ExecuteBindCardDetailCommand()));
		}
		private async Task ExecuteBindCardDetailCommand()
		{
			if (CardDetailForEdit != null)
			{
				CardNumber = CardDetailForEdit.card_number;
				ExpirationMonth = CardDetailForEdit.exp_month;
				ExpirationYear = CardDetailForEdit.exp_year;
				Cvv = CardDetailForEdit.card_cvv;
			}
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		private string cardNumber;
		public string CardNumber
		{
			get => cardNumber;
			set
			{
				cardNumber = value;
				OnPropertyChanged("CardNumber");
			}
		}

		private string expirationMonth;
		public string ExpirationMonth
		{
			get => expirationMonth;
			set
			{
				expirationMonth = value;
				OnPropertyChanged("ExpirationMonth");
			}
		}

		private string expirationYear;
		public string ExpirationYear
		{
			get => expirationYear;
			set
			{
				expirationYear = value;
				OnPropertyChanged("ExpirationYear");
			}
		}

		private string cvv;
		public string Cvv
		{
			get => cvv;
			set
			{
				cvv = value;
				OnPropertyChanged("Cvv");
			}
		}
		public string CardHolderName => Helper.Helper.UserInfo.DisplayUserName;
		public List<string> ExpirationYearList { get; set; }
		public Models.CardDetailResponse CardDetailForEdit { get; set; }
		#endregion
	}
}
