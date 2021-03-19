using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class ReadOnlyInvoicingAddressPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ReadOnlyInvoicingAddressPageViewModel(INavigation navigation)
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
			await Navigation.PushAsync(new Views.FinalStepToPayPage());
		}
		#endregion

		#region Edit Delivery Address Command.
		private ICommand editDeliveryAddressCommand;
		public ICommand EditDeliveryAddressCommand
		{
			get => editDeliveryAddressCommand ?? (editDeliveryAddressCommand = new Command(async () => await ExecuteEditDeliveryAddressCommand()));
		}
		private async Task ExecuteEditDeliveryAddressCommand()
		{
			Helper.Helper.IsEditDeliveryAddressFromInvoicing = true;
			Application.Current.MainPage = new NavigationPage(new Views.AddressesListPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Edit Invoicing Address Command.
		private ICommand editInvoicingAddressCommand;
		public ICommand EditInvoicingAddressCommand
		{
			get => editInvoicingAddressCommand ?? (editInvoicingAddressCommand = new Command(async () => await ExecuteEditInvoicingAddressCommand()));
		}
		private async Task ExecuteEditInvoicingAddressCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.WhoIsPayingPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public Models.InvoiceAddressResponse DisplayInvoiceAddress => Helper.Helper.InvoiceAddressDetail;
		public Models.DeliveryAddressDetailResponse DisplayDeliveryAddress => Helper.Helper.DeliveryAddressDetail;
		#endregion
	}
}

