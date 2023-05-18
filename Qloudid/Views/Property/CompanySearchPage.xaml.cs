using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Property
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanySearchPage : ContentPage
    {
        CompanySearchPageViewModel viewModel;
        public CompanySearchPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new CompanySearchPageViewModel(this.Navigation);
        }
    }
}