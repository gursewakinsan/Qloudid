using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BedRoomDetailsPage : ContentPage
    {
        #region Variables.
        BedRoomDetailsPageViewModel viewModel;
        #endregion

        #region Constructor.
        public BedRoomDetailsPage(Models.BedroomDetailResponse bedroom)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new BedRoomDetailsPageViewModel(this.Navigation);
            viewModel.SelectedBedroomDetail = bedroom;
            if (bedroom.BedTypeList != null)
                viewModel.Count = bedroom.BedTypeList.Count;
        }
        #endregion
    }
}