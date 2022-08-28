using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.MyCountries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeProfilePage : ContentPage
    {
        ChangeProfilePageViewModel viewModel;
        public ChangeProfilePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ChangeProfilePageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.CurrentCountryDetailCommand.Execute(null);
        }

        #region On Plus Button Tapped.
        private void OnFrameTapped(object sender, System.EventArgs e)
        {
            Frame frame = sender as Frame;
            OnPlusButtonTapped(frame.BindingContext as Models.CurrentCountryDetailResponse);
        }

        private void OnGridTapped(object sender, System.EventArgs e)
        {
           Grid grid = sender as Grid;
            OnPlusButtonTapped(grid.BindingContext as Models.CurrentCountryDetailResponse);
        }

        private void OnLabelTapped(object sender, System.EventArgs e)
        {
            Label label = sender as Label;
            OnPlusButtonTapped(label.BindingContext as Models.CurrentCountryDetailResponse);
        }

        private void OnPlusButtonClicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            OnPlusButtonTapped(button.BindingContext as Models.CurrentCountryDetailResponse);
        }

        void OnPlusButtonTapped(Models.CurrentCountryDetailResponse response)
        {
            viewModel.SelectedCurrentCountryDetailCommand.Execute(null);
        }
        #endregion
    }
}