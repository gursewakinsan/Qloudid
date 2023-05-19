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

        #region On Appearing.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.CompanyListSearchCommand.Execute(null);
        }
        #endregion

        #region On Item Tapped.
        private void OnGridTapped(object sender, System.EventArgs e)
        {
            Grid control = sender as Grid;
            OnItemTapped(control.BindingContext as Models.CompanyListSearchResponse);
        }

        private void OnButtonTapped(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            OnItemTapped(control.BindingContext as Models.CompanyListSearchResponse);
        }

        private void OnStackLayoutTapped(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            OnItemTapped(control.BindingContext as Models.CompanyListSearchResponse);
        }

        private void OnLabelTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnItemTapped(control.BindingContext as Models.CompanyListSearchResponse);
        }

        async void OnItemTapped(Models.CompanyListSearchResponse company)
        {
            await Navigation.PushAsync(new LandlordSendRequestPage(company));
        }
        #endregion
    }
}