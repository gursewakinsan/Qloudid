using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WrongPasswordPage : ContentPage
	{
		public WrongPasswordPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
		}

		protected override void OnDisappearing()
		{
			Helper.Helper.IsBack = true;
			base.OnDisappearing();
		}

		private async void OnBackButtonClicked(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}