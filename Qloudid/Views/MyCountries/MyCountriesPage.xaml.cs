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
            if (txtMobileNumber.Text?.Length > 0)
            {
                lblPhone.Color = Color.FromHex("#DB4437");
                sfLayout.UnfocusedColor = Color.FromHex("#DB4437");
            }
            else
            {
                lblPhone.Color = Color.FromHex("#797A7D");
                sfLayout.UnfocusedColor = Color.FromHex("#797A7D");
            }

            if (!string.IsNullOrWhiteSpace(args.NewTextValue))
            {
                bool isValid = args.NewTextValue.ToCharArray().All(char.IsDigit);
                ((Controls.CustomFloatingLabelEntry)sender).Text = isValid ? args.NewTextValue : args.OldTextValue;
            }
        }
    }
}