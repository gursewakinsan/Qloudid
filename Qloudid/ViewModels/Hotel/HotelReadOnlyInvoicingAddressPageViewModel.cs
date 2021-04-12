using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class HotelReadOnlyInvoicingAddressPageViewModel : BaseViewModel
	{
		#region Constructor.
		public HotelReadOnlyInvoicingAddressPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Selected Invoicing Address Command.
		private ICommand selectedInvoicingAddressCommand;
		public ICommand SelectedInvoicingAddressCommand
		{
			get => selectedInvoicingAddressCommand ?? (selectedInvoicingAddressCommand = new Command(async () => await ExecuteSelectedInvoicingAddressCommand()));
		}
		private async Task ExecuteSelectedInvoicingAddressCommand()
		{
			await Navigation.PushAsync(new Views.Hotel.HotelCardListToPayPage());
		}
		#endregion

		#region Properties.
		public Models.InvoiceAddressResponse DisplayInvoiceAddress => Helper.Helper.InvoiceAddressDetail;
		#endregion
	}
}
