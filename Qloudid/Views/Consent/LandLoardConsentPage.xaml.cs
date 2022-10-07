using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Consent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandLoardConsentPage : ContentPage
    {
        LandLoardConsentPageViewModel viewModel;
        public LandLoardConsentPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new LandLoardConsentPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ReceivedRequestDetailTenantsCommand.Execute(null);
        }
    }
}