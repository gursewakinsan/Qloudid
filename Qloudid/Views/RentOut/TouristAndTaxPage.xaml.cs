using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TouristAndTaxPage : ContentPage
    {
        TouristAndTaxPageViewModel viewModel;
        public TouristAndTaxPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TouristAndTaxPageViewModel(this.Navigation);
        }
    }
}