using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IWantToPayVerifyPasswordPage : ContentPage
	{
		IWantToPayVerifyPasswordPageViewModel viewModel;
		public IWantToPayVerifyPasswordPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new IWantToPayVerifyPasswordPageViewModel(this.Navigation);
		}
	}
}