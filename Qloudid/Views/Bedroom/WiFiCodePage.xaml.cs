using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WiFiCodePage : ContentPage
    {
        WiFiCodePageViewModel viewModel;
        public WiFiCodePage(Models.EditAddressResponse editAddress)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new WiFiCodePageViewModel(this.Navigation);
            viewModel.IsWifiAvailable = editAddress.IsWifiAvailable;
            viewModel.WifiUsername = editAddress.WifiUsername;
            viewModel.WifiPassword = editAddress.WifiPassword;
        }
    }
}