using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeadLineUpdatedPage : ContentPage
    {
        #region Variables.
        HeadLineUpdatedPageViewModel viewModel;
        #endregion

        #region Constructor.
        public HeadLineUpdatedPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new HeadLineUpdatedPageViewModel(this.Navigation);
        }
        #endregion
    }
}