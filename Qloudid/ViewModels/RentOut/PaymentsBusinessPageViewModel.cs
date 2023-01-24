using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class PaymentsBusinessPageViewModel : BaseViewModel
    {
		#region Constructor.
		public PaymentsBusinessPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
			IsCompanyCard = Helper.Helper.SendBookingRequestInfo.IsPaid == 3 ? true : false;
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

		#region Save Company Details Command.
		private ICommand saveCompanyDetailsCommand;
		public ICommand SaveCompanyDetailsCommand
		{
			get => saveCompanyDetailsCommand ?? (saveCompanyDetailsCommand = new Command(async () => await ExecuteSaveCompanyDetailsCommand()));
		}
		private async Task ExecuteSaveCompanyDetailsCommand()
		{
			if (string.IsNullOrWhiteSpace(CompanyName))
				await Helper.Alert.DisplayAlert("Company name is required.");
			else if (string.IsNullOrWhiteSpace(VATCID))
				await Helper.Alert.DisplayAlert("VAT/CID is required.");
			else if (string.IsNullOrWhiteSpace(StreetAddress))
				await Helper.Alert.DisplayAlert("Street address is required.");
			else if (string.IsNullOrWhiteSpace(Number))
				await Helper.Alert.DisplayAlert("Number is required.");
			else if (string.IsNullOrWhiteSpace(ZipCode))
				await Helper.Alert.DisplayAlert("Zip code is required.");
			else if (string.IsNullOrWhiteSpace(City))
				await Helper.Alert.DisplayAlert("City is required.");
			else if (IsCompanyCard && string.IsNullOrWhiteSpace(NameOnTheCard))
				await Helper.Alert.DisplayAlert("Name on the card is required.");
			else if (IsCompanyCard && string.IsNullOrWhiteSpace(CardNumber))
				await Helper.Alert.DisplayAlert("Card number is required.");
			else if (IsCompanyCard && string.IsNullOrWhiteSpace(CVC))
				await Helper.Alert.DisplayAlert("CVC is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IRentOutService service = new RentOutService();
				await service.SaveCompanyDetailsAsync(new Models.SaveCompanyDetailsRequest()
				{
					card_number = CardNumber,
					cvv = CVC,
					company_name = CompanyName,
					d_address = StreetAddress,
					dcity = City,
					dpo_number = Number,
					dzip = ZipCode,
					expiry_month = SelectedIssueMonth,
					expiry_year = SelectedIssueYear,
					name_on_card = NameOnTheCard,
					cid_number = VATCID,
					booking_id = Helper.Helper.BookingId
				});
				this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
				this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
				this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
				this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
				this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
				await Navigation.PopAsync();
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

		private string companyName;
		public string CompanyName
		{
			get => companyName;
			set
			{
				companyName = value;
				OnPropertyChanged("CompanyName");
			}
		}

		private string vatcid;
		public string VATCID
		{
			get => vatcid;
			set
			{
				vatcid = value;
				OnPropertyChanged("VATCID");
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

		private bool isCompanyCard;
		public bool IsCompanyCard
		{
			get => isCompanyCard;
			set
			{
				isCompanyCard = value;
				OnPropertyChanged("IsCompanyCard");
			}
		}
		#endregion
	}
}
