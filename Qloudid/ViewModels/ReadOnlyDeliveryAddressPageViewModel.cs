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
		#endregion
	}
}
