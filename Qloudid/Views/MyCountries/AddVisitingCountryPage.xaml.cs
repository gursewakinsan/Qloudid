using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.MyCountries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVisitingCountryPage : ContentPage
    {
        AddVisitingCountryPageViewModel viewModel;
        public AddVisitingCountryPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddVisitingCountryPageViewModel(this.Navigation);
        }
    }
}