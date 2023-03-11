using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class ApartmentInfoPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ApartmentInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
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
			IsPageLoad = false;
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			var response  = await service.GetAddressByIdAsync(new Models.EditAddressRequest()
			{
				id = Helper.Helper.SelectedUserDeliveryAddress.Id
			});

			if (response.BedroomUpdated && response.BathroomUpdated && response.PropertyCompositionUpdated && response.OtherRoomUpdated)
			{
				IsAboutVisible = true;
				IsApartmentUpdated = true;
			}
			else
			{
				IsAboutVisible = false;
				IsApartmentUpdated = false;
			}

			if (IsApartmentUpdated && response.IsWiFiUpdated)
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
				ApartmentCardWidthRequest = App.ScreenWidth-55;
			}
			else if (!response.IsWiFiUpdated)
			{
				IsApartmentUpdated = false;
				IsApartmentAndWifiUpdated = true;
				WifiCardWidthRequest = App.ScreenWidth -55;
			}
			Address = response;
			Helper.Helper.SelectedUserAddress = Address;
			DependencyService.Get<IProgressBar>().Hide();
			IsPageLoad = true;
		}
		#endregion

		#region Edit Wi Fi Command.
		private ICommand editWiFiCommand;
		public ICommand EditWiFiCommand
		{
			get => editWiFiCommand ?? (editWiFiCommand = new Command(async () => await ExecuteEditWiFiCommand()));
		}
		private async Task ExecuteEditWiFiCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			await Navigation.PushAsync(new Views.Bedroom.WiFiCodePage(Address));
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Go To Do Apartment Page Command.
		private ICommand goToDoApartmentPageCommand;
		public ICommand GoToDoApartmentPageCommand
		{
			get => goToDoApartmentPageCommand ?? (goToDoApartmentPageCommand = new Command(async () => await ExecuteGoToDoApartmentPageCommand()));
		}
		private async Task ExecuteGoToDoApartmentPageCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			await Navigation.PushAsync(new Views.Bedroom.ToDoApartmentsPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
		}
		#endregion

		#region Rent Out Command.
		private ICommand rentOutCommand;
		public ICommand RentOutCommand
		{
			get => rentOutCommand ?? (rentOutCommand = new Command(async () => await ExecuteRentOutCommand()));
		}
		private async Task ExecuteRentOutCommand()
		{
			if (!Address.BedroomUpdated || !Address.BathroomUpdated || !Address.PropertyCompositionUpdated || !Address.OtherRoomUpdated || !Address.IsWiFiUpdated)
				await Navigation.PushAsync(new Views.Bedroom.ErrorPage());
			else
				await Navigation.PushAsync(new Views.RentOut.RentOutPage());
		}
		#endregion

		#region Ownership Command.
		private ICommand ownershipCommand;
		public ICommand OwnershipCommand
		{
			get => ownershipCommand ?? (ownershipCommand = new Command(async () => await ExecuteOwnershipCommand()));
		}
		private async Task ExecuteOwnershipCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.OwnershipUpdatedPage());
		}
		#endregion

		#region Bedroom Page Command.
		private ICommand bedroomPageCommand;
		public ICommand BedroomPageCommand
		{
			get => bedroomPageCommand ?? (bedroomPageCommand = new Command(async () => await ExecuteBedroomPageCommand()));
		}
		private async Task ExecuteBedroomPageCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.UpdateMyHomeDetailsPage());
		}
		#endregion

		#region Bathroom Page Command.
		private ICommand bathroomPageCommand;
		public ICommand BathroomPageCommand
		{
			get => bathroomPageCommand ?? (bathroomPageCommand = new Command(async () => await ExecuteBathroomPageCommand()));
		}
		private async Task ExecuteBathroomPageCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.BathroomsDetailsPage());
		}
		#endregion

		#region Property Composition Page Command.
		private ICommand propertyCompositionPageCommand;
		public ICommand PropertyCompositionPageCommand
		{
			get => propertyCompositionPageCommand ?? (propertyCompositionPageCommand = new Command(async () => await ExecutePropertyCompositionPageCommand()));
		}
		private async Task ExecutePropertyCompositionPageCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.PropertyCompositionPage());
		}
		#endregion

		#region Other Rooms Page Command.
		private ICommand otherRoomsPageCommand;
		public ICommand OtherRoomsPageCommand
		{
			get => otherRoomsPageCommand ?? (otherRoomsPageCommand = new Command(async () => await ExecuteOtherRoomsPageCommand()));
		}
		private async Task ExecuteOtherRoomsPageCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.OtherRoomsPage());
		}
		#endregion

		#region Ownership Updated Page Command.
		private ICommand ownershipUpdatedPageCommand;
		public ICommand OwnershipUpdatedPageCommand
		{
			get => ownershipUpdatedPageCommand ?? (ownershipUpdatedPageCommand = new Command(async () => await ExecuteOwnershipUpdatedPageCommand()));
		}
		private async Task ExecuteOwnershipUpdatedPageCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.OwnershipUpdatedPage());
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

		private bool isApartmentUpdated;
		public bool IsApartmentUpdated
		{
			get => isApartmentUpdated;
			set
			{
				isApartmentUpdated = value;
				OnPropertyChanged("IsApartmentUpdated");
			}
		}

		private double apartmentCardWidthRequest = 278;
		public double ApartmentCardWidthRequest
		{
			get => apartmentCardWidthRequest;
			set
			{
				apartmentCardWidthRequest = value;
				OnPropertyChanged("ApartmentCardWidthRequest");
			}
		}

		private double wifiCardWidthRequest = 278;
		public double WifiCardWidthRequest
		{
			get => wifiCardWidthRequest;
			set
			{
				wifiCardWidthRequest = value;
				OnPropertyChanged("WifiCardWidthRequest");
			}
		}

		private bool isApartmentAndWifiUpdated = false;
		public bool IsApartmentAndWifiUpdated
		{
			get => isApartmentAndWifiUpdated;
			set
			{
				isApartmentAndWifiUpdated = value;
				OnPropertyChanged("IsApartmentAndWifiUpdated");
			}
		}

		private bool isAboutVisible = false;
		public bool IsAboutVisible
		{
			get => isAboutVisible;
			set
			{
				isAboutVisible = value;
				OnPropertyChanged("IsAboutVisible");
			}
		}
		#endregion
	}
}
