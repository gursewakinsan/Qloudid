using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Booking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageYourReservationsPage : ContentPage
    {
        ManageYourReservationsPageViewModel viewModel;
        public ManageYourReservationsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ManageYourReservationsPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ManageReservationsCommand.Execute(null);
        }

        private async void OnConfirmButtonClicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            Helper.Helper.IsManageYourReservations = true;
            Helper.Helper.HotelBookingId = button.ClassId;
            await Navigation.PushAsync(new Hotel.VerifyHotelPasswordPage());
        }
    }
}