using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
    public class HouseRulesPageViewModel : BaseViewModel
	{
		#region Constructor.
		public HouseRulesPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
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
			IRentOutService service = new RentOutService();
			var response = await service.TimeHouseRulesInfoAsync();
			//Mon-Fri From
			MonFriFromTimeInfo = new ObservableCollection<Models.TimeHouseRulesInfoResponse>(response);
			//SelectedMonFriFromTimeInfo

			//Mon-Fri To
			MonFriToTimeInfo = new ObservableCollection<Models.TimeHouseRulesInfoResponse>(response);
			//SelectedMonFriToTimeInfo

			//Sat-Sun From
			SatSunFromTimeInfo = new ObservableCollection<Models.TimeHouseRulesInfoResponse>(response);
			//SatSunFromTimeInfo

			//Sat-Sun To
			SatSunToTimeInfo = new ObservableCollection<Models.TimeHouseRulesInfoResponse>(response);
			//SatSunToTimeInfo

			DependencyService.Get<IProgressBar>().Hide();
			IsPageLoad = true;
		}
		#endregion

		#region Update Apartment House Rules Command.
		private ICommand updateApartmentHouseRulesCommand;
		public ICommand UpdateApartmentHouseRulesCommand
		{
			get => updateApartmentHouseRulesCommand ?? (updateApartmentHouseRulesCommand = new Command(async () => await ExecuteUpdateApartmentHouseRulesCommand()));
		}
		private async Task ExecuteUpdateApartmentHouseRulesCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			await service.UpdateApartmentHouseRulesAsync(new Models.UpdateApartmentHouseRulesRequest()
			{
			});
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		//Mon - Fri From
		private ObservableCollection<Models.TimeHouseRulesInfoResponse> monFriFromTimeInfo;
		public ObservableCollection<Models.TimeHouseRulesInfoResponse> MonFriFromTimeInfo
		{
			get => monFriFromTimeInfo;
			set
			{
				monFriFromTimeInfo = value;
				OnPropertyChanged("MonFriFromTimeInfo");
			}
		}

		private Models.TimeHouseRulesInfoResponse selectedMonFriFromTimeInfo;
		public Models.TimeHouseRulesInfoResponse SelectedMonFriFromTimeInfo
		{
			get => selectedMonFriFromTimeInfo;
			set
			{
				selectedMonFriFromTimeInfo = value;
				OnPropertyChanged("SelectedMonFriFromTimeInfo");
			}
		}

		//Mon - Fri To
		private ObservableCollection<Models.TimeHouseRulesInfoResponse> monFriToTimeInfo;
		public ObservableCollection<Models.TimeHouseRulesInfoResponse> MonFriToTimeInfo
		{
			get => monFriToTimeInfo;
			set
			{
				monFriToTimeInfo = value;
				OnPropertyChanged("MonFriToTimeInfo");
			}
		}

		private Models.TimeHouseRulesInfoResponse selectedMonFriToTimeInfo;
		public Models.TimeHouseRulesInfoResponse SelectedMonFriToTimeInfo
		{
			get => selectedMonFriToTimeInfo;
			set
			{
				selectedMonFriToTimeInfo = value;
				OnPropertyChanged("SelectedMonFriToTimeInfo");
			}
		}

		//Sat - Sun From
		private ObservableCollection<Models.TimeHouseRulesInfoResponse> satSunFromTimeInfo;
		public ObservableCollection<Models.TimeHouseRulesInfoResponse> SatSunFromTimeInfo
		{
			get => satSunFromTimeInfo;
			set
			{
				satSunFromTimeInfo = value;
				OnPropertyChanged("SatSunFromTimeInfo");
			}
		}

		private Models.TimeHouseRulesInfoResponse selectedSatSunFromTimeInfo;
		public Models.TimeHouseRulesInfoResponse SelectedSatSunFromTimeInfo
		{
			get => selectedSatSunFromTimeInfo;
			set
			{
				selectedSatSunFromTimeInfo = value;
				OnPropertyChanged("SelectedSatSunFromTimeInfo");
			}
		}

		//Sat - Sun To
		private ObservableCollection<Models.TimeHouseRulesInfoResponse> satSunToTimeInfo;
		public ObservableCollection<Models.TimeHouseRulesInfoResponse> SatSunToTimeInfo
		{
			get => satSunToTimeInfo;
			set
			{
				satSunToTimeInfo = value;
				OnPropertyChanged("SatSunToTimeInfo");
			}
		}

		private Models.TimeHouseRulesInfoResponse selectedSatSunToTimeInfo;
		public Models.TimeHouseRulesInfoResponse SelectedSatSunToTimeInfo
		{
			get => selectedSatSunToTimeInfo;
			set
			{
				selectedSatSunToTimeInfo = value;
				OnPropertyChanged("SelectedSatSunToTimeInfo");
			}
		}

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
		#endregion
	}
}
