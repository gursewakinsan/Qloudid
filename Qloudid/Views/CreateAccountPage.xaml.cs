using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateAccountPage : ContentPage
	{
		CreateAccountPageViewModel viewModel;
		public CreateAccountPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CreateAccountPageViewModel(this.Navigation);
		}

		private void PickerSelectedIndexChanged(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				Models.Country country = picker.SelectedItem as Models.Country;
				viewModel.CountryId = country.Id;
			}
		}

		private void OnButtonCloseClicked(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new RestorePage());
		}
	}
}