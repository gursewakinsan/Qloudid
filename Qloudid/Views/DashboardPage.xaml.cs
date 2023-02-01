using System;
using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using ZXing.Net.Mobile.Forms;
using System.Collections.Generic;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DashboardPage : ContentPage
	{
		DashboardPageViewModel viewModel;
		ZXingScannerPage scanPage;
		int carouselViewPosition = 0;
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
			
			if (Helper.Helper.IsFirstTime)
			{
				Helper.Helper.IsFirstTime = false;
				viewModel.IsAlreadyLoginCommand.Execute(null);
			}
			else
			{
				GetCountries();
				viewModel.GetUserImageCommand.Execute(null);
			}
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

			//string str = $"RDBUQzN3T25RU0dvQVM1NnAyV0IxZz09/OTJCN1UwUXVVZmhwbzh2WmhHdzVTMlFZS0Rjc3BIVEhrQ2MvY0hlYzJGMD0=/purchase/1"; //$"bGw3UUxkaXF3bm1EK3hjdFZwOC9rQT09/YWZlN2t1ZmF5bmh6VHVhdnlZSHFCZz09/hotel/1/bmdtL1V1S0I0M3ZIdkJPS1lSRU1Kdz09";
			//viewModel.LoginToDesktopCommand.Execute(str);
		}
		private void OnBackClicked(object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				this.scanPage.IsScanning = false;
				await Navigation.PopModalAsync();
			});
		}

		/*private void OnCarouselViewPositionChanged(object sender, PositionChangedEventArgs e)
		{
			carouselViewPosition = e.CurrentPosition;
			string color = viewModel.DashboardItemList[carouselViewPosition].IconColor;
			indicatorView.SelectedIndicatorColor = Color.FromHex(color);
			btnLearnMore.TextColor = Color.FromHex(color);
		}*/

		private void OnLearnMoreButtonClicked(object sender, EventArgs e)
		{
			OnTapped(carouselViewPosition);
		}

		private void OnGestureRecognizerTapped(object sender, EventArgs e)
		{
			StackLayout control = sender as StackLayout;
			OnTapped(Convert.ToInt32(control.ClassId));
		}

		private void GridOnGestureRecognizerTapped(object sender, EventArgs e)
		{
			Grid control = sender as Grid;
			OnTapped(Convert.ToInt32(control.ClassId));
		}

		private void LabelOnGestureRecognizerTapped(object sender, EventArgs e)
        {
            Label control = sender as Label;
			OnTapped(Convert.ToInt32(control.ClassId));
        }

		private void ImageOnGestureRecognizerTapped(object sender, EventArgs e)
		{
			Image control = sender as Image;
			OnTapped(Convert.ToInt32(control.ClassId));
		}

		private void FrameOnGestureRecognizerTapped(object sender, EventArgs e)
		{
			Frame control = sender as Frame;
			OnTapped(Convert.ToInt32(control.ClassId));
		}

		private void OnTapped(int id)
		{
			if (id == 0)
				viewModel.PayCommand.Execute(null);
			else if (id == 1)
				viewModel.PassportCommand.Execute(null);
			else if (id == 2)
				viewModel.BookingCommand.Execute(null);
			else if (id == 3)
				viewModel.PreCheckInCommand.Execute(null);
			else if (id == 4)
				viewModel.ConsentCommand.Execute(null);
			else if (id == 5)
				viewModel.LandLoardConsentCommand.Execute(null);
			else if (id == 6)
				viewModel.ManageCardCommand.Execute(null);
		}
    }
}