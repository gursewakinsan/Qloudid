using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestorePage : ContentPage
	{
		RestorePageViewModel viewModel;
		public RestorePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new RestorePageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			//Helper.Helper.GetCountries();
			GetCountries();
			if (Helper.Helper.IsFirstTime)
			{
				Helper.Helper.IsFirstTime = false;
				viewModel.IsAlreadyLoginCommand.Execute(null);
			}
		}

		public void GetCountries()
		{
			if (Helper.Helper.CountryList == null)
			{
				string jsonFileName = "CountryJson.json";
				var assembly = typeof(RestorePage).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
				using (var reader = new StreamReader(stream))
					Helper.Helper.CountryList = JsonConvert.DeserializeObject<List<Models.Country>>(reader.ReadToEnd());
			}
		}
	}
}