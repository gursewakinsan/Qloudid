using System.Timers;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class YourSignaturePageViewModel : BaseViewModel
	{
		#region Local Variable.
		Timer timer;
		int count = 0;
		#endregion

		#region Constructor.
		public YourSignaturePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			timer = new Timer();
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			timer.Interval = 60000;
			timer.Enabled = true;

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
				DeliveryAddress = Helper.Helper.DeliveryAddressDetail;
		}
		#endregion

		#region On Timed Event.
		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			DisplayTotalMinutes = $"{count = count + 1} ";
			timer.Start();
		}
		#endregion

		#region Confirm And Sign Command.
		private ICommand confirmAndSignCommand;
		public ICommand ConfirmAndSignCommand
		{
			get => confirmAndSignCommand ?? (confirmAndSignCommand = new Command(async () => await ExecuteConfirmAndSignCommand()));
		}
		private async Task ExecuteConfirmAndSignCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.ConfirmAndSignSignaturePage());
			await Task.CompletedTask;
		}
		#endregion

		#region Cancel Confirm And Sign Command.
		private ICommand cancelConfirmAndSignCommand;
		public ICommand CancelConfirmAndSignCommand
		{
			get => cancelConfirmAndSignCommand ?? (cancelConfirmAndSignCommand = new Command(async () => await ExecuteCancelConfirmAndSignCommand()));
		}
		private async Task ExecuteCancelConfirmAndSignCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			await Task.CompletedTask;
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
			Helper.Helper.IsEditAddressFromYourSignature = true;
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

		#region Edit Card Detail Command.
		private ICommand editCardDetailCommand;
		public ICommand EditCardDetailCommand
		{
			get => editCardDetailCommand ?? (editCardDetailCommand = new Command(async () => await ExecuteEditCardDetailCommand()));
		}
		private async Task ExecuteEditCardDetailCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.FinalStepToPayPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Bind Data.
		/*void BindData()
		{
			var dAddress = Helper.Helper.DeliveryAddressDetail;
			if (dAddress != null)
				DeliveryAddress = $"{dAddress.CompanyName}, {dAddress.NameOnHouse} {dAddress.Address} {dAddress.Zipcode} {dAddress.City}, {dAddress.CountryName}";

			var iAddress = Helper.Helper.InvoiceAddressDetail;
			if (iAddress != null)
				InvoiceAddress = $"{iAddress.NameOnHouse}, {iAddress.InvoiceAddress} {iAddress.InvoiceZip} {iAddress.InvoiceCity}, {iAddress.InvoiceCountry}";

			var cc = Helper.Helper.CardDetail;
			if (cc != null)
			{
				string space = string.Empty;
				CardDetail = $"Card {space.PadLeft(20)} **** **** ****  {cc.card_number2.GetLast(4)}";
			}
		}*/
		#endregion

		#region Properties.
		public Models.PurchaseDetailResponse PurchaseDetail => Helper.Helper.PurchaseDetail;
		//public Models.DeliveryAddressDetailResponse DeliveryAddress => Helper.Helper.DeliveryAddressDetail;
		public Models.InvoiceAddressResponse InvoiceAddress => Helper.Helper.InvoiceAddressDetail;
		public Models.CardDetailResponse CardDetail => Helper.Helper.CardDetail;

		private string displayTotalMinutes = "Less then ";
		public string DisplayTotalMinutes
		{
			get => displayTotalMinutes;
			set
			{
				displayTotalMinutes = value;
				OnPropertyChanged("DisplayTotalMinutes");
			}
		}

		private Models.DeliveryAddressDetailResponse deliveryAddress;
		public Models.DeliveryAddressDetailResponse DeliveryAddress
		{
			get => deliveryAddress;
			set
			{
				deliveryAddress = value;
				OnPropertyChanged("DeliveryAddress");
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
		#endregion
	}
}