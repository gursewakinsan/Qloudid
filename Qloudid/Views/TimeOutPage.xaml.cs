using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimeOutPage : ContentPage
	{
		public TimeOutPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
		}

		private void OnContinueButtonClicked(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new DashboardPage());
		}
	}
}