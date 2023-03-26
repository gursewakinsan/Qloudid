using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Identity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddYourIdCardPage : ContentPage
    {
        AddYourIdCardPageViewModel viewModel;
        public AddYourIdCardPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddYourIdCardPageViewModel(this.Navigation);
        }
    }
}
