using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Repair
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserApartmentSubpartProblemDetailPage : ContentPage
    {
        UserApartmentSubpartProblemDetailPageViewModel viewModel;
        public UserApartmentSubpartProblemDetailPage(Models.UserApartmentProblemDetailResponse userApartment)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new UserApartmentSubpartProblemDetailPageViewModel(this.Navigation);
            viewModel.SelectedApartmentProblemDetail = userApartment;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.UserApartmentSubpartProblemDetailCommand.Execute(null);
        }
    }
}