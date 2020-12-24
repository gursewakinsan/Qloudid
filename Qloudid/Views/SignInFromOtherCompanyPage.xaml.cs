using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;


namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInFromOtherCompanyPage : ContentPage
	{
		SignInFromOtherCompanyViewModel viewModel;
		public SignInFromOtherCompanyPage(string signInText)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SignInFromOtherCompanyViewModel(this.Navigation);
			BindSignInText(signInText);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.VerifyUserConsentCommand.Execute(null);
		}
		
		void BindSignInText(string signInText)
		{
			switch (signInText)
			{
				case "login":
					txtSignIn.Text = "I want to login";
					break;
				case "purchase":
					txtSignIn.Text = "I want to register delivery address";
					break;
				case "signin":
					txtSignIn.Text = "I want to sign in";
					break;
				case "apply":
					txtSignIn.Text = "I want to apply for job";
					break;
			}
		}
	}
}