using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HotelCheckInErrorPage : ContentPage
	{
		public HotelCheckInErrorPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
		}

		private void OnContinueButtonClicked(object sender, EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new DashboardPage());
		}
	}
}