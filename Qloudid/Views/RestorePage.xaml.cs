using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestorePage : ContentPage
	{
		RestorePageViewModel viewModel;
		public RestorePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new RestorePageViewModel(this.Navigation);
		}
	}
}