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
    }
}
