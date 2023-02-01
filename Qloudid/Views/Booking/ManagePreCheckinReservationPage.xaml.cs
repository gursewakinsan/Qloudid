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
            viewModel.ManageReservationsCommand.Execute(null);
        }
    }
}