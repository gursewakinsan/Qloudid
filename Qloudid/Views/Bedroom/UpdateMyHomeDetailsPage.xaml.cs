using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateMyHomeDetailsPage : ContentPage
    {
        #region Variables.
        UpdateMyHomeDetailsPageViewModel viewModel;
        #endregion

        #region Constructor.
        public UpdateMyHomeDetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new UpdateMyHomeDetailsPageViewModel(this.Navigation);
        }
        #endregion

        #region On Appearing.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.BedroomDetailCommand.Execute(null);
        }
        #endregion

        private void OnFrameTapped(object sender, System.EventArgs e)
        {

        }

        private void OnGridTapped(object sender, System.EventArgs e)
        {

        }

        private void OnLabelTapped(object sender, System.EventArgs e)
        {

        }

        private void OnButtonTapped(object sender, System.EventArgs e)
        {

        }
    }
}