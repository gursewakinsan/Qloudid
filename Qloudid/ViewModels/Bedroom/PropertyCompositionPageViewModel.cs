using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class PropertyCompositionPageViewModel : BaseViewModel
    {
		#region Constructor.
		public PropertyCompositionPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			UserAddress = Helper.Helper.SelectedUserAddress;
			UserAddress.PrivateEntranceBg = UserAddress.PrivateEntrance ? Color.FromHex("#0F9D58") : Color.FromHex("#242A37");
			UserAddress.ElevatorBg = UserAddress.Elevator ? Color.FromHex("#0F9D58") : Color.FromHex("#242A37");
		}
		#endregion

		#region Private Entrance Door Command.
		private ICommand privateEntranceDoorCommand;
		public ICommand PrivateEntranceDoorCommand
		{
			get => privateEntranceDoorCommand ?? (privateEntranceDoorCommand = new Command(() => ExecutePrivateEntranceDoorCommand()));
		}
		private void ExecutePrivateEntranceDoorCommand()
		{
			UserAddress.PrivateEntrance = !UserAddress.PrivateEntrance;
			UserAddress.PrivateEntranceBg = UserAddress.PrivateEntrance ? Color.FromHex("#0F9D58") : Color.FromHex("#242A37");
		}
		#endregion

		#region Elevator Command.
		private ICommand elevatorCommand;
		public ICommand ElevatorCommand
		{
			get => elevatorCommand ?? (elevatorCommand = new Command(() => ExecuteElevatorCommand()));
		}
		private void ExecuteElevatorCommand()
		{
			UserAddress.Elevator = !UserAddress.Elevator;
			UserAddress.ElevatorBg = UserAddress.Elevator ? Color.FromHex("#0F9D58") : Color.FromHex("#242A37");
		}
		#endregion

		#region Properties.
		private Models.EditAddressResponse userAddress;
		public Models.EditAddressResponse UserAddress
		{
			get => userAddress;
			set
			{
				userAddress = value;
				OnPropertyChanged("UserAddress");
			}
		}

		private bool isPageLoad = false;
		public bool IsPageLoad
		{
			get => isPageLoad;
			set
			{
				isPageLoad = value;
				OnPropertyChanged("IsPageLoad");
			}
		}
		public Models.UserDeliveryAddressesResponse SelectedApartment => Helper.Helper.SelectedUserDeliveryAddress;

		#endregion
	}
}
