using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Identity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoIdentityCardAddedPage : ContentPage
    {
        NoIdentityCardAddedPageViewModel viewModel;
        public NoIdentityCardAddedPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new NoIdentityCardAddedPageViewModel(this.Navigation);
        }
    }
}