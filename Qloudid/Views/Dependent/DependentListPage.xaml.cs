using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Collections.Generic;

namespace Qloudid.Views.Dependent
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DependentListPage : ContentPage
	{
		DependentListPageViewModel viewModel;
		public DependentListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new DependentListPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			GetCountries();
			viewModel.GetAllDependentCommand.Execute(null);
		}

		private void OnDependentItemTapped(object sender, ItemTappedEventArgs e)
		{
			listDependent.SelectedItem = null;
		}

		public void GetCountries()
		{
			if (Helper.Helper.CountryList == null)
			{
				string jsonFileName = "CountryJson.json";
				var assembly = typeof(DependentListPage).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
				using (var reader = new StreamReader(stream))
					Helper.Helper.CountryList = JsonConvert.DeserializeObject<List<Models.Country>>(reader.ReadToEnd());
			}
		}
	}
}