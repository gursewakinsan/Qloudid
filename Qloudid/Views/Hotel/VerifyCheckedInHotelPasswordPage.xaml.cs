using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerifyCheckedInHotelPasswordPage : ContentPage
	{
		VerifyCheckedInHotelPasswordPageViewModel viewModel;
		public VerifyCheckedInHotelPasswordPage(int checkedInHotelId)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VerifyCheckedInHotelPasswordPageViewModel(this.Navigation);
			viewModel.CheckedInHotelId = checkedInHotelId;
		}

		private void OnCloseButtonClicked(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new DashboardPage());
		}
	}
}