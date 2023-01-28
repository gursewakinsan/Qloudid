using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStorePage : ContentPage
    {
        AppStorePageViewModel viewModel;
        public AppStorePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AppStorePageViewModel(this.Navigation);
        }
    }
}