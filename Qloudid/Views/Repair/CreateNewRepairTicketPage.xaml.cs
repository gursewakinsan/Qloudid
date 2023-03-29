using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Repair
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateNewRepairTicketPage : ContentPage
    {
        CreateNewRepairTicketPageViewModel viewModel;
        public CreateNewRepairTicketPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new CreateNewRepairTicketPageViewModel(this.Navigation);
        }
    }
}
