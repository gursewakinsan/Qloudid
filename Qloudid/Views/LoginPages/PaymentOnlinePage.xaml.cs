using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.LoginPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentOnlinePage : ContentPage
    {
        PaymentOnlinePageViewModel viewModel;
        public PaymentOnlinePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new PaymentOnlinePageViewModel(this.Navigation);
        }
    }


}
