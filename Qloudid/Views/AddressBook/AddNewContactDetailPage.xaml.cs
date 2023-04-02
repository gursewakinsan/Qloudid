using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Collections.Generic;

namespace Qloudid.Views.AddressBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewContactDetailPage : ContentPage
    {
        AddNewContactDetailPageViewModel viewModel;
        public AddNewContactDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddNewContactDetailPageViewModel(this.Navigation);
            GetCountries();
        }

        public void GetCountries()
        {
            if (Helper.Helper.CountryList == null)
            {
                string jsonFileName = "CountryJson.json";
                var assembly = typeof(AddNewContactDetailPage).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
                using (var reader = new StreamReader(stream))
                    Helper.Helper.CountryList = JsonConvert.DeserializeObject<List<Models.Country>>(reader.ReadToEnd());
            }
        }

        async void OnEmailRemoveClicked(System.Object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            if (viewModel.ListOfContactEmailAddress.Count > 1)
                viewModel.ListOfContactEmailAddress.Remove(button.BindingContext as Models.ContactEmailDetail);
            else
                await Helper.Alert.DisplayAlert("Email information is required.");

        }

        async void OnPhoneRemoveClicked(System.Object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            if (viewModel.ListOfContactPhoneNumber.Count > 1)
                viewModel.ListOfContactPhoneNumber.Remove(button.BindingContext as Models.ContactPhoneNumberDetail);
            else
                await Helper.Alert.DisplayAlert("Phone information is required.");
        }

        async void OnAddressRemoveClicked(System.Object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            if (viewModel.ListOfContactAddressNumber.Count > 1)
                viewModel.ListOfContactAddressNumber.Remove(button.BindingContext as Models.ContactAddressDetail);
            else
                await Helper.Alert.DisplayAlert("Address information is required.");
        }

        async void OnCardRemoveClicked(System.Object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            if (viewModel.ListOfContactCard.Count > 1)
                viewModel.ListOfContactCard.Remove(button.BindingContext as Models.ContactCardDetail);
            else
                await Helper.Alert.DisplayAlert("Card information is required.");
        }
    }
}
