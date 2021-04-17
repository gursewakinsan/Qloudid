using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HotelCheckInSuccessfullPage : ContentPage
	{
		public HotelCheckInSuccessfullPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
		}

		private void OnCloseButtonClicked(object sender, EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new DashboardPage());
		}
	}
}