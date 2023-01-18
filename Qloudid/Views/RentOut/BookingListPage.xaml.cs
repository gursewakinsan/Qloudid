using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingListPage : ContentPage
    {
        BookingListPageViewModel viewModel;
        public BookingListPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new BookingListPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ApartmentBookingListCommand.Execute(null);
        }

        private void OnBookingsItemTapped(object sender, ItemTappedEventArgs e)
        {
            listBookings.SelectedItem = null;
        }
    }
}