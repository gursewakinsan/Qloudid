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

        void OnEmailRemoveClicked(System.Object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            viewModel.ListOfContactEmailAddress.Remove(button.BindingContext as Models.ContactEmailDetail);
        }

        void OnPhoneRemoveClicked(System.Object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            viewModel.ListOfContactPhoneNumber.Remove(button.BindingContext as Models.ContactPhoneNumberDetail);
        }

        void OnAddressRemoveClicked(System.Object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            viewModel.ListOfContactAddressNumber.Remove(button.BindingContext as Models.ContactAddressDetail);
        }

        void OnCardRemoveClicked(System.Object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            viewModel.ListOfContactCard.Remove(button.BindingContext as Models.ContactCardDetail);
        }
    }
}
