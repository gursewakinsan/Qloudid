using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WiFiCodePage : ContentPage
    {
        WiFiCodePageViewModel viewModel;
        public WiFiCodePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new WiFiCodePageViewModel(this.Navigation);
        }
    }
}