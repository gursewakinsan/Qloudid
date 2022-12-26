using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescriptionUpdatedPage : ContentPage
    {
        #region Variables.
        DescriptionUpdatedPageViewModel viewModel;
        #endregion

        #region Constructor.
        public DescriptionUpdatedPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new DescriptionUpdatedPageViewModel(this.Navigation);
        }
        #endregion
    }
}