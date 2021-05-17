using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Collections.Generic;

namespace Qloudid.Views.Info
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WantToCompleteCheckInInfoPage : ContentPage
	{
		WantToCompleteCheckInInfoPageViewModel viewModel;
		public WantToCompleteCheckInInfoPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WantToCompleteCheckInInfoPageViewModel(this.Navigation);
			GetCountries();
		}

		public void GetCountries()
		{
			if (Helper.Helper.CountryList == null)
			{
				string jsonFileName = "CountryJson.json";
				var assembly = typeof(WantToCompletePayInfoMsgPage).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
				using (var reader = new StreamReader(stream))
					Helper.Helper.CountryList = JsonConvert.DeserializeObject<List<Models.Country>>(reader.ReadToEnd());
			}
		}
	}
}