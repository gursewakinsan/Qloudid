using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views.PreCheckIn
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlreadyDonePreCheckInPage : ContentPage
	{
		public AlreadyDonePreCheckInPage ()
		{
			InitializeComponent ();
		}

		private void OnButtonTapped(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new DashboardPage());
		}
	}
}