using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Booking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagePreCheckinReservationPage : ContentPage
    {
        ManagePreCheckinReservationPageViewModel viewModel;
        public ManagePreCheckinReservationPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ManagePreCheckinReservationPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ApartmentPreCheckinRequiredListCommand.Execute(null);
        }

        private void OnConfirmButtonClicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            var preCheckIn = button.BindingContext as Models.ApartmentPreCheckinRequiredListResponse;
            viewModel.PreCheckInPageCommand.Execute(preCheckIn.Enc);
            /*Models.GetPreCheckinStatusResponse fillData = new Models.GetPreCheckinStatusResponse()
            {
                BookingDates = preCheckIn.Duration,
                GuestAdult = preCheckIn.GuestAdult,
                GuestChildren = preCheckIn.GuestChildren,
                Id = preCheckIn.Id.ToString(),
                HotelName = preCheckIn.PropertyNickName,
                Name = Helper.Helper.UserInfo.DisplayUserName,
                Guests = preCheckIn.Guest
            };
            Helper.Helper.PreCheckinStatusInfo = fillData;
            Helper.Helper.PreCheckinStatus = 2;
            Helper.Helper.IsPreCheckIn = true;
            await Navigation.PushAsync(new PreCheckIn.PreCheckInPage());*/
        }
    }
}