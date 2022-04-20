using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.PreCheckIn
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerifyPreCheckInPasswordPage : ContentPage
	{
		VerifyPreCheckInPasswordPageViewModel viewModel;
		public VerifyPreCheckInPasswordPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VerifyPreCheckInPasswordPageViewModel(this.Navigation);
		}
	}
}