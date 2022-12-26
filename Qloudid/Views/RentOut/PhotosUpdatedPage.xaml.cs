using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotosUpdatedPage : ContentPage
    {
        #region Variables.
        PhotosUpdatedPageViewModel viewModel;
        #endregion

        #region Constructor.
        public PhotosUpdatedPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new PhotosUpdatedPageViewModel(this.Navigation);
        }
        #endregion
    }
}