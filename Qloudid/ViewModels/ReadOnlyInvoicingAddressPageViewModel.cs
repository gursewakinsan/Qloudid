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

			#region For Delivery Address.
			if (Helper.Helper.UserOrCompanyAddress == 0)
			{
				//Company Address
				IsVisibleUserName = true;
				DeliveryAddressBoxHeightRequest = 140;
				if (Device.RuntimePlatform == Device.iOS)
					CustomFloatingLabelEntryHeightRequest = 120;
				else
					CustomFloatingLabelEntryHeightRequest = 140;
			}
			else
			{
				//User Address
				IsVisibleUserName = false;
				DeliveryAddressBoxHeightRequest = 120;
				if (Device.RuntimePlatform == Device.iOS)
					CustomFloatingLabelEntryHeightRequest = 100;
				else
					CustomFloatingLabelEntryHeightRequest = 120;
			}
			#endregion

			#region For Invoicing Address.
			if (Helper.Helper.UserOrCompanyAddressForInvoicing == 1)
			{
				//Company Address For Invoicing
				IsVisibleUserName_InInvoiceAddress = true;
				DeliveryAddressBoxHeightRequest_InInvoiceAddress = 140;
				if (Device.RuntimePlatform == Device.iOS)
					CustomFloatingLabelEntryHeightRequest_InInvoiceAddress = 120;
				else
					CustomFloatingLabelEntryHeightRequest_InInvoiceAddress = 140;
			}
			else
			{
				//User Address For Invoicing
				IsVisibleUserName_InInvoiceAddress = false;
				DeliveryAddressBoxHeightRequest_InInvoiceAddress = 120;
				if (Device.RuntimePlatform == Device.iOS)
					CustomFloatingLabelEntryHeightRequest_InInvoiceAddress = 100;
				else
					CustomFloatingLabelEntryHeightRequest_InInvoiceAddress = 120;
			}
			#endregion

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
			{
				Helper.Helper.QloudidPayButtonText = "Delivery Address";
				Application.Current.MainPage = new NavigationPage(new Views.Pickup.PickUpAddressListPage());
			}
			else
			{
				if (Helper.Helper.IsPickupAddressAvailable)
					Helper.Helper.QloudidPayButtonText = "Pickup Address";
				else
					Helper.Helper.QloudidPayButtonText = "Qloud ID Pay";
				Application.Current.MainPage = new NavigationPage(new Views.AddressesListPage());
			}
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

		private double deliveryAddressBoxHeightRequest;
		public double DeliveryAddressBoxHeightRequest
		{
			get => deliveryAddressBoxHeightRequest;
			set
			{
				deliveryAddressBoxHeightRequest = value;
				OnPropertyChanged("DeliveryAddressBoxHeightRequest");
			}
		}

		private double customFloatingLabelEntryHeightRequest;
		public double CustomFloatingLabelEntryHeightRequest
		{
			get => customFloatingLabelEntryHeightRequest;
			set
			{
				customFloatingLabelEntryHeightRequest = value;
				OnPropertyChanged("CustomFloatingLabelEntryHeightRequest");
			}
		}

		private bool isVisibleUserName;
		public bool IsVisibleUserName
		{
			get => isVisibleUserName;
			set
			{
				isVisibleUserName = value;
				OnPropertyChanged("IsVisibleUserName");
			}
		}

		private double deliveryAddressBoxHeightRequest_InInvoiceAddress;
		public double DeliveryAddressBoxHeightRequest_InInvoiceAddress
		{
			get => deliveryAddressBoxHeightRequest_InInvoiceAddress;
			set
			{
				deliveryAddressBoxHeightRequest_InInvoiceAddress = value;
				OnPropertyChanged("DeliveryAddressBoxHeightRequest_InInvoiceAddress");
			}
		}

		private double customFloatingLabelEntryHeightRequest_InInvoiceAddress;
		public double CustomFloatingLabelEntryHeightRequest_InInvoiceAddress
		{
			get => customFloatingLabelEntryHeightRequest_InInvoiceAddress;
			set
			{
				customFloatingLabelEntryHeightRequest_InInvoiceAddress = value;
				OnPropertyChanged("CustomFloatingLabelEntryHeightRequest_InInvoiceAddress");
			}
		}

		private bool isVisibleUserName_InInvoiceAddress;
		public bool IsVisibleUserName_InInvoiceAddress
		{
			get => isVisibleUserName_InInvoiceAddress;
			set
			{
				isVisibleUserName_InInvoiceAddress = value;
				OnPropertyChanged("IsVisibleUserName_InInvoiceAddress");
			}
		}

		public Models.User UserInfo => Helper.Helper.UserInfo;
		public Models.PurchaseDetailResponse PurchaseDetail => Helper.Helper.PurchaseDetail;
		#endregion
	}
}

