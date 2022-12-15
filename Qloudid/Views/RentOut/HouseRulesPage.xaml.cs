using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HouseRulesPage : ContentPage
    {
        HouseRulesPageViewModel viewModel;
        public HouseRulesPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new HouseRulesPageViewModel(this.Navigation);
        }
    }
}