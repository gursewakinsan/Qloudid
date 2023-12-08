using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.LoginPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GlobalIdPage : ContentPage
    {
        GlobalIdPageViewModel viewModel;
        public GlobalIdPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new GlobalIdPageViewModel(this.Navigation);
        }
    }

}
