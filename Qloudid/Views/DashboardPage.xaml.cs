using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using ZXing.Net.Mobile.Forms;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DashboardPage : ContentPage
	{
		DashboardPageViewModel viewModel;
		ZXingScannerPage scanPage;
		public DashboardPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new DashboardPageViewModel(this.Navigation);
		}
		private async void OnLoginToDesktopClicked(object sender, System.EventArgs e)
		{
			scanPage = new ZXingScannerPage();
			scanPage.OnScanResult += (result) => {
				scanPage.IsScanning = false;
				Device.BeginInvokeOnMainThread(async () => {
					await Navigation.PopModalAsync();
					viewModel.LoginToDesktopCommand.Execute(result.Text);
				});
			};
			scanPage.IsScanning = true;
			await Navigation.PushModalAsync(scanPage);
		}
	}
}