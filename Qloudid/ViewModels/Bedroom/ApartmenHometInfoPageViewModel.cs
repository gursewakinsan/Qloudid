using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class ApartmenHometInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ApartmenHometInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			UserDeliveryAddresses = Helper.Helper.SelectedUserDeliveryAddress;
		}
		#endregion

		#region Get Address By Id Command.
		private ICommand getAddressByIdCommand;
		public ICommand GetAddressByIdCommand
		{
			get => getAddressByIdCommand ?? (getAddressByIdCommand = new Command(async () => await ExecuteGetAddressByIdCommand()));
		}
		private async Task ExecuteGetAddressByIdCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			var response = await service.GetAddressByIdAsync(new Models.EditAddressRequest()
			{
				id = Helper.Helper.SelectedUserDeliveryAddress.Id
			});

			if (response.BedroomUpdated && response.BathroomUpdated && response.PropertyCompositionUpdated && response.OtherRoomUpdated)
			{
				IsWiFi = true;
			}
			else
			{
				IsFinishSetUp = true;
			}
			
            /*if (IsApartmentUpdated && response.IsWiFiUpdated)
				IsApartmentAndWifiUpdated = false;
			else if (!IsApartmentUpdated && !response.IsWiFiUpdated)
			{
				IsApartmentAndWifiUpdated = true;
				IsApartmentUpdated = true;
				ApartmentCardWidthRequest = WifiCardWidthRequest = 278;
			}
			else if (!IsApartmentUpdated)
			{
				IsApartmentAndWifiUpdated = true;
				IsApartmentUpdated = true;
				ApartmentCardWidthRequest = App.ScreenWidth - 55;
			}
			else if (!response.IsWiFiUpdated)
			{
				IsApartmentUpdated = false;
				IsApartmentAndWifiUpdated = true;
				WifiCardWidthRequest = App.ScreenWidth - 55;
			}*/
            Address = response;
            StayOrRentOutCommand.Execute("Stay");
            Helper.Helper.SelectedUserAddress = Address;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Manage Command.
		private ICommand manageCommand;
		public ICommand ManageCommand
		{
			get => manageCommand ?? (manageCommand = new Command(async () => await ExecuteManageCommand()));
		}
		private async Task ExecuteManageCommand()
		{
			if (IsPublished1Box || IsPublished4Box)
			{
				Helper.Helper.IsPublished4Box = true;
				await Navigation.PushAsync(new Views.RentOut.RentOutPage());
			}
			else if (Address.BedroomUpdated && Address.BathroomUpdated && Address.PropertyCompositionUpdated && Address.OtherRoomUpdated)
			{
				await Navigation.PushAsync(new Views.Bedroom.ToDoApartmentsPage());
			}
			else
				await Navigation.PushAsync(new Views.Bedroom.ApartmentInfoPage());

		}
		#endregion

		#region Stay Command.
		private ICommand stayCommand;
		public ICommand StayCommand
		{
			get => stayCommand ?? (stayCommand = new Command(async () => await ExecuteStayCommand()));
		}
		private async Task ExecuteStayCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.ApartmentInfoPage());
		}
		#endregion

		#region Wi-Fi Command.
		private ICommand wiFiCommand;
		public ICommand WiFiCommand
		{
			get => wiFiCommand ?? (wiFiCommand = new Command(async () => await ExecuteWiFiCommand()));
		}
		private async Task ExecuteWiFiCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.WiFiCodePage(Address));
		}
		#endregion

		#region Booking Command.
		private ICommand bookingCommand;
		public ICommand BookingCommand
		{
			get => bookingCommand ?? (bookingCommand = new Command(async () => await ExecuteBookingCommand()));
		}
		private async Task ExecuteBookingCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.BookingListPage());
		}
		#endregion

		#region Check In Check Out Command.
		private ICommand checkInCheckOutCommand;
		public ICommand CheckInCheckOutCommand
		{
			get => checkInCheckOutCommand ?? (checkInCheckOutCommand = new Command(async () => await ExecuteCheckInCheckOutCommand()));
		}
		private async Task ExecuteCheckInCheckOutCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.ManageCheckedInAndOutPage());
		}
		#endregion

		#region Pre Check In Guest Command.
		private ICommand preCheckInGuestCommand;
		public ICommand PreCheckInGuestCommand
		{
			get => preCheckInGuestCommand ?? (preCheckInGuestCommand = new Command(async () => await ExecutePPreCheckInGuestCommand()));
		}
		private async Task ExecutePPreCheckInGuestCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.PreCheckInGuestPage());
		}
		#endregion

		#region Check Out Guest Command.
		private ICommand checkOutGuestCommand;
		public ICommand CheckOutGuestCommand
		{
			get => checkOutGuestCommand ?? (checkOutGuestCommand = new Command(async () => await ExecuteCheckOutGuestCommand()));
		}
		private async Task ExecuteCheckOutGuestCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.CheckOutGuestPage());
		}
		#endregion

		#region Police Report Guest Command.
		private ICommand policeReportGuestCommand;
		public ICommand PoliceReportGuestCommand
		{
			get => policeReportGuestCommand ?? (policeReportGuestCommand = new Command(async () => await ExecutePoliceReportGuestCommand()));
		}
		private async Task ExecutePoliceReportGuestCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.PoliceReportGuestPage());
		}
		#endregion

		#region Clean Now Page Command.
		private ICommand cleanNowPageCommand;
		public ICommand CleanNowPageCommand
		{
			get => cleanNowPageCommand ?? (cleanNowPageCommand = new Command(async () => await ExecuteCleanNowPageCommand()));
		}
		private async Task ExecuteCleanNowPageCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.AssignCleaningTaskNowPage());
		}
		#endregion

		#region Home Repair Command.
		private ICommand homeRepairCommand;
		public ICommand HomeRepairCommand
		{
			get => homeRepairCommand ?? (homeRepairCommand = new Command(async () => await ExecuteHomeRepairCommand()));
		}
		private async Task ExecuteHomeRepairCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRepairService service = new RepairService();
			var response = await service.UserApartmentTicketListAsync(new Models.UserApartmentTicketListRequest()
			{
				ApartmentId = Address.Id
			});
			if (response?.Count >0)
				await Navigation.PushAsync(new Views.Repair.RepairListPage());
			else
				await Navigation.PushAsync(new Views.Repair.NoRepairListPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Stay Or Rent Out Command.
		private ICommand stayOrRentOutCommand;
		public ICommand StayOrRentOutCommand
		{
			get => stayOrRentOutCommand ?? (stayOrRentOutCommand = new Command<string>((option) => ExecuteStayOrRentOutCommand(option)));
		}
		private void ExecuteStayOrRentOutCommand(string option)
		{
			IsSetupNotCompleted = IsWiFi = IsFinishSetUp = IsPublished1Box = IsPublished4Box = false;
			switch (option)
            {
				case "Stay":
					IsStay = true;
					IsRentOut = false;
					if (Address.BedroomUpdated && Address.BathroomUpdated && Address.PropertyCompositionUpdated && Address.OtherRoomUpdated)
					{
						IsWiFi = true;
					}
					else
					{
						IsFinishSetUp = true;
					}
					
					break;
				case "RentOut":
					IsStay = false;
					IsRentOut = true;

					if (Address.BedroomUpdated && Address.BathroomUpdated && Address.PropertyCompositionUpdated && Address.OtherRoomUpdated)
					{
						if (Address.IsPublished)
							IsPublished4Box = true;
						else
							IsPublished1Box = true;
					}
					else
						IsSetupNotCompleted = true;
					break;
			}
        }
		#endregion

		#region Properties.
		private Models.EditAddressResponse address;
		public Models.EditAddressResponse Address
		{
			get => address;
			set
			{
				address = value;
				OnPropertyChanged("Address");
			}
		}

		private Models.UserDeliveryAddressesResponse userDeliveryAddresses;
		public Models.UserDeliveryAddressesResponse UserDeliveryAddresses
		{
			get => userDeliveryAddresses;
			set
			{
				userDeliveryAddresses = value;
				OnPropertyChanged("UserDeliveryAddresses");
			}
		}

		private bool isStay = true;
		public bool IsStay
		{
			get => isStay;
			set
			{
				isStay = value;
				OnPropertyChanged("IsStay");
			}
		}

		private bool isRentOut = false;
		public bool IsRentOut
		{
			get => isRentOut;
			set
			{
				isRentOut = value;
				OnPropertyChanged("IsRentOut");
			}
		}

		private bool isFinishSetUp = false;
		public bool IsFinishSetUp
		{
			get => isFinishSetUp;
			set
			{
				isFinishSetUp = value;
				OnPropertyChanged("IsFinishSetUp");
			}
		}

		private bool isSetupNotCompleted = false;
		public bool IsSetupNotCompleted
		{
			get => isSetupNotCompleted;
			set
			{
				isSetupNotCompleted = value;
				OnPropertyChanged("IsSetupNotCompleted");
			}
		}

		private bool isWiFi = false;
		public bool IsWiFi
		{
			get => isWiFi;
			set
			{
				isWiFi = value;
				OnPropertyChanged("IsWiFi");
			}
		}

		private bool isPublished1Box = false;
		public bool IsPublished1Box
		{
			get => isPublished1Box;
			set
			{
				isPublished1Box = value;
				OnPropertyChanged("IsPublished1Box");
			}
		}

		private bool isPublished4Box = false;
		public bool IsPublished4Box
		{
			get => isPublished4Box;
			set
			{
				isPublished4Box = value;
				OnPropertyChanged("IsPublished4Box");
			}
		}
		#endregion
	}
}
