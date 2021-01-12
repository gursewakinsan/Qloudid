using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountNotAvailablePage : ContentPage
	{
		public AccountNotAvailablePage()
		{
			InitializeComponent();
		}

		private void OnBtnRestoreClicked(object sender, EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new RestoreEmailPage());
		}

		private void OnBtnCreateAccountClicked(object sender, EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new CreateAccountPage());
		}
	}
}