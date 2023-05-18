using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Property
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanySearchListPage : ContentPage
    {
        CompanySearchListPageViewModel viewModel;
        public CompanySearchListPage(string searchText)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new CompanySearchListPageViewModel(this.Navigation);
            viewModel.SearchText = searchText;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.CompanyListSearchCommand.Execute(null);
        }
    }
}