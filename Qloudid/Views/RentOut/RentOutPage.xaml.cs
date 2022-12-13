using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RentOutPage : ContentPage
    {
        RentOutPageViewModel viewModel;
        public RentOutPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new RentOutPageViewModel(this.Navigation);
        }
    }
}