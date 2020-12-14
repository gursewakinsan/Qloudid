using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InvalidCertificatePage : ContentPage
	{
		public InvalidCertificatePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
		}
		
		private async void OnBackButtonClicked(object sender, System.EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(Helper.Helper.IpFromURL))
			{
				Helper.Helper.IpFromURL = string.Empty;
				Application.Current.MainPage = new NavigationPage(new RestorePage());
			}
			else
				await Navigation.PopAsync();
		}
	}
}