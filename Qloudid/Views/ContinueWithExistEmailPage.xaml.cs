using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContinueWithExistEmailPage : ContentPage
	{
		RestoreEmailPageViewModel viewModel;
		public ContinueWithExistEmailPage(string email)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new RestoreEmailPageViewModel(this.Navigation);
			viewModel.Email = email;
		}

		private void OnCloseButtonClicked(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new RestorePage());
		}
	}
}