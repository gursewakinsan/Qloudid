using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class ReadOnlyDeliveryAddressPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ReadOnlyDeliveryAddressPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
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

			if (Helper.Helper.IsPickupAddress)
				DisplayPickupAddressDetail = Helper.Helper.SelectedPickupAddress;
			else
				DisplayDeliveryAddress = Helper.Helper.DeliveryAddressDetail;
		}
		#endregion

		#region Selected Delivery Address Command.
		private ICommand selectedDeliveryAddressCommand;
		public ICommand SelectedDeliveryAddressCommand
		{
			get => selectedDeliveryAddressCommand ?? (selectedDeliveryAddressCommand = new Command(async () => await ExecuteSelectedDeliveryAddressCommand()));
		}
		private async Task ExecuteSelectedDeliveryAddressCommand()
		{
			await Navigation.PushAsync(new Views.WhoIsPayingPage());
		}
		#endregion

		#region Edit Address Command.
		private ICommand editAddressCommand;
		public ICommand EditAddressCommand
		{
			get => editAddressCommand ?? (editAddressCommand = new Command(async () => await ExecuteEditAddressCommand()));
		}
		private async Task ExecuteEditAddressCommand()
		{
			if (Helper.Helper.IsPickupAddress)
				await Navigation.PopAsync();
			else
				Application.Current.MainPage = new NavigationPage(new Views.AddressesListPage());
		}
		#endregion

		#region Properties.
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

		public Models.User UserInfo => Helper.Helper.UserInfo;
		public Models.PurchaseDetailResponse PurchaseDetail => Helper.Helper.PurchaseDetail;
		#endregion
	}
}
