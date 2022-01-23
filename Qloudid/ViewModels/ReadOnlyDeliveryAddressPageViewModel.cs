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
			Helper.Helper.IsPickupAddress = true;
			Helper.Helper.PurchaseDetail = new Models.PurchaseDetailResponse() { Price = "400" };
			Helper.Helper.DeliveryAddressDetail = new Models.DeliveryAddressDetailResponse()
			{
				Address = "Address",
				City = "City",
				CompanyName = "CompanyName",
				CountryName = "CountryName",
				EntryCode = "EntryCode",
				Id = 1,
				NameOnHouse = "NameOnHouse",
				PortNumber = "PortNumber",
				Zipcode = "Zipcode"
			};

			Helper.Helper.SelectedPickupAddress = new Models.PickupAddressDetailResponse()
			{
				Address = "Address",
				City = "City",
				CountryName = "CountryName",
				Id = 1,
				PortNumber = "PortNumber",
				Zipcode = "Zipcode",
				PickupAddressName = "PickupAddressName"
			};

			IsVisiblePickupAddress = true;
			IsVisibleDeliveryAddress = false;
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

		public Models.PurchaseDetailResponse PurchaseDetail => Helper.Helper.PurchaseDetail;
		#endregion
	}
}
