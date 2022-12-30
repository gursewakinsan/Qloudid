using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartedManualsDetailsPage : ContentPage
    {
        StartedManualsDetailsPageViewModel viewModel;
        public StartedManualsDetailsPage(Models.GetSratedDetailResponse selectedStartedManuals)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new StartedManualsDetailsPageViewModel(this.Navigation);
            viewModel.SelectedStartedManuals = selectedStartedManuals;
        }
    }
}