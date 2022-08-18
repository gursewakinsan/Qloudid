using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Collections.Generic;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInFromWebPage : ContentPage
	{
		SignInFromWebPageViewModel viewModel;
		bool isFromThirdPartyUrl = false;
		public SignInFromWebPage(bool _isFromThirdPartyUrl)
		{
			isFromThirdPartyUrl = _isFromThirdPartyUrl;
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SignInFromWebPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (!isFromThirdPartyUrl)
			{
				viewModel.LoginFromUrlIpCommand.Execute(null);
				GetCountries();
			}
			else
				viewModel.LoginToDesktopCommand.Execute(Helper.Helper.IpFromURL);
		}

		public void GetCountries()
		{
			if (Helper.Helper.CountryList ==null)
			{
				string jsonFileName = "CountryJson.json";
				var assembly = typeof(SignInFromWebPage).GetTypeInfo().Assembly;
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