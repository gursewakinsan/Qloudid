using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Qloudid.ViewModels
{
    public class LandlordSendRequestPageViewModel : BaseViewModel
    {
        #region Constructor.
        public LandlordSendRequestPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            BId = 0;
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
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Send Request Command.
        private ICommand sendRequestCommand;
        public ICommand SendRequestCommand
        {
            get => sendRequestCommand ?? (sendRequestCommand = new Command(async () => await ExecuteSendRequestCommand()));
        }
        private async Task ExecuteSendRequestCommand()
        {
            if (BId == 0)
                await Helper.Alert.DisplayAlert("Please select Property");
            else
            {
                DependencyService.Get<IProgressBar>().Show();
                IPropertyService service = new PropertyService();
                await service.SendLandloardRequestAsync(new Models.SendLandloardRequest()
                {
                    BId = BId,
                    CompanyId = SelectedCompanySearch.Id
                });
                DependencyService.Get<IProgressBar>().Hide();
                Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
            }
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
       
        public int BId { get; set; }
        public Models.CompanyListSearchResponse SelectedCompanySearch { get; set; }
        #endregion
    }
}
