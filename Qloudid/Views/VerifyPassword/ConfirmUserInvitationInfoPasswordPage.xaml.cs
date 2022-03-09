using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.VerifyPassword
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmUserInvitationInfoPasswordPage : ContentPage
	{
		ConfirmUserInvitationInfoPasswordPageViewModel viewModel;
		public ConfirmUserInvitationInfoPasswordPage(string confirmUserInvitationCode)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new ConfirmUserInvitationInfoPasswordPageViewModel(this.Navigation);
			viewModel.ConfirmUserInvitationCode = confirmUserInvitationCode;
		}

		private void OnCloseButtonClicked(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new DashboardPage());
		}
	}
}