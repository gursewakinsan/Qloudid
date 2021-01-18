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
					CardNumber = CardNumber,
					CardHolderName = CardHolderName,
					ExpirationMonth = ExpirationMonth,
					ExpirationYear = ExpirationYear,
					Cvv = Cvv
				};
				Models.AddNewCardResponse response = await service.AddNewCardAsync(request);
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		public string CardNumber { get; set; }
		public string CardHolderName { get; set; }
		public string ExpirationMonth { get; set; }
		public string ExpirationYear { get; set; }
		public string Cvv { get; set; }
		public List<string> ExpirationYearList { get; set; }
		#endregion
	}
}
