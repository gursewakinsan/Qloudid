using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.LoginPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpressCheckInOutPage : ContentPage
    {
        ExpressCheckInOutPageViewModel viewModel;
        public ExpressCheckInOutPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ExpressCheckInOutPageViewModel(this.Navigation);
        }
    }

    //Will remove this line
}




