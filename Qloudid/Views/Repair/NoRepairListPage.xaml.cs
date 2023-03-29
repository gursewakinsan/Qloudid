using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Repair
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoRepairListPage : ContentPage
    {
        NoRepairListPageViewModel viewModel;
        public NoRepairListPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new NoRepairListPageViewModel(this.Navigation);
        }
    }
}
