using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HotelReadOnlyInvoicingAddressPage : ContentPage
	{
		HotelReadOnlyInvoicingAddressPageViewModel viewModel;
		public HotelReadOnlyInvoicingAddressPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new HotelReadOnlyInvoicingAddressPageViewModel(this.Navigation);
		}
	}
}