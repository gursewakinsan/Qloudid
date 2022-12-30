using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManualsPage : ContentPage
    {
        #region Variables.
        ManualsPageViewModel viewModel;
        #endregion

        #region Constructor.
        public ManualsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ManualsPageViewModel(this.Navigation);
        }
        #endregion

        #region On Appearing.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetSratedManualsDetailCommand.Execute(null);
        }
        #endregion

        #region On Started Manuals Tapped.
        private async void OnStartedManualsTapped(object sender, ItemTappedEventArgs e)
        {
            Models.GetSratedDetailResponse manuals = e.Item as Models.GetSratedDetailResponse;
            listStartedManuals.SelectedItem = null;
            await Navigation.PushAsync(new StartedManualsDetailsPage(manuals));
        }
        #endregion
    }
}