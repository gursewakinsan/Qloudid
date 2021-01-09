using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WrongMobileOtpPinPage : ContentPage
	{
		WrongMobileOtpPinPageViewModel viewModel;
		public WrongMobileOtpPinPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WrongMobileOtpPinPageViewModel(this.Navigation);
		}
	}
}