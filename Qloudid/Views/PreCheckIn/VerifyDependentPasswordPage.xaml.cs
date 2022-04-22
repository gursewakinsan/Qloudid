using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.PreCheckIn
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerifyDependentPasswordPage : ContentPage
	{
		VerifyDependentPasswordPageViewModel viewModel;
		public VerifyDependentPasswordPage(Models.VerifyPreCheckInDependentRequest dependentRequest)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VerifyDependentPasswordPageViewModel(this.Navigation);
			viewModel.VerifyPreCheckInDependentInfo = dependentRequest;
		}
	}
}