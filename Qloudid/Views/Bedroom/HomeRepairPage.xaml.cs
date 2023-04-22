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
        async void OnHomeRepairCategoryInfoItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Models.HomeRepairCategoryInfoResponse homeRepair = e.Item as Models.HomeRepairCategoryInfoResponse;
            listHomeRepairCategoryInfo.SelectedItem = null;
            await Navigation.PushAsync(new AmenitiesSubCategoryDetailPage(homeRepair.Id));
        }
        #endregion
    }
}
