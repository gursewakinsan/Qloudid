﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InvalidQrCodePage : ContentPage
	{
		public InvalidQrCodePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
		}

		protected override void OnDisappearing()
		{
			if(!string.IsNullOrWhiteSpace(Helper.Helper.IpFromURL))
			{
				Helper.Helper.IpFromURL = string.Empty;
				Application.Current.MainPage = new NavigationPage(new RestorePage());
			}
			base.OnDisappearing();
		}

		private async void OnBackButtonClicked(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}