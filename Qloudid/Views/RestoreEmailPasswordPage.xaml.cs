using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestoreEmailPasswordPage : ContentPage
	{
		RestoreEmailPasswordPageViewModel viewModel;
		public RestoreEmailPasswordPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new RestoreEmailPasswordPageViewModel(this.Navigation);
		}
	}
}