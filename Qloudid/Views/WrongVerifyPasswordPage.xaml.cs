using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WrongVerifyPasswordPage : ContentPage
	{
		WrongVerifyPasswordViewModel viewModel;
		public WrongVerifyPasswordPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WrongVerifyPasswordViewModel(this.Navigation);
		}

		protected override void OnDisappearing()
		{
			viewModel.UpdateLoginStatusCommand.Execute(null);
			base.OnDisappearing();
		}

		private async void OnBackButtonClicked(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}