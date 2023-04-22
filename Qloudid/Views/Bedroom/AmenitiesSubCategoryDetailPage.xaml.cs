using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using Qloudid.Controls;

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

        #region On Icon Up/Down Tapped.
        private void OnIconUpDownTapped(object sender, System.EventArgs e)
        {
            Label label = sender as Label;
            Models.AmenitiesSubcategoryDetailResponse amenities = label.BindingContext as Models.AmenitiesSubcategoryDetailResponse;
            amenities.IsOpen = !amenities.IsOpen;
        }
        #endregion

        #region On Select All Clicked.
        private void OnButtonSelectAllClicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            Models.AmenitiesSubcategoryDetailResponse amenities = button.BindingContext as Models.AmenitiesSubcategoryDetailResponse;
            amenities.SubCategoryInfo.ForEach(x => x.IsAvailable = true);
        }

        private void OnLabelSelectAllClicked(object sender, System.EventArgs e)
        {
            Label label = sender as Label;
            Models.AmenitiesSubcategoryDetailResponse amenities = label.BindingContext as Models.AmenitiesSubcategoryDetailResponse;
            amenities.SubCategoryInfo.ForEach(x => x.IsAvailable = true);
        }
        #endregion

        #region On Check Un-Check Button Clicked.
        private void OnCheckUncheckButtonClicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            Models.SubcategoryInfo subcategoryInfo = button.BindingContext as Models.SubcategoryInfo;
            subcategoryInfo.IsAvailable = !subcategoryInfo.IsAvailable;
        }
        #endregion

        #region On Check Un-Check Button Clicked.
        private void OnCustomPickerSelectedIndexChanged(object sender, System.EventArgs e)
        {
            CustomPicker picker = sender as CustomPicker;
            if (picker.SelectedIndex == -1 || viewModel == null) return;
            else
            {
                string str = picker.ClassId;
            }
        }
        #endregion
    }
}
