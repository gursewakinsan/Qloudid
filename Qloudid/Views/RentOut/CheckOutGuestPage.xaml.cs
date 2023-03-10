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

        void OnPreCheckInItemTapped(System.Object sender, ItemTappedEventArgs e)
        {
            listPreCheckIn.SelectedItem = null;
        }
    }
}
