using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateNightlyPricingPage : ContentPage
    {
        UpdateNightlyPricingPageViewModel viewModel;
        public UpdateNightlyPricingPage(Models.NightlyPricingListResponse nightlyPricing)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new UpdateNightlyPricingPageViewModel(this.Navigation);
            viewModel.UpdateSelectedNightlyPricing = nightlyPricing;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.FillData();
        }
    }
}