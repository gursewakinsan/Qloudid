using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeRepairPage : ContentPage
    {
        #region Variables.
        HomeRepairPageViewModel viewModel;
        #endregion
        
        #region Constructor.
        public HomeRepairPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new HomeRepairPageViewModel(this.Navigation);
        }
        #endregion

        #region On Appearing.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.HomeRepairCategoryInfoCommand.Execute(null);
        }
        #endregion

        #region On Home Repair Category Info Item Tapped.
        private async void OnButtonCategoryInfoClicked(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            Models.HomeRepairCategoryInfoResponse homeRepair = control.BindingContext as Models.HomeRepairCategoryInfoResponse;
            await Navigation.PushAsync(new AmenitiesSubCategoryDetailPage(homeRepair.Id));
        }

        private async void OnLabelCategoryInfoClicked(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            Models.HomeRepairCategoryInfoResponse homeRepair = control.BindingContext as Models.HomeRepairCategoryInfoResponse;
            await Navigation.PushAsync(new AmenitiesSubCategoryDetailPage(homeRepair.Id));
        }
        #endregion
    }
}
