using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentsPersonalPage : ContentPage
    {
        PaymentsPersonalPageViewModel viewModel;
        public PaymentsPersonalPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new PaymentsPersonalPageViewModel(this.Navigation);
        }
    }
}