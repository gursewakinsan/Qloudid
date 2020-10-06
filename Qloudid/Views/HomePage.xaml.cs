using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using ZXing.Net.Mobile.Forms;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		HomePageViewModel viewModel;
		ZXingScannerPage scanPage;
		public HomePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new HomePageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (Helper.Helper.IsFirstTime)
			{
				Helper.Helper.IsFirstTime = false;
				viewModel.IsAlreadyLoginCommand.Execute(null);
			}
		}
		private async void OnScanQrCodeClicked(object sender, System.EventArgs e)
		{
			scanPage = new ZXingScannerPage();
			scanPage.OnScanResult += (result) => {
				scanPage.IsScanning = false;
				Device.BeginInvokeOnMainThread(async () => {
					await Navigation.PopModalAsync();
					//await DisplayAlert("Scanned Barcode", result.Text + " , " + result.BarcodeFormat + " ," + result.ResultPoints[0].ToString(), "OK");
					viewModel.ValidateQrCodeCommand.Execute(result.Text);
				});
			};
			scanPage.IsScanning = true;
			await Navigation.PushModalAsync(scanPage);
		}
	}
}