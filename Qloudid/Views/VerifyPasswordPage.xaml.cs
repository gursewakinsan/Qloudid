using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerifyPasswordPage : ContentPage
	{
		VerifyPasswordPageViewModel viewModel;
		public VerifyPasswordPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VerifyPasswordPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			Helper.Helper.IsBack = true;
			Helper.Helper.IpFromURL = string.Empty;
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			if (Helper.Helper.IsBack)
				viewModel.ClearIpsCommand.Execute(null);
			base.OnDisappearing();
		}
	}
}