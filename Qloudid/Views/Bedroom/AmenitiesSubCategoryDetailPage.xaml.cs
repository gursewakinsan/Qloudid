using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using Qloudid.Controls;
using Syncfusion.SfCalendar.XForms;
using Qloudid.Models;
using System;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AmenitiesSubCategoryDetailPage : ContentPage
    {
        #region Variables.
        AmenitiesSubCategoryDetailPageViewModel viewModel;
        bool isOpen = false;
        #endregion
        
        #region Constructor.
        public AmenitiesSubCategoryDetailPage(Models.HomeRepairCategoryInfoResponse homeRepair)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AmenitiesSubCategoryDetailPageViewModel(this.Navigation);
            viewModel.HomeRepairCategoryInfo = homeRepair;
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
            isOpen = true;
        }
        #endregion

        #region On Select All Clicked.
        private void OnButtonSelectAllClicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            Models.AmenitiesSubcategoryDetailResponse amenities = button.BindingContext as Models.AmenitiesSubcategoryDetailResponse;
            amenities.SubCategoryInfo.ForEach(x => x.IsAvailable = true);
            viewModel.AdvanceValues = amenities.AdvanceValues;
            viewModel.UpdateType = 3;
            viewModel.IsAvailable = 0;
            viewModel.UserAmenityId = 0;
            viewModel.WhoWillFixTheProblem = 0;
            viewModel.UpdateAminitySubcategoryCommand.Execute(null);
        }

        private void OnLabelSelectAllClicked(object sender, System.EventArgs e)
        {
            Label label = sender as Label;
            Models.AmenitiesSubcategoryDetailResponse amenities = label.BindingContext as Models.AmenitiesSubcategoryDetailResponse;
            amenities.SubCategoryInfo.ForEach(x => x.IsAvailable = true);
            viewModel.AdvanceValues = amenities.AdvanceValues;
            viewModel.UpdateType = 3;
            viewModel.IsAvailable = 0;
            viewModel.UserAmenityId = 0;
            viewModel.WhoWillFixTheProblem = 0;
            viewModel.UpdateAminitySubcategoryCommand.Execute(null);
        }
        #endregion

        #region On Check Un-Check Button Clicked.
        private void OnCheckUncheckButtonClicked(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            Models.SubcategoryInfo subcategoryInfo = button.BindingContext as Models.SubcategoryInfo;
            subcategoryInfo.IsAvailable = !subcategoryInfo.IsAvailable;
            viewModel.UpdateType = 1;
            viewModel.WhoWillFixTheProblem = 0;
            viewModel.IsAvailable = subcategoryInfo.IsAvailable ? 1 : 0;
            viewModel.AdvanceValues = subcategoryInfo.AdvanceValues;
            viewModel.UserAmenityId = subcategoryInfo.Id;
            viewModel.UpdateAminitySubcategoryCommand.Execute(null);
        }
        #endregion

        #region On Check Un-Check Button Clicked.
        private void OnCustomPickerSelectedIndexChanged(object sender, System.EventArgs e)
        {
            CustomPicker picker = sender as CustomPicker;
            if (picker.SelectedIndex == -1 || viewModel == null || !isOpen) return;
            else
            {
                viewModel.UpdateType = 2;
                viewModel.WhoWillFixTheProblem = picker.SelectedIndex +1;
                viewModel.IsAvailable = 0;
                viewModel.AdvanceValues = 0;
                viewModel.UserAmenityId = Convert.ToInt32(picker.ClassId);
                viewModel.UpdateAminitySubcategoryCommand.Execute(null);
            }
        }
        #endregion
    }
}
