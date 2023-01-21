using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentsBusinessPage : ContentPage
    {
        PaymentsBusinessPageViewModel viewModel;
        public PaymentsBusinessPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new PaymentsBusinessPageViewModel(this.Navigation);
        }
    }
}