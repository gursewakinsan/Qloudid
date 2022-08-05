using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using Qloudid.Controls;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BedRoomDetailsPage : ContentPage
    {
        #region Variables.
        bool status = false;
        BedRoomDetailsPageViewModel viewModel;
        #endregion

        #region Constructor.
        public BedRoomDetailsPage(Models.BedroomDetailResponse bedroom)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new BedRoomDetailsPageViewModel(this.Navigation);
            viewModel.SelectedBedroomDetail = bedroom;
        }
        #endregion

        #region On Appearing.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.BedroomBedDetailCommand.Execute(null);
        }
        #endregion

        #region On Appearing.
        private void OnPickerSelectedIndexChanged(object sender, System.EventArgs e)
        {
            CustomPicker picker = sender as CustomPicker;
            if (picker.SelectedIndex == -1) return;
            else
            {
                string str = picker.ClassId;
                if (status)
                {
                    viewModel.BedId = System.Convert.ToInt32(picker.ClassId);
                    Models.Bedtype bedtype = picker.SelectedItem as Models.Bedtype;
                    viewModel.BedInfo = bedtype.BedType;
                    viewModel.UpdateBedTypeInfoCommand.Execute(null);
                    status = false;
                }
            }
        }
        #endregion

        private void CustomPicker_Focused(object sender, FocusEventArgs e)
        {
            status = true;
        }
    }
}