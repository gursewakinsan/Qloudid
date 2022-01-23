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
			if (Helper.Helper.IsPickupAddress)
				DisplayPickupAddressDetail = Helper.Helper.SelectedPickupAddress;
			else
				DisplayDeliveryAddress = Helper.Helper.DeliveryAddressDetail;
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
			if (Helper.Helper.IsPickupAddress)
				Application.Current.MainPage = new NavigationPage(new Views.Pickup.PickUpAddressListPage());
			else
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

		private Models.DeliveryAddressDetailResponse displayDeliveryAddress;
		public Models.DeliveryAddressDetailResponse DisplayDeliveryAddress
		{
			get => displayDeliveryAddress;
			set
			{
				displayDeliveryAddress = value;
				OnPropertyChanged("DisplayDeliveryAddress");
			}
		}

		private Models.PickupAddressDetailResponse displayPickupAddressDetail;
		public Models.PickupAddressDetailResponse DisplayPickupAddressDetail
		{
			get => displayPickupAddressDetail;
			set
			{
				displayPickupAddressDetail = value;
				OnPropertyChanged("DisplayPickupAddressDetail");
			}
		}

		private bool isVisibleDeliveryAddress = !Helper.Helper.IsPickupAddress;
		public bool IsVisibleDeliveryAddress
		{
			get => isVisibleDeliveryAddress;
			set
			{
				isVisibleDeliveryAddress = value;
				OnPropertyChanged("IsVisibleDeliveryAddress");
			}
		}

		private bool isVisiblePickupAddress = Helper.Helper.IsPickupAddress;
		public bool IsVisiblePickupAddress
		{
			get => isVisiblePickupAddress;
			set
			{
				isVisiblePickupAddress = value;
				OnPropertyChanged("IsVisiblePickupAddress");
			}
		}

		public Models.PurchaseDetailResponse PurchaseDetail => Helper.Helper.PurchaseDetail;
		#endregion
	}
}

