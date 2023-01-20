using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
    public class AddNewGuestDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public AddNewGuestDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
			CountryList = new ObservableCollection<Models.Country>(Helper.Helper.CountryList);
			SelectedCountry = CountryList[0];
			CountryCodeList = new ObservableCollection<Models.Country>(Helper.Helper.CountryList);
			SelectedCountryCode = CountryCodeList[0];
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

		private ObservableCollection<Models.Country> countryList;
		public ObservableCollection<Models.Country> CountryList
		{
			get => countryList;
			set
			{
				countryList = value;
				OnPropertyChanged("CountryList");
			}
		}

		private Models.Country selectedCountry;
		public Models.Country SelectedCountry
		{
			get => selectedCountry;
			set
			{
				selectedCountry = value;
				OnPropertyChanged("SelectedCountry");
			}
		}

		private ObservableCollection<Models.Country> countryCodeList;
		public ObservableCollection<Models.Country> CountryCodeList
		{
			get => countryCodeList;
			set
			{
				countryCodeList = value;
				OnPropertyChanged("CountryCodeList");
			}
		}

		private Models.Country selectedCountryCode;
		public Models.Country SelectedCountryCode
		{
			get => selectedCountryCode;
			set
			{
				selectedCountryCode = value;
				OnPropertyChanged("SelectedCountryCode");
			}
		}

		public DateTime BindIssueMinimumDate => DateTime.Today.AddYears(-70);
		public DateTime BindIssueMaximumDate => DateTime.Today.AddDays(-1);
		public DateTime SelectedIssueDate { get; set; }
		public DateTime BindExpiryMinimumDate => DateTime.Today;
		public DateTime BindExpiryMaximumDate => DateTime.Today.AddYears(70);
		public DateTime SelectedExpiryDate { get; set; }
		public byte[] UserImageDataFront { get; set; }
		public byte[] UserImageDataBack { get; set; }
		#endregion
	}
}
