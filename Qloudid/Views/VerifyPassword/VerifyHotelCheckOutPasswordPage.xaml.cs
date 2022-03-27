using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.VerifyPassword
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerifyHotelCheckOutPasswordPage : ContentPage
	{
		VerifyHotelCheckOutPasswordPageViewModel viewModel;
		public VerifyHotelCheckOutPasswordPage(int hotelCheckOutId)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VerifyHotelCheckOutPasswordPageViewModel(this.Navigation);
			viewModel.HotelCheckOutId = hotelCheckOutId;
		}

		private void OnCloseButtonClicked(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new DashboardPage());
		}
	}
}