using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecurityDepositPage : ContentPage
    {
        SecurityDepositPageViewModel viewModel;
        public SecurityDepositPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new SecurityDepositPageViewModel(this.Navigation);
        }
    }
}