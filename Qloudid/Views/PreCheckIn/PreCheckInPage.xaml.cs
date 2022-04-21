using System;
using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using ZXing.Net.Mobile.Forms;
using System.Collections.Generic;

namespace Qloudid.Views.PreCheckIn
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PreCheckInPage : ContentPage
	{
		PreCheckInPageViewModel viewModel;
		public PreCheckInPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new PreCheckInPageViewModel(this.Navigation);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			GetCountries();
		}

        public void GetCountries()
		{
			if (Helper.Helper.CountryList == null)
			{
				string jsonFileName = "CountryJson.json";
				var assembly = typeof(PreCheckInPage).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
				using (var reader = new StreamReader(stream))
					Helper.Helper.CountryList = JsonConvert.DeserializeObject<List<Models.Country>>(reader.ReadToEnd());
			}
		}
	}
}