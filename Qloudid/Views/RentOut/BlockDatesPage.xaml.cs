using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlockDatesPage : ContentPage
    {
        BlockDatesPageViewModel viewModel;
        public BlockDatesPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new BlockDatesPageViewModel(this.Navigation);
        }

        private void OnCustomPickerSelectedIndexChanged(object sender, System.EventArgs e)
        {
            Controls.CustomPicker picker = sender as Controls.CustomPicker;
            if (picker.SelectedIndex == -1)
                return;
            else
            {
                if (viewModel != null)
                    viewModel.PickerSelectedAction = picker.SelectedIndex;
            }
        }
    }
}