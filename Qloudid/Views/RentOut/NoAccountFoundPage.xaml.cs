using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoAccountFoundPage : ContentPage
    {
        NoAccountFoundPageViewModel viewModel;
        public NoAccountFoundPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new NoAccountFoundPageViewModel(this.Navigation);
        }
    }
}