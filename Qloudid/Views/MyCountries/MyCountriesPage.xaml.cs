using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.MyCountries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCountriesPage : ContentPage
    {
        MyCountriesPageViewModel viewModel;
        public MyCountriesPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new MyCountriesPageViewModel(this.Navigation);
        }

        private void MobileNumberTextChanged(object sender, TextChangedEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(args.NewTextValue))
            {
                bool isValid = args.NewTextValue.ToCharArray().All(char.IsDigit);
                ((Controls.CustomFloatingLabelEntry)sender).Text = isValid ? args.NewTextValue : args.OldTextValue;
            }
        }
    }
}