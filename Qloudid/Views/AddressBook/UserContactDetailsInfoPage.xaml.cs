using Xamarin.Forms;
using Qloudid.ViewModels;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views.AddressBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserContactDetailsInfoPage : ContentPage
    {
        UserContactDetailsInfoPageViewModel viewModel;
        public UserContactDetailsInfoPage(Models.UserAddressBookContactsResponse user)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new UserContactDetailsInfoPageViewModel(this.Navigation);
            viewModel.SelectedUser = user;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.UserAddessBookContactDetailInfoCommand.Execute(null);
        }
    }
}
