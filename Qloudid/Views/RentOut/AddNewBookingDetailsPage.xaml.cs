using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Collections.Generic;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewBookingDetailsPage : ContentPage
    {
        AddNewBookingDetailsPageViewModel viewModel;
        public AddNewBookingDetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddNewBookingDetailsPageViewModel(this.Navigation);
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
                var assembly = typeof(AddNewBookingDetailsPage).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
                using (var reader = new StreamReader(stream))
                    Helper.Helper.CountryList = JsonConvert.DeserializeObject<List<Models.Country>>(reader.ReadToEnd());
            }
        }

        private void OnCustomPickerSelectedIndexChanged(object sender, System.EventArgs e)
        {
            Controls.CustomPicker picker = sender as Controls.CustomPicker;
            if (picker.SelectedIndex == -1)
                return;
            else
            {
                if (viewModel != null)
                    viewModel.Paid = picker.SelectedIndex + 1;
            }
        }
    }
}