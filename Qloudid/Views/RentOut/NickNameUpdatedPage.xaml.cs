using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NickNameUpdatedPage : ContentPage
    {
        #region Variables.
        NickNameUpdatedPageViewModel viewModel;
        #endregion
        
        #region Constructor.
        public NickNameUpdatedPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new NickNameUpdatedPageViewModel(this.Navigation);
        }
        #endregion
    }
}