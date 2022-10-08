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

        private async void OnTenantsRequestDetailItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.TenantsRequestDetail tenants = e.Item as Models.TenantsRequestDetail;
            listTenantsRequestDetail.SelectedItem = null;
            if (tenants.IsRequestReceived)
                await Navigation.PushAsync(new LandLoardConsentDetailsPage(tenants));
        }
    }
}