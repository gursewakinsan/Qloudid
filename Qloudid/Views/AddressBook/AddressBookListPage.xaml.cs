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
    public partial class AddressBookListPage : ContentPage
    {
        AddressBookListPageViewModel viewModel;
        public AddressBookListPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddressBookListPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetUserAddressBookContactsCommand.Execute(null);
            GetCountries();
        }

        public void GetCountries()
        {
            if (Helper.Helper.CountryList == null)
            {
                string jsonFileName = "CountryJson.json";
                var assembly = typeof(AddressBookListPage).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
                using (var reader = new StreamReader(stream))
                    Helper.Helper.CountryList = JsonConvert.DeserializeObject<List<Models.Country>>(reader.ReadToEnd());
            }
        }

        void OnImageButtonClicked(System.Object sender, System.EventArgs e)
        {
            ImageButton control = sender as ImageButton;
            OnItemClicked(control.BindingContext as Models.UserAddressBookContactsResponse);
        }

        void OnStackLayoutClicked(System.Object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            OnItemClicked(control.BindingContext as Models.UserAddressBookContactsResponse);
        }

        void OnLabelClicked(System.Object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnItemClicked(control.BindingContext as Models.UserAddressBookContactsResponse);
        }

        async void OnItemClicked(Models.UserAddressBookContactsResponse user)
        {
            await Navigation.PushAsync(new UserContactDetailsInfoPage(user));
        }
    }
}
