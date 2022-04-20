using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views.PreCheckIn
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UnauthorizedPreCheckInPage : ContentPage
	{
		public UnauthorizedPreCheckInPage ()
		{
			InitializeComponent ();
		}

		private void OnButtonTapped(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new DashboardPage());
		}
	}
}