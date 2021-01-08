using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerifyExistingMobileNumberPage : ContentPage
	{
		VerifyExistingMobileNumberViewModel viewModel;
		public VerifyExistingMobileNumberPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VerifyExistingMobileNumberViewModel(this.Navigation);
		}
	}
}