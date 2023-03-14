using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreCheckInGuestPage : ContentPage
    {
        PreCheckInGuestPageViewModel viewModel;
        public PreCheckInGuestPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new PreCheckInGuestPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ReservationHistoryListCommand.Execute(null);
        }

        void OnPreCheckInItemTapped(System.Object sender, ItemTappedEventArgs e)
        {
            listPreCheckIn.SelectedItem = null;
        }
    }
}
