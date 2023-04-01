using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.AddressBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewContactDetailPage : ContentPage
    {
        AddNewContactDetailPageViewModel viewModel;
        public AddNewContactDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddNewContactDetailPageViewModel(this.Navigation);
        }

        void OnEmailRemoveClicked(System.Object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            viewModel.ListOfContactEmailAddress.Remove(button.BindingContext as Models.ContactEmailDetail);
        }

        void OnPhoneRemoveClicked(System.Object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            viewModel.ListOfContactPhoneNumber.Remove(button.BindingContext as Models.ContactPhoneNumberDetail);
        }

        void OnAddressRemoveClicked(System.Object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            viewModel.ListOfContactAddressNumber.Remove(button.BindingContext as Models.ContactAddressDetail);
        }

        void OnCardRemoveClicked(System.Object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            viewModel.ListOfContactCard.Remove(button.BindingContext as Models.ContactCardDetail);
        }
    }
}
