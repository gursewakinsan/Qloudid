using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HotelBookingDetailPage : ContentPage
	{
		HotelBookingDetailPageViewModel viewModel;
		public HotelBookingDetailPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new HotelBookingDetailPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.VerifyUserConsentCommand.Execute(null);
		}
	}
}