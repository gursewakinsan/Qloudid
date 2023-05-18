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
                //CountryId
                //BId
            };
            var res = await service.AddLandloardAsync(request);
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
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
        #endregion
    }
}

