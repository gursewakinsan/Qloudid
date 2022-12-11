using System;
using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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

		#region Property Type Command.
		private ICommand propertyTypeCommand;
		public ICommand PropertyTypeCommand
		{
			get => propertyTypeCommand ?? (propertyTypeCommand = new Command(async () => await ExecutePropertyTypeCommand()));
		}
		private async Task ExecutePropertyTypeCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			var responsesPropertyTypeInfo = await service.PropertyTypeAsync();
			PropertyTypeInfo = new ObservableCollection<Models.PropertyTypeResponse>(responsesPropertyTypeInfo);
			SelectedPropertyType = PropertyTypeInfo.FirstOrDefault(x => x.Id == UserAddress.PropertyType);

			var responsesFloorsInfo = await service.FloorsInfoAsync(new Models.FloorsInfoRequest()
			{
				ApartmentId = SelectedApartment.Id
			});
			FloorsApartmentInfo = new ObservableCollection<Models.FloorsInfoResponse>(responsesFloorsInfo);
			SelectedFloorsApartmentInfo = FloorsApartmentInfo.FirstOrDefault(x => x.Id == UserAddress.ApartmentFloor);

			FloorsEntranceInfo = new ObservableCollection<Models.FloorsInfoResponse>(responsesFloorsInfo);
			SelectedFloorsEntranceInfo = FloorsEntranceInfo.FirstOrDefault(x => x.Id == UserAddress.EntranceFloor);
			DependencyService.Get<IProgressBar>().Hide();
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

		#region Update Property Composition Command.
		private ICommand updatePropertyCompositionCommand;
		public ICommand UpdatePropertyCompositionCommand
		{
			get => updatePropertyCompositionCommand ?? (updatePropertyCompositionCommand = new Command(async () => await ExecuteUpdatePropertyCompositionCommand()));
		}
		private async Task ExecuteUpdatePropertyCompositionCommand()
		{
			if (string.IsNullOrWhiteSpace(UserAddress.PropertyLayout))
				await Helper.Alert.DisplayAlert("Property layout is required.");
			else if (string.IsNullOrWhiteSpace(UserAddress.FloorsAvailable))
				await Helper.Alert.DisplayAlert("Available floors  is required.");
			else
            {
				DependencyService.Get<IProgressBar>().Show();
				IBedroomService service = new BedroomService();
				await service.UpdatePropertyCompositionAsync(new Models.UpdatePropertyCompositionRequest()
				{
					PropertyType = SelectedPropertyType.Id,
					PropertyLayout = Convert.ToInt32(UserAddress.PropertyLayout),
					FloorsAvailable = Convert.ToInt32(UserAddress.FloorsAvailable),
					ApartmentFloor = SelectedFloorsApartmentInfo.Id,
					EntranceFloor = SelectedFloorsEntranceInfo.Id,
					PrivateEntrance = UserAddress.PrivateEntrance ? 1 : 0,
					Elevator = UserAddress.Elevator ? 1 : 0,
					ApartmentId = UserAddress.Id
				});
				Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
				await Navigation.PopAsync();
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.PropertyTypeResponse> propertyTypeInfo;
		public ObservableCollection<Models.PropertyTypeResponse> PropertyTypeInfo
		{
			get => propertyTypeInfo;
			set
			{
				propertyTypeInfo = value;
				OnPropertyChanged("PropertyTypeInfo");
			}
		}

		private Models.PropertyTypeResponse selectedPropertyType;
		public Models.PropertyTypeResponse SelectedPropertyType
		{
			get => selectedPropertyType;
			set
			{
				selectedPropertyType = value;
				OnPropertyChanged("SelectedPropertyType");
			}
		}

		private ObservableCollection<Models.FloorsInfoResponse> floorsApartmentInfo;
		public ObservableCollection<Models.FloorsInfoResponse> FloorsApartmentInfo
		{
			get => floorsApartmentInfo;
			set
			{
				floorsApartmentInfo = value;
				OnPropertyChanged("FloorsApartmentInfo");
			}
		}

		private Models.FloorsInfoResponse selectedFloorsApartmentInfo;
		public Models.FloorsInfoResponse SelectedFloorsApartmentInfo
		{
			get => selectedFloorsApartmentInfo;
			set
			{
				selectedFloorsApartmentInfo = value;
				OnPropertyChanged("SelectedFloorsApartmentInfo");
			}
		}

		private ObservableCollection<Models.FloorsInfoResponse> floorsEntranceInfo;
		public ObservableCollection<Models.FloorsInfoResponse> FloorsEntranceInfo
		{
			get => floorsEntranceInfo;
			set
			{
				floorsEntranceInfo = value;
				OnPropertyChanged("FloorsEntranceInfo");
			}
		}

		private Models.FloorsInfoResponse selectedFloorsEntranceInfo;
		public Models.FloorsInfoResponse SelectedFloorsEntranceInfo
		{
			get => selectedFloorsEntranceInfo;
			set
			{
				selectedFloorsEntranceInfo = value;
				OnPropertyChanged("SelectedFloorsEntranceInfo");
			}
		}

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
