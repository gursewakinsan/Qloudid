using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Identity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewPassportIdPage : ContentPage
    {
        AddNewPassportIdPageViewModel viewModel;
        public AddNewPassportIdPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddNewPassportIdPageViewModel(this.Navigation);
        }
    }
}
