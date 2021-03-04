using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmAndSignSignaturePage : ContentPage
	{
		ConfirmAndSignSignaturePageViewModel viewModel;
		public ConfirmAndSignSignaturePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new ConfirmAndSignSignaturePageViewModel(this.Navigation);
		}
	}
}