using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IdentificatorPage : ContentPage
	{
		IdentificatorPageViewModel viewModel;
		public IdentificatorPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new IdentificatorPageViewModel(this.Navigation);
		}

		private void PickerSelectedIndexChanged(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				viewModel.SelectedIdentificator = picker.SelectedItem as Models.Identificator;
				switch (viewModel.SelectedIdentificator.Id)
				{
					case 0:
						viewModel.IsShowIdentificator = false;
						break;
					case 1:
						viewModel.IsShowIdentificator = true;
						txtIdentificator.Placeholder = "ID number";
						break;
					case 2:
						viewModel.IsShowIdentificator = true;
						txtIdentificator.Placeholder = "Driver license number";
						break;
					case 3:
						viewModel.IsShowIdentificator = true;
						txtIdentificator.Placeholder = "Passport number";
						break;
				}
			}
		}
	}
}