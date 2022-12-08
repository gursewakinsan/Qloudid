using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class WiFiCodePageViewModel : BaseViewModel
    {
		#region Constructor.
		public WiFiCodePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Wifi On/Off Command.
		private ICommand wifiOnOffCommand;
		public ICommand WifiOnOffCommand
		{
			get => wifiOnOffCommand ?? (wifiOnOffCommand = new Command(() => ExecuteWifiOnOffCommand()));
		}
		private void ExecuteWifiOnOffCommand()
		{
			IsWifiAvailable = !IsWifiAvailable;
		}
		#endregion

		#region Update Apartment Wifi Command.
		private ICommand updateApartmentWifiCommand;
		public ICommand UpdateApartmentWifiCommand
		{
			get => updateApartmentWifiCommand ?? (updateApartmentWifiCommand = new Command(async () => await ExecuteUpdateApartmentWifiCommand()));
		}
		private async Task ExecuteUpdateApartmentWifiCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			if (IsWifiAvailable)
			{
				if (string.IsNullOrWhiteSpace(WifiUsername))
					await Helper.Alert.DisplayAlert("Wifi username is required.");
				else if (string.IsNullOrWhiteSpace(WifiPassword))
					await Helper.Alert.DisplayAlert("Wifi password is required.");
				else
				{
					await service.UpdateApartmentWifiAsync(new Models.UpdateApartmentWifiRequest()
					{
						ApartmentId = Helper.Helper.SelectedUserDeliveryAddress.Id,
						WifiAvailable = 1,
						WifiPassword = WifiPassword,
						WifiUsername = WifiUsername,
					});
					Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
				}
			}
			else
			{
				await service.UpdateApartmentWifiAsync(new Models.UpdateApartmentWifiRequest()
				{
					ApartmentId = Helper.Helper.SelectedUserDeliveryAddress.Id,
					WifiAvailable = 0,
					WifiPassword = string.Empty,
					WifiUsername = string.Empty,
				});
				Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private bool isWifiAvailable;
		public bool IsWifiAvailable
		{
			get => isWifiAvailable;
			set
			{
				isWifiAvailable = value;
				OnPropertyChanged("IsWifiAvailable");
			}
		}

		private string wifiUsername;
		public string WifiUsername
		{
			get => wifiUsername;
			set
			{
				wifiUsername = value;
				OnPropertyChanged("WifiUsername");
			}
		}

		private string wifiPassword;
		public string WifiPassword
		{
			get => wifiPassword;
			set
			{
				wifiPassword = value;
				OnPropertyChanged("WifiPassword");
			}
		}
		#endregion
	}
}
