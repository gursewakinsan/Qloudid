using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GenerateCertificatePage : ContentPage
	{
		GenerateCertificateViewModel viewModel;
		public GenerateCertificatePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new GenerateCertificateViewModel(this.Navigation);
		}
	}
}