using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Invoice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetServiceInvoiceDetailPage : ContentPage
    {
        GetServiceInvoiceDetailPageViewModel viewModel;
        public GetServiceInvoiceDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new GetServiceInvoiceDetailPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ServiceInvoiceDetailCommand.Execute(null);
        }
    }
}