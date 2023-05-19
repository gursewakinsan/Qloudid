using Newtonsoft.Json;
using Qloudid.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views.Property
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLandlordPage : ContentPage
    {
        AddLandlordPageViewModel viewModel;
        public AddLandlordPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            GetCountries();
            BindingContext = viewModel = new AddLandlordPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.UserPropertyCommand.Execute(null);
        }

        #region Get Countries.
        public void GetCountries()
        {
            if (Helper.Helper.CountryList == null)
            {
                string jsonFileName = "CountryJson.json";
                var assembly = typeof(AddLandlordPage).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
                using (var reader = new StreamReader(stream))
                    Helper.Helper.CountryList = JsonConvert.DeserializeObject<List<Models.Country>>(reader.ReadToEnd());
            }
        }
        #endregion
    }
}