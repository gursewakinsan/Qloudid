using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class PaymentsPersonalPageViewModel : BaseViewModel
    {
		#region Constructor.
		public PaymentsPersonalPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
			IsPrivate = true;
			BindMonthAndYear();
		}
		#endregion

		#region Bind Month And Year
		private void BindMonthAndYear()
		{
			IssueMonthList = new List<string>();
			for (int issueMonth = 1; issueMonth < 13; issueMonth++)
				IssueMonthList.Add($"{issueMonth}");
			SelectedIssueMonth = IssueMonthList[0];

			IssueYearList = new List<string>();
			int issueYear = DateTime.Today.Year;
			for (int i = 0; i < 50; i++)
			{
				IssueYearList.Add($"{issueYear}");
				issueYear = issueYear + 1;
			}
			SelectedIssueYear = IssueYearList[0];
		}
		#endregion

		#region Private/Company Command.
		private ICommand privateOrCompanyCommand;
		public ICommand PrivateOrCompanyCommand
		{
			get => privateOrCompanyCommand ?? (privateOrCompanyCommand = new Command<string>((selectedButton) => ExecutePrivateOrCompanyCommand(selectedButton)));
		}
		private void ExecutePrivateOrCompanyCommand(string selectedButton)
		{
            switch (selectedButton)
            {
				case "Private":
					IsPrivate = true;
					break;
				case "Company":
					IsPrivate = false;
					break;
			}
        }
		#endregion

		#region Update User Personal Address Command.
		private ICommand updateUserPersonalAddressCommand;
		public ICommand UpdateUserPersonalAddressCommand
		{
			get => updateUserPersonalAddressCommand ?? (updateUserPersonalAddressCommand = new Command(async () => await ExecuteUpdateUserPersonalAddressCommand()));
		}
		private async Task ExecuteUpdateUserPersonalAddressCommand()
		{
			if (string.IsNullOrWhiteSpace(NameOnTheDoor))
				await Helper.Alert.DisplayAlert("Name on the door is required.");
			else if (string.IsNullOrWhiteSpace(StreetAddress))
				await Helper.Alert.DisplayAlert("Street address is required.");
			else if (string.IsNullOrWhiteSpace(Number))
				await Helper.Alert.DisplayAlert("Number is required.");
			else if (string.IsNullOrWhiteSpace(ZipCode))
				await Helper.Alert.DisplayAlert("Zip code is required.");
			else if (string.IsNullOrWhiteSpace(City))
				await Helper.Alert.DisplayAlert("City is required.");
			else if (string.IsNullOrWhiteSpace(NameOnTheCard))
				await Helper.Alert.DisplayAlert("Name on the card is required.");
			else if (string.IsNullOrWhiteSpace(CardNumber))
				await Helper.Alert.DisplayAlert("Card number is required.");
			else if (string.IsNullOrWhiteSpace(CVC))
				await Helper.Alert.DisplayAlert("CVC is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IRentOutService service = new RentOutService();
				await service.UpdateUserPersonalAddressAsync(new Models.UpdateUserPersonalAddressRequest()
				{
					CardNumber = CardNumber,
					Cvv = CVC,
					D_Address = NameOnTheDoor,
					D_City = City,
					D_PoNumber = Number,
					D_Zip = ZipCode,
					ExpiryMonth = SelectedIssueMonth,
					ExpiryYear = SelectedIssueYear,
					NameOnCard = NameOnTheCard,
					IsCompany = IsPrivate ? 0 : 1,
					BookingId = Helper.Helper.BookingId
				});
				if (!IsPrivate)
					await Navigation.PushAsync(new Views.RentOut.PaymentsBusinessPage());
				else
				{
					this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
					this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
					this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
					this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
					await Navigation.PopAsync();
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		private Models.EditAddressResponse address;
		public Models.EditAddressResponse Address
		{
			get => address;
			set
			{
				address = value;
				OnPropertyChanged("Address");
			}
		}

		private List<string> issueMonthList;
		public List<string> IssueMonthList
		{
			get => issueMonthList;
			set
			{
				issueMonthList = value;
				OnPropertyChanged("IssueMonthList");
			}
		}

		private string selectedIssueMonth;
		public string SelectedIssueMonth
		{
			get => selectedIssueMonth;
			set
			{
				selectedIssueMonth = value;
				OnPropertyChanged("SelectedIssueMonth");
			}
		}

		private List<string> issueYearList;
		public List<string> IssueYearList
		{
			get => issueYearList;
			set
			{
				issueYearList = value;
				OnPropertyChanged("IssueYearList");
			}
		}

		private string selectedIssueYear;
		public string SelectedIssueYear
		{
			get => selectedIssueYear;
			set
			{
				selectedIssueYear = value;
				OnPropertyChanged("SelectedIssueYear");
			}
		}

		private Color privateTextColor;
		public Color PrivateTextColor
		{
			get => privateTextColor;
			set
			{
				privateTextColor = value;
				OnPropertyChanged("PrivateTextColor");
			}
		}

		private Color privateBg;
		public Color PrivateBg
		{
			get => privateBg;
			set
			{
				privateBg = value;
				OnPropertyChanged("PrivateBg");
			}
		}

		private Color companyTextColor;
		public Color CompanyTextColor
		{
			get => companyTextColor;
			set
			{
				companyTextColor = value;
				OnPropertyChanged("CompanyTextColor");
			}
		}

		private Color companyBg;
		public Color CompanyBg
		{
			get => companyBg;
			set
			{
				companyBg = value;
				OnPropertyChanged("CompanyBg");
			}
		}

		private bool isPrivate;
		public bool IsPrivate
		{
			get => isPrivate;
			set
			{
				isPrivate = value;
				if (isPrivate)
				{
					PrivateTextColor = Color.FromHex("#181A1F");
					PrivateBg = Color.FromHex("#4CD964");

					CompanyTextColor = Color.Gray;
					CompanyBg = Color.Transparent;
				}
				else
				{
					PrivateTextColor = Color.Gray;
					PrivateBg = Color.Transparent;

					CompanyTextColor = Color.FromHex("#181A1F");
					CompanyBg = Color.FromHex("#4CD964");
				}
				OnPropertyChanged("IsPrivate");
			}
		}

		private string nameOnTheDoor;
		public string NameOnTheDoor
		{
			get => nameOnTheDoor;
			set
			{
				nameOnTheDoor = value;
				OnPropertyChanged("NameOnTheDoor");
			}
		}

		private string streetAddress;
		public string StreetAddress
		{
			get => streetAddress;
			set
			{
				streetAddress = value;
				OnPropertyChanged("StreetAddress");
			}
		}

		private string number;
		public string Number
		{
			get => number;
			set
			{
				number = value;
				OnPropertyChanged("Number");
			}
		}

		private string zipCode;
		public string ZipCode
		{
			get => zipCode;
			set
			{
				zipCode = value;
				OnPropertyChanged("ZipCode");
			}
		}

		private string city;
		public string City
		{
			get => city;
			set
			{
				city = value;
				OnPropertyChanged("City");
			}
		}

		private string nameOnTheCard;
		public string NameOnTheCard
		{
			get => nameOnTheCard;
			set
			{
				nameOnTheCard = value;
				OnPropertyChanged("NameOnTheCard");
			}
		}

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

		private string cvc;
		public string CVC
		{
			get => cvc;
			set
			{
				cvc = value;
				OnPropertyChanged("CVC");
			}
		}
		#endregion
	}
}