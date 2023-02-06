using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetStartedPropertyPage : ContentPage
    {
        #region Variables.
        GetStartedPropertyPageViewModel viewModel;
        #endregion
       
        #region Constructor.
        public GetStartedPropertyPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new GetStartedPropertyPageViewModel(this.Navigation);
        }
        #endregion
    }
}