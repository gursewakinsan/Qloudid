using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoAccountFoundPage : ContentPage
    {
        NoAccountFoundPageViewModel viewModel;
        public NoAccountFoundPage(string phoneNumber)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new NoAccountFoundPageViewModel(this.Navigation);
            lblText.Text = $"Is connected to the phone no: {phoneNumber}";
        }
    }
}