using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
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

		protected override void OnAppearing()
		{
			//if (!string.IsNullOrWhiteSpace(Helper.Helper.IpFromURL))
			//	viewModel.LoginFromUrlIpCommand.Execute(null);
			
			/*if (Helper.Helper.IsFirstTime)
			{
				Helper.Helper.IsFirstTime = false;
				viewModel.IsAlreadyLoginCommand.Execute(null);
			}
			else
			{
				GetCountries();
				viewModel.GetUserImageCommand.Execute(null);
			}*/
			base.OnAppearing();
		}

		public void GetCountries()
		{
			if (Helper.Helper.CountryList ==null)
			{
				string jsonFileName = "CountryJson.json";
				var assembly = typeof(DashboardPage).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
				using (var reader = new StreamReader(stream))
					Helper.Helper.CountryList = JsonConvert.DeserializeObject<List<Models.Country>>(reader.ReadToEnd());
			}
		}

		private async void OnLoginToDesktopClicked(object sender, EventArgs e)
		{
			var customOverlay = new StackLayout
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			var back = new ImageButton
			{
				Margin = new Thickness(15, 20, 0, 0),
				BackgroundColor = Color.Transparent,
				Source = "iconBack.png",
				Padding = 10,
				HeightRequest = 50,
				WidthRequest = 50,
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
					viewModel.LoginToDesktopCommand.Execute(result.Text);
				});
			};
			scanPage.IsScanning = true;
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