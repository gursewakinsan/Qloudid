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

        #region On Bedrooms Clicked Event.
        async void OnBedroomsClickedEvent(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new UpdateMyHomeDetailsPage());
        }
        #endregion

        #region On Bathroom Clicked Event.
        async void OnBathroomClickedEvent(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new BathroomsDetailsPage());
        }
        #endregion
    }
}