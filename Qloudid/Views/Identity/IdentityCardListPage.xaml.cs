using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Identity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IdentityCardListPage : ContentPage
    {
        IdentityCardListPageViewModel viewModel;
        public IdentityCardListPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new IdentityCardListPageViewModel(this.Navigation);
        }

        void OnIdentityItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            listIdentity.SelectedItem = null;
        }
    }
}
