using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CleanByPage : ContentPage
    {
        CleanByPageViewModel viewModel;
        public CleanByPage(Models.ApartmentCheckedinInfoResponse apartment)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new CleanByPageViewModel(this.Navigation);
            viewModel.ApartmentCheckedIn = apartment;
        }
    }
}
