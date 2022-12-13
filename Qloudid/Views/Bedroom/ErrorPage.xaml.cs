using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorPage : ContentPage
    {
        #region Variables.
        ErrorPageViewModel viewModel;
        #endregion

        #region Constructor.
        public ErrorPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ErrorPageViewModel(this.Navigation);
        }
        #endregion
    }
}