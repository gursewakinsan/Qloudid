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

		private void OnBackButtonClicked(object sender, System.EventArgs e)
		{
			Helper.Helper.IpFromURL = string.Empty;
			Application.Current.MainPage = new NavigationPage(new RestorePage());
		}
	}
}