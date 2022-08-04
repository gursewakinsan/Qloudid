using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyHomeDetailsPage : ContentPage
    {
        #region Variables.
        MyHomeDetailsPageViewModel viewModel;
        #endregion

        #region Constructor.
        public MyHomeDetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new MyHomeDetailsPageViewModel(this.Navigation);
        }
        #endregion

        #region On Clicked Event.
        async void OnClickedEvent(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new UpdateMyHomeDetailsPage());
        }
        #endregion
    }
}