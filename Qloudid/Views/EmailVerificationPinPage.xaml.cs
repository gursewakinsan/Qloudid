using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmailVerificationPinPage : ContentPage
	{
		EmailVerificationPinPageViewModel viewModel;
		public EmailVerificationPinPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new EmailVerificationPinPageViewModel(this.Navigation);
		}
	}
}