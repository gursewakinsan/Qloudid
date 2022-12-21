using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NightlyPricingListPage : ContentPage
    {
        #region Variables.
        NightlyPricingListPageViewModel viewModel;
        #endregion

        #region Constructor.
        public NightlyPricingListPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new NightlyPricingListPageViewModel(this.Navigation);
        }
        #endregion

        #region On Appearing.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.NightlyPricingListCommand.Execute(null);
        }
        #endregion

        #region On Nightly Pricing Clicked.
        private void OnButtonNightlyPricingClicked(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            OnNightlyPricingClicked(control.BindingContext as Models.NightlyPricingListResponse);
        }

        private void OnGridNightlyPricingClicked(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            OnNightlyPricingClicked(control.BindingContext as Models.NightlyPricingListResponse);
        }

        private void OnStackLayoutNightlyPricingClicked(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            OnNightlyPricingClicked(control.BindingContext as Models.NightlyPricingListResponse);
        }

        private void OnLabelNightlyPricingClicked(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnNightlyPricingClicked(control.BindingContext as Models.NightlyPricingListResponse);
        }

        private void OnFrameNightlyPricingClicked(object sender, System.EventArgs e)
        {
            Frame control = sender as Frame;
            OnNightlyPricingClicked(control.BindingContext as Models.NightlyPricingListResponse);
        }
        void OnNightlyPricingClicked(Models.NightlyPricingListResponse nightlyPricing)
        {
            viewModel.RemovePricingGapCommand.Execute(nightlyPricing);
        }
        #endregion

        
    }
}