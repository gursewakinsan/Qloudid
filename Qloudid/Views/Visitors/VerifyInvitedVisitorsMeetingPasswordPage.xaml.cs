using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Visitors
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerifyInvitedVisitorsMeetingPasswordPage : ContentPage
	{
		VerifyInvitedVisitorsMeetingPasswordPageViewModel viewModel;
		public VerifyInvitedVisitorsMeetingPasswordPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VerifyInvitedVisitorsMeetingPasswordPageViewModel(this.Navigation);
		}

		private void OnCloseButtonClicked(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new DashboardPage());
		}
	}
}