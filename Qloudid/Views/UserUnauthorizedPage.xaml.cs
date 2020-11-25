using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserUnauthorizedPage : ContentPage
	{
		public UserUnauthorizedPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
		}
		private async void OnBackButtonClicked(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}