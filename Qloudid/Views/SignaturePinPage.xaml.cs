using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignaturePinPage : ContentPage
	{
		SignaturePinPageViewModel viewModel;
		public SignaturePinPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SignaturePinPageViewModel(this.Navigation);
		}
	}
}