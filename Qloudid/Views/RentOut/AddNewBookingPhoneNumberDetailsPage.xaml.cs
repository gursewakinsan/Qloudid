using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewBookingPhoneNumberDetailsPage : ContentPage
    {
        AddNewBookingPhoneNumberDetailsPageViewModel viewModel;
        public AddNewBookingPhoneNumberDetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddNewBookingPhoneNumberDetailsPageViewModel(this.Navigation);
        }
    }
}