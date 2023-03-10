using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PoliceReportGuestPage : ContentPage
    {
        PoliceReportGuestPageViewModel viewModel;
        public PoliceReportGuestPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new PoliceReportGuestPageViewModel(this.Navigation);
        }

        void OnPreCheckInItemTapped(System.Object sender, ItemTappedEventArgs e)
        {
            listPreCheckIn.SelectedItem = null;
        }
    }
}
