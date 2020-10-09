using System;
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
		private async void OnScanQrCodeClicked(object sender, EventArgs e)
		{
			var customOverlay = new StackLayout
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			var back = new ImageButton
			{
				BackgroundColor = Color.FromHex("#F9F9F9"),
				Source= "iconBack.png", Padding=10,
				HeightRequest=50, WidthRequest=50,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			back.Clicked += OnBackClicked;
			customOverlay.Children.Add(back);

			this.scanPage = new ZXingScannerPage(customOverlay: customOverlay);
			scanPage.OnScanResult += (result) => {
				scanPage.IsScanning = false;
				Device.BeginInvokeOnMainThread(async () => {
					await Navigation.PopModalAsync();
					//await DisplayAlert("Scanned Barcode", result.Text + " , " + result.BarcodeFormat + " ," + result.ResultPoints[0].ToString(), "OK");
					viewModel.ValidateQrCodeCommand.Execute(result.Text);
				});
			};
			await Navigation.PushModalAsync(scanPage);
		}

		private void OnBackClicked(object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				this.scanPage.IsScanning = false;
				await Navigation.PopModalAsync();
			});
		}
	}
}