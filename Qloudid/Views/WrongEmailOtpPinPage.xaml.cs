using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WrongEmailOtpPinPage : ContentPage
	{
		WrongEmailOtpPinPageViewModel viewModel;
		public WrongEmailOtpPinPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WrongEmailOtpPinPageViewModel(this.Navigation);
		}
	}
}