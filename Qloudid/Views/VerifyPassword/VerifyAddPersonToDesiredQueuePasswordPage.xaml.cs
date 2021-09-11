using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Collections.Generic;

namespace Qloudid.Views.VerifyPassword
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerifyAddPersonToDesiredQueuePasswordPage : ContentPage
	{
		VerifyAddPersonToDesiredQueuePasswordViewModel viewModel;
		public VerifyAddPersonToDesiredQueuePasswordPage(int id)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VerifyAddPersonToDesiredQueuePasswordViewModel(this.Navigation);
			viewModel.AddPersonToDesiredQueueId = id;
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
				var assembly = typeof(VerifyAddPersonToDesiredQueuePasswordPage).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
				using (var reader = new StreamReader(stream))
					Helper.Helper.CountryList = JsonConvert.DeserializeObject<List<Models.Country>>(reader.ReadToEnd());
			}
		}

		private void OnCloseButtonClicked(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new DashboardPage());
		}
	}
}