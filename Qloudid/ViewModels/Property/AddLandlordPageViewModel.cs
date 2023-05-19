using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class AddLandlordPageViewModel : BaseViewModel
    {
        #region Constructor.
        public AddLandlordPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            CountryList = Helper.Helper.CountryList.OrderBy(x => x.CountryCode).ToList();
            if(CountryList.Count > 0 ) 
                SelectedCountryCode = CountryList.FirstOrDefault(s => s.CountryCode == Helper.Helper.CountryCode);
        }
        #endregion

        #region User Property Command.
        private ICommand userPropertyCommand;
        public ICommand UserPropertyCommand
        {
            get => userPropertyCommand ?? (userPropertyCommand = new Command(async () => await ExecuteUserPropertyCommand()));
        }
        private async Task ExecuteUserPropertyCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IPropertyService service = new PropertyService();
            UserPropertyList = await service.UserPropertyAsync(new Models.UserPropertyRequest()
            {
                UserId = Helper.Helper.UserId
            });
            if(UserPropertyList?.Count >0)
                SelectedUserProperty = UserPropertyList[0];
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Add Landlord Command.
        private ICommand addLandlordCommand;
        public ICommand AddLandlordCommand
        {
            get => addLandlordCommand ?? (addLandlordCommand = new Command(async () => await ExecuteAddLandlordCommand()));
        }
        private async Task ExecuteAddLandlordCommand()
        {
            if (string.IsNullOrWhiteSpace(CompanyName))
                await Helper.Alert.DisplayAlert("Company name is required.");
            else if (string.IsNullOrWhiteSpace(MobileNumber))
                await Helper.Alert.DisplayAlert("Mobile number is required.");
            else if (MobileNumber.StartsWith("0"))
                await Helper.Alert.DisplayAlert("Mobile number cannot be start from zero.");
            else if (string.IsNullOrWhiteSpace(CompanyEmail))
                await Helper.Alert.DisplayAlert("Company email is required.");
            else if (!Helper.Helper.IsValid(CompanyEmail))
                await Helper.Alert.DisplayAlert("Please enter valid company email address.");
            else if (string.IsNullOrWhiteSpace(ChairmenEmail))
                await Helper.Alert.DisplayAlert("Chairmen email is required.");
            else if (!Helper.Helper.IsValid(ChairmenEmail))
                await Helper.Alert.DisplayAlert("Please enter valid chairmen email address.");
            else if (string.IsNullOrWhiteSpace(ViceChairmenEmail))
                await Helper.Alert.DisplayAlert("Vice chairmen email is required.");
            else if (!Helper.Helper.IsValid(ViceChairmenEmail))
                await Helper.Alert.DisplayAlert("Please enter valid vice chairmen email address.");
            else if (string.IsNullOrWhiteSpace(SecratoryEmail))
                await Helper.Alert.DisplayAlert("Secratory email is required.");
            else if (!Helper.Helper.IsValid(SecratoryEmail))
                await Helper.Alert.DisplayAlert("Please enter valid secratory email address.");
            else if (string.IsNullOrWhiteSpace(ManagerEmail))
                await Helper.Alert.DisplayAlert("Manager email is required.");
            else if (!Helper.Helper.IsValid(ManagerEmail))
                await Helper.Alert.DisplayAlert("Please enter valid manager email address.");
            else
            {
                DependencyService.Get<IProgressBar>().Show();
                IPropertyService service = new PropertyService();
                Models.AddLandloardRequest request = new Models.AddLandloardRequest()
                {
                    UserId = Helper.Helper.UserId,
                    CompanyName = CompanyName,
                    PhoneNumber = MobileNumber,
                    CompanyEmail = CompanyEmail,
                    ChairmenEmail = ChairmenEmail,
                    ViceChairmenEmail = ViceChairmenEmail,
                    SecratoryEmail = SecratoryEmail,
                    CountryId = SelectedCountryCode.Id,
                    BId = SelectedUserProperty.Id,
                    ManagerEmail = ManagerEmail
                };
                await service.AddLandloardAsync(request);
                DependencyService.Get<IProgressBar>().Hide();
                Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
            }
        }
        #endregion

        #region Properties.
        private List<Models.Country> countryList;
        public List<Models.Country> CountryList
        {
            get => countryList;
            set
            {
                countryList = value;
                OnPropertyChanged("CountryList");
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

        private List<Models.UserPropertyResponse> userPropertyList;
        public List<Models.UserPropertyResponse> UserPropertyList
        {
            get => userPropertyList;
            set
            {
                userPropertyList = value;
                OnPropertyChanged("UserPropertyList");
            }
        }

        private Models.UserPropertyResponse selectedUserProperty;
        public Models.UserPropertyResponse SelectedUserProperty
        {
            get => selectedUserProperty;
            set
            {
                selectedUserProperty = value;
                OnPropertyChanged("SelectedUserProperty");
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

        private string mobileNumber;
        public string MobileNumber
        {
            get => mobileNumber;
            set
            {
                mobileNumber = value;
                OnPropertyChanged("MobileNumber");
            }
        }

        private string companyEmail;
        public string CompanyEmail
        {
            get => companyEmail;
            set
            {
                companyEmail = value;
                OnPropertyChanged("CompanyEmail");
            }
        }

        private string chairmenEmail;
        public string ChairmenEmail
        {
            get => chairmenEmail;
            set
            {
                chairmenEmail = value;
                OnPropertyChanged("ChairmenEmail");
            }
        }

        private string viceChairmenEmail;
        public string ViceChairmenEmail
        {
            get => viceChairmenEmail;
            set
            {
                viceChairmenEmail = value;
                OnPropertyChanged("ViceChairmenEmail");
            }
        }

        private string secratoryEmail;
        public string SecratoryEmail
        {
            get => secratoryEmail;
            set
            {
                secratoryEmail = value;
                OnPropertyChanged("SecratoryEmail");
            }
        }

        private string managerEmail;
        public string ManagerEmail
        {
            get => managerEmail;
            set
            {
                managerEmail = value;
                OnPropertyChanged("ManagerEmail");
            }
        }
        #endregion
    }
}

