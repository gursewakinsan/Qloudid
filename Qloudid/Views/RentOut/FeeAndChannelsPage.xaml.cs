using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeeAndChannelsPage : ContentPage
    {
        #region Variables.
        FeeAndChannelsPageViewModel viewModel;
        #endregion

        #region Constructor.
        public FeeAndChannelsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new FeeAndChannelsPageViewModel(this.Navigation);
        }
        #endregion
    }
}