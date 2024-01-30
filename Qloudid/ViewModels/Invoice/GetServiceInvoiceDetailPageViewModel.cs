using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class GetServiceInvoiceDetailPageViewModel : BaseViewModel
    {
        #region Constructor.
        public GetServiceInvoiceDetailPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Service Invoice Detail Command.
        private ICommand serviceInvoiceDetailCommand;
        public ICommand ServiceInvoiceDetailCommand
        {
            get => serviceInvoiceDetailCommand ?? (serviceInvoiceDetailCommand = new Command(async () => await ExecuteServiceInvoiceDetailCommand()));
        }
        private async Task ExecuteServiceInvoiceDetailCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IInvoiceService service = new InvoiceService();
            ServiceInvoiceDetail = await service.GetServiceInvoiceDetailAsync(new Models.GetServiceInvoiceDetailRequest()
            {
                InvoiceId = Helper.Helper.InvoiceId
            });
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Sign Command.
        private ICommand signCommand;
        public ICommand SignCommand
        {
            get => signCommand ?? (signCommand = new Command( () =>  ExecuteSignCommand()));
        }
        private void ExecuteSignCommand()
        {
            Application.Current.MainPage = new NavigationPage(new Views.Hotel.VerifyHotelPasswordPage());
        }
        #endregion

        #region Back Command.
        private ICommand backCommand;
        public ICommand BackCommand
        {
            get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
        }
        private void ExecuteBackCommand()
        {
            Application.Current.MainPage.Navigation.PushAsync(new Views.DashboardPage());
        }
        #endregion

        #region Properties.
        private Models.GetServiceInvoiceDetailResponse serviceInvoiceDetail;
        public Models.GetServiceInvoiceDetailResponse ServiceInvoiceDetail
        {
            get => serviceInvoiceDetail;
            set
            {
                serviceInvoiceDetail = value;
                OnPropertyChanged("ServiceInvoiceDetail");
            }
        }
        #endregion
    }
}
