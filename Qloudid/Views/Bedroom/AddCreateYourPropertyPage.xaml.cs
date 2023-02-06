using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCreateYourPropertyPage : ContentPage
    {
        AddCreateYourPropertyPageViewModel viewModel;
        public AddCreateYourPropertyPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddCreateYourPropertyPageViewModel(this.Navigation);
        }
    }
}