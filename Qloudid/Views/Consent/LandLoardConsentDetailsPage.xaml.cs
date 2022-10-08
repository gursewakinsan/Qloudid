using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Consent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandLoardConsentDetailsPage : ContentPage
    {
        LandLoardConsentDetailsPageViewModel viewModel;
        public LandLoardConsentDetailsPage(Models.TenantsRequestDetail tenants)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new LandLoardConsentDetailsPageViewModel(this.Navigation);
            viewModel.SelectedTenantsDetail = tenants;
        }
    }
}