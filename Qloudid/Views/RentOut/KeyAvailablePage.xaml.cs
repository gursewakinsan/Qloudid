using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KeyAvailablePage : ContentPage
    {
        KeyAvailablePageViewModel viewModel;
        public KeyAvailablePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new KeyAvailablePageViewModel(this.Navigation);
        }

        private void OnCustomPickerSelectedIndexChanged(object sender, System.EventArgs e)
        {
            Controls.CustomPicker picker = sender as Controls.CustomPicker;
            if (picker.SelectedIndex == -1)
                return;
            else
            {
                if (viewModel != null)
                    viewModel.Address.TotalKeys = picker.SelectedIndex;
            }
        }
    }
}
