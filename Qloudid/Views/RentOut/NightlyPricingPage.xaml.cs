using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NightlyPricingPage : ContentPage
    {
        NightlyPricingPageViewModel viewModel;
        public NightlyPricingPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new NightlyPricingPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            imgSeasonality.Source = ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/grases.png"));
            viewModel.SeasonalityTemplate = 1;
            viewModel.AddPricingPeriodCommand.Execute(null);
        }

        private void OnCustomPickerSelectedIndexChanged(object sender, System.EventArgs e)
        {
            Controls.CustomPicker picker = sender as Controls.CustomPicker;
            if (picker.SelectedIndex == -1)
                return;
            else
            {
                switch (picker.SelectedIndex)
                {
                    case 0:
                        if (viewModel != null)
                        {
                            viewModel.SeasonalityTemplate = 1;
                            imgSeasonality.Source = ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/grases.png"));
                        }
                        break;
                    case 1:
                        if (viewModel != null)
                        {
                            viewModel.SeasonalityTemplate = 2;
                            imgSeasonality.Source = ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/flatses.png"));
                        }
                        break;
                    case 2:
                        if (viewModel != null)
                        {
                            viewModel.SeasonalityTemplate = 3;
                            imgSeasonality.Source = ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/quases.png"));
                        }
                        break;
                    case 3:
                        if (viewModel != null)
                        {
                            viewModel.SeasonalityTemplate = 4;
                            imgSeasonality.Source = ImageSource.FromUri(new System.Uri("https://www.qloudid.com/html/usercontent/images/sumses.png"));
                        }
                        break;
                }
            }
        }
    }
}