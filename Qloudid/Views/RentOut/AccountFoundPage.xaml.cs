using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountFoundPage : ContentPage
    {
        AccountFoundPageViewModel viewModel;
        public AccountFoundPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AccountFoundPageViewModel(this.Navigation);
        }
    }
}