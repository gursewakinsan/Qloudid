using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.AddressBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressBookListPage : ContentPage
    {
        AddressBookListPageViewModel viewModel;
        public AddressBookListPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddressBookListPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
          //  viewModel.GetUserAddressBookContactsCommand.Execute(null);
        }
    }
}
