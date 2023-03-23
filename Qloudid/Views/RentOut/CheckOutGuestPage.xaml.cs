using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckOutGuestPage : ContentPage
    {
        CheckOutGuestPageViewModel viewModel;
        public CheckOutGuestPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new CheckOutGuestPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ApartmentCheckedOutInfoCommand.Execute(null);
        }

        #region On Checked Out Tapped.
        void OnButtonCheckedOutClicked(System.Object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            CheckedOutListTapped(control.BindingContext as Models.ApartmentCheckedinInfoResponse);
        }

        void OnLabelCheckedOutClicked(System.Object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            CheckedOutListTapped(control.BindingContext as Models.ApartmentCheckedinInfoResponse);
        }

        void OnStackLayoutCheckedOutClicked(System.Object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            CheckedOutListTapped(control.BindingContext as Models.ApartmentCheckedinInfoResponse);
        }

        async void CheckedOutListTapped(Models.ApartmentCheckedinInfoResponse apartmentCheckedOut)
        {
            await Navigation.PushAsync(new ProcessToCheckOutPage(apartmentCheckedOut));
        }

        async void OnApartmentCheckedOutInfoItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Models.ApartmentCheckedinInfoResponse apartment = e.Item as Models.ApartmentCheckedinInfoResponse;
            listApartmentCheckedOutInfo.SelectedItem = null;
            if (apartment.CheckedIn == 1)
                await Navigation.PushAsync(new ProcessToCheckOutPage(apartment));
            else if (apartment.CheckedIn == 2 && apartment.GotToCleaning == 1)
                await Navigation.PushAsync(new ProcessToCheckInPage(apartment));
        }
        #endregion
    }
}