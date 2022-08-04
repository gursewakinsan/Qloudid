using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateMyHomeDetailsPage : ContentPage
    {
        #region Variables.
        UpdateMyHomeDetailsPageViewModel viewModel;
        #endregion

        #region Constructor.
        public UpdateMyHomeDetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new UpdateMyHomeDetailsPageViewModel(this.Navigation);
        }
        #endregion

        #region On Appearing.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.BedroomDetailCommand.Execute(null);
        }
        #endregion

        private void OnFrameTapped(object sender, System.EventArgs e)
        {
            Frame control = sender as Frame;
            OnSelectedItemClicked(control.BindingContext as Models.BedroomDetailResponse);
        }

        private void OnGridTapped(object sender, System.EventArgs e)
        {
            Grid control = sender as Grid;
            OnSelectedItemClicked(control.BindingContext as Models.BedroomDetailResponse);
        }

        private void OnLabelTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnSelectedItemClicked(control.BindingContext as Models.BedroomDetailResponse);
        }

        private void OnButtonTapped(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            OnSelectedItemClicked(control.BindingContext as Models.BedroomDetailResponse);
        }

        async void OnSelectedItemClicked(Models.BedroomDetailResponse bedroom)
        {
            await Navigation.PushAsync(new BedRoomDetailsPage(bedroom));
        }
    }
}