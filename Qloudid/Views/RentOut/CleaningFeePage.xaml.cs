using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CleaningFeePage : ContentPage
    {
        CleaningFeePageViewModel viewModel;
        public CleaningFeePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new CleaningFeePageViewModel(this.Navigation);
        }
    }
}