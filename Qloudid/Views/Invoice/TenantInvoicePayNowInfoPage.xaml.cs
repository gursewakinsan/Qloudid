using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Invoice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TenantInvoicePayNowInfoPage : ContentPage
    {
        TenantInvoicePayNowInfoPageViewModel viewModel;
        public TenantInvoicePayNowInfoPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TenantInvoicePayNowInfoPageViewModel(this.Navigation);
            lblUserName.Text = Helper.Helper.UserInfo.DisplayUserName;
        }
    }
}