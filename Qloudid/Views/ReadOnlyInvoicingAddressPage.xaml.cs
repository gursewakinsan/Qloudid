using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReadOnlyInvoicingAddressPage : ContentPage
	{
		ReadOnlyInvoicingAddressPageViewModel viewModel;
		public ReadOnlyInvoicingAddressPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new ReadOnlyInvoicingAddressPageViewModel(this.Navigation);
		}
	}
}