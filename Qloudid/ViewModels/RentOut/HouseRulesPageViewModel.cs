using System.Linq;
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

			Address.ChildrenAllowedBg = Address.ChildrenAllowed ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
			Address.InfantsAllowedBg = Address.InfantsAllowed ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
			Address.SmokingAllowedBg = Address.SmokingAllowed ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
			Address.EventsAllowedBg = Address.EventsAllowed ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
			Address.PetsAllowedBg = Address.PetsAllowed ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
		}
		#endregion

		#region Time House Rules Info Command.
		private ICommand timeHouseRulesInfoCommand;
		public ICommand TimeHouseRulesInfoCommand
		{
			get => timeHouseRulesInfoCommand ?? (timeHouseRulesInfoCommand = new Command(async () => await ExecuteTimeHouseRulesInfoCommand()));
		}
		private async Task ExecuteTimeHouseRulesInfoCommand()
		{
			IsPageLoad = false;
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			var response = await service.TimeHouseRulesInfoAsync();
			//Mon-Fri From
			MonFriFromTimeInfo = new ObservableCollection<Models.TimeHouseRulesInfoResponse>(response);
			if (string.IsNullOrWhiteSpace(Address.QuiteHrsMonFriOpen))
				SelectedMonFriFromTimeInfo = MonFriFromTimeInfo[0];
			else
				SelectedMonFriFromTimeInfo = MonFriFromTimeInfo.FirstOrDefault(x => x.Id.Equals(Address.QuiteHrsMonFriOpen));

			//Mon-Fri To
			MonFriToTimeInfo = new ObservableCollection<Models.TimeHouseRulesInfoResponse>(response);
			if (string.IsNullOrWhiteSpace(Address.QuiteHrsMonFriClose))
				SelectedMonFriToTimeInfo = MonFriToTimeInfo[0];
			else
				SelectedMonFriToTimeInfo = MonFriToTimeInfo.FirstOrDefault(x => x.Id.Equals(Address.QuiteHrsMonFriClose));

			//Sat-Sun From
			SatSunFromTimeInfo = new ObservableCollection<Models.TimeHouseRulesInfoResponse>(response);
			if (string.IsNullOrWhiteSpace(Address.QuiteHrsSatSunOpen))
				SelectedSatSunFromTimeInfo = SatSunFromTimeInfo[0];
			else
				SelectedSatSunFromTimeInfo = SatSunFromTimeInfo.FirstOrDefault(x => x.Id.Equals(Address.QuiteHrsSatSunOpen));

			//Sat-Sun To
			SatSunToTimeInfo = new ObservableCollection<Models.TimeHouseRulesInfoResponse>(response);
			if (string.IsNullOrWhiteSpace(Address.QuiteHrsSatSunClose))
				SelectedSatSunToTimeInfo = SatSunToTimeInfo[0];
			else
				SelectedSatSunToTimeInfo = SatSunToTimeInfo.FirstOrDefault(x => x.Id.Equals(Address.QuiteHrsSatSunClose));

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

			Models.UpdateApartmentHouseRulesRequest request = new Models.UpdateApartmentHouseRulesRequest()
			{
				ApartmentId = Address.Id,
				ChildrenAllowed = Address.ChildrenAllowed ? 1 : 0,
				InfantsAllowed = Address.InfantsAllowed ? 1 : 0,
				SmokingAllowed = Address.SmokingAllowed ? 1 : 0,
				EventsAllowed = Address.EventsAllowed ? 1 : 0,
				PetsAllowed = Address.PetsAllowed ? 1 : 0,
				QuiteHrs = Address.QuiteHrs ? 1 : 0,
				QuiteHrsMonFriOpen = SelectedMonFriFromTimeInfo?.Id,
				QuiteHrsMonFriClose = SelectedMonFriToTimeInfo?.Id,
				QuiteHrsSatSunOpen = SelectedSatSunFromTimeInfo?.Id,
				QuiteHrsSatSunClose = SelectedSatSunToTimeInfo?.Id,
			};
			if (!Address.QuiteHrs)
			{
				request.QuiteHrsMonFri = 0;
				request.QuiteHrsSatSun = 0;
			}
			else
			{
				request.QuiteHrsMonFri = Address.QuiteHrsMonFri ? 1 : 0;
				request.QuiteHrsSatSun = Address.QuiteHrsSatSun ? 1 : 0;
			}

			await service.UpdateApartmentHouseRulesAsync(request);
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Children Allowed Command.
		private ICommand childrenAllowedCommand;
		public ICommand ChildrenAllowedCommand
		{
			get => childrenAllowedCommand ?? (childrenAllowedCommand = new Command(() => ExecuteChildrenAllowedCommand()));
		}
		private void ExecuteChildrenAllowedCommand()
		{
			Address.ChildrenAllowed = !Address.ChildrenAllowed;
			Address.ChildrenAllowedBg = Address.ChildrenAllowed ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
		}
		#endregion

		#region Infants Allowed Command.
		private ICommand infantsAllowedCommand;
		public ICommand InfantsAllowedCommand
		{
			get => infantsAllowedCommand ?? (infantsAllowedCommand = new Command( () =>  ExecuteInfantsAllowedCommand()));
		}
		private void ExecuteInfantsAllowedCommand()
		{
			Address.InfantsAllowed = !Address.InfantsAllowed;
			Address.InfantsAllowedBg = Address.InfantsAllowed ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
		}
		#endregion

		#region Smoking Allowed Command.
		private ICommand smokingAllowedCommand;
		public ICommand SmokingAllowedCommand
		{
			get => smokingAllowedCommand ?? (smokingAllowedCommand = new Command(() => ExecuteSmokingAllowedCommand()));
		}
		private void ExecuteSmokingAllowedCommand()
		{
			Address.SmokingAllowed = !Address.SmokingAllowed;
			Address.SmokingAllowedBg = Address.SmokingAllowed ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
		}
		#endregion

		#region Events Allowed Command.
		private ICommand eventsAllowedCommand;
		public ICommand EventsAllowedCommand
		{
			get => eventsAllowedCommand ?? (eventsAllowedCommand = new Command(() => ExecuteEventsAllowedCommand()));
		}
		private void ExecuteEventsAllowedCommand()
		{
			Address.EventsAllowed = !Address.EventsAllowed;
			Address.EventsAllowedBg = Address.EventsAllowed ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
		}
		#endregion

		#region Pets Allowed Command.
		private ICommand petsAllowedCommand;
		public ICommand PetsAllowedCommand
		{
			get => petsAllowedCommand ?? (petsAllowedCommand = new Command(() => ExecutePetsAllowedCommand()));
		}
		private void ExecutePetsAllowedCommand()
		{
			Address.PetsAllowed = !Address.PetsAllowed;
			Address.PetsAllowedBg = Address.PetsAllowed ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
		}
		#endregion

		#region Quite Hrs Command.
		private ICommand quiteHrsCommand;
		public ICommand QuiteHrsCommand
		{
			get => quiteHrsCommand ?? (quiteHrsCommand = new Command(() => ExecuteQuiteHrsCommand()));
		}
		private void ExecuteQuiteHrsCommand()
		{
			Address.QuiteHrs = !Address.QuiteHrs;
		}
		#endregion

		#region Quite Hrs Mon-Fri Command.
		private ICommand quiteHrsMonFriCommand;
		public ICommand QuiteHrsMonFriCommand
		{
			get => quiteHrsMonFriCommand ?? (quiteHrsMonFriCommand = new Command(() => ExecuteQuiteHrsMonFriCommand()));
		}
		private void ExecuteQuiteHrsMonFriCommand()
		{
			Address.QuiteHrsMonFri = !Address.QuiteHrsMonFri;
		}
		#endregion

		#region Quite Hrs Sat-Sun Command.
		private ICommand quiteHrsSatSunCommand;
		public ICommand QuiteHrsSatSunCommand
		{
			get => quiteHrsSatSunCommand ?? (quiteHrsSatSunCommand = new Command(() => ExecuteQuiteHrsSatSunCommand()));
		}
		private void ExecuteQuiteHrsSatSunCommand()
		{
			Address.QuiteHrsSatSun = !Address.QuiteHrsSatSun;
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
