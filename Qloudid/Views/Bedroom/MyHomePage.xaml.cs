using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyHomePage : ContentPage
    {
        #region Variables.
        MyHomePageViewModel viewModel;
        #endregion

        #region Constructor.
        public MyHomePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new MyHomePageViewModel(this.Navigation);
        }
        #endregion

        #region On Appearing.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.BedroomDetailCommand.Execute(null);
        }
        #endregion

        #region On List View Clicked.
        private void OnFrameTapped(object sender, System.EventArgs e)
        {
            Frame control = sender as Frame;
            HandleClickedEvent(control.BindingContext as Models.UserDeliveryAddressesResponse);
        }
        private void OnGridTapped(object sender, System.EventArgs e)
        {
            Grid control = sender as Grid;
            HandleClickedEvent(control.BindingContext as Models.UserDeliveryAddressesResponse);
        }
        private void OnStackLayoutTapped(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            HandleClickedEvent(control.BindingContext as Models.UserDeliveryAddressesResponse);
        }
        private void OnLabelTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            HandleClickedEvent(control.BindingContext as Models.UserDeliveryAddressesResponse);
        }
        private void OnButtonTapped(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            HandleClickedEvent(control.BindingContext as Models.UserDeliveryAddressesResponse);
        }

        async void HandleClickedEvent(Models.UserDeliveryAddressesResponse userDelivery)
        {
            Helper.Helper.SelectedUserDeliveryAddress = userDelivery;
            //await Navigation.PushAsync(new MyHomeDetailsPage());
            if (!userDelivery.IsOwnershipUpdated)
                await Navigation.PushAsync(new OwnershipUpdatedPage());
            else
                await Navigation.PushAsync(new ApartmentInfoPage());
        }
        #endregion
    }
}