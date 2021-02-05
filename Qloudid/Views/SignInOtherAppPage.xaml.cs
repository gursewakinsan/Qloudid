using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInOtherAppPage : ContentPage
	{
		SignInOtherAppPageViewModel viewModel;
		public SignInOtherAppPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SignInOtherAppPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			viewModel.CheckValidQrCommand.Execute(null);
			base.OnAppearing();
		}

		private void OnCloseButtonClicked(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new DashboardPage());
		}
	}
}