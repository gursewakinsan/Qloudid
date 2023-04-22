using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AmenitiesSubCategoryDetailPage : ContentPage
    {
        #region Variables.
        AmenitiesSubCategoryDetailPageViewModel viewModel;
        #endregion
        
        #region Constructor.
        public AmenitiesSubCategoryDetailPage(int categoryId)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AmenitiesSubCategoryDetailPageViewModel(this.Navigation);
            viewModel.CategoryId = categoryId;
        }
        #endregion

        #region On Appearing.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.AmenitiesSubCategoryDetailCommand.Execute(null);
        }
        #endregion
    }
}
