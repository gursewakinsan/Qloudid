using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Property
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandlordSendRequestPage : ContentPage
    {
        LandlordSendRequestPageViewModel viewModel;
        public LandlordSendRequestPage(Models.CompanyListSearchResponse company)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new LandlordSendRequestPageViewModel(this.Navigation);
            viewModel.SelectedCompanySearch = company;
        }

        #region On Appearing.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.UserPropertyCommand.Execute(null);
        }
        #endregion

        #region On Item Tapped.
        private void OnButtonTapped(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            OnItemTapped(control.BindingContext as Models.UserPropertyResponse);
        }

        private void OnBoxViewTapped(object sender, System.EventArgs e)
        {
            BoxView control = sender as BoxView;
            OnItemTapped(control.BindingContext as Models.UserPropertyResponse);
        }

        private void OnLabelTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnItemTapped(control.BindingContext as Models.UserPropertyResponse);
        }

        void OnItemTapped(Models.UserPropertyResponse userProperty)
        {
            viewModel.UserPropertyList.ForEach(x => x.IsSelected = false);
            userProperty.IsSelected = !userProperty.IsSelected;
            viewModel.BId = userProperty.Id;
        }
        #endregion
    }
}