using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Repair
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeRepairPage : ContentPage
    {
        HomeRepairPageViewModel viewModel;
        public HomeRepairPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new HomeRepairPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.UserApartmentProblemDetailCommand.Execute(null);
        }

        async void OnApartmentProblemDetailItemTapped(System.Object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Models.UserApartmentProblemDetailResponse userApartment = e.ItemData as Models.UserApartmentProblemDetailResponse;
            listView.SelectedItem = null;
            if (userApartment.SubpartInfo > 0)
                await Navigation.PushAsync(new ReportTheProblemPage(userApartment));
            else
                await Navigation.PushAsync(new UserApartmentSubpartProblemDetailPage(userApartment));
        }
    }
}
