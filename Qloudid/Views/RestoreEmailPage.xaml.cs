using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestoreEmailPage : ContentPage
	{
		RestoreEmailPageViewModel viewModel;
		public RestoreEmailPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new RestoreEmailPageViewModel(this.Navigation);
		}
	}
}