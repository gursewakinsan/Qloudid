using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Repair
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RepairListPage : ContentPage
    {
        RepairListPageViewModel viewModel;
        public RepairListPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new RepairListPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.UserApartmentTicketListCommand.Execute(null);
        }
    }
}
