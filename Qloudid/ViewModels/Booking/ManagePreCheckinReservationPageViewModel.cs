using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class ManagePreCheckinReservationPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ManagePreCheckinReservationPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Back Button Control Command.
		private ICommand backButtonControlCommand;
		public ICommand BackButtonControlCommand
		{
			get => backButtonControlCommand ?? (backButtonControlCommand = new Command(async () => await ExecuteBackButtonControlCommand()));
		}
		private async Task ExecuteBackButtonControlCommand()
		{
			await Navigation.PopAsync();
		}
		#endregion

		#region Apartment Pre Checkin Required List Command.
		private ICommand apartmentPreCheckinRequiredListCommand;
		public ICommand ApartmentPreCheckinRequiredListCommand
		{
			get => apartmentPreCheckinRequiredListCommand ?? (apartmentPreCheckinRequiredListCommand = new Command(async () => await ExecuteApartmentPreCheckinRequiredListCommand()));
		}
		private async Task ExecuteApartmentPreCheckinRequiredListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			var response = await service.ApartmentPreCheckinRequiredListAsync(new Models.ApartmentPreCheckinRequiredListRequest()
			{
				UserId = Helper.Helper.UserId
			});
			if (response?.Count > 0)
			{
				PreCheckinReservationInfo = response.Where(x => x.PreCheckInStatus == false).ToList();
				PreCheckinReservationHistory = response.Where(x => x.PreCheckInStatus == true).ToList();
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Pre Check In Page Command.
		private ICommand preCheckInPageCommand;
		public ICommand PreCheckInPageCommand
		{
			get => preCheckInPageCommand ?? (preCheckInPageCommand = new Command<string>(async (enc) => await ExecutePreCheckInPageCommand(enc)));
		}
		private async Task ExecutePreCheckInPageCommand(string enc)
		{
			DependencyService.Get<IProgressBar>().Show();
			IPreCheckInService preCheckInService = new PreCheckInService();
			var responsePreCheckInService = await preCheckInService.GetPreCheckinStatusAsync(new Models.GetPreCheckinStatusRequest()
			{
				Id = enc,
				userId = Helper.Helper.UserId
			});
			Helper.Helper.PreCheckinStatusInfo = responsePreCheckInService;
			if (responsePreCheckInService != null)
				Helper.Helper.HotelCheckedIn = responsePreCheckInService.Checkid;

			if (responsePreCheckInService?.Result == 0)
			{
				Application.Current.MainPage = new NavigationPage(new Views.PreCheckIn.UnauthorizedPreCheckInPage());
				DependencyService.Get<IProgressBar>().Hide();
				return;
			}
			else if (responsePreCheckInService?.Result == 1)
			{
				Helper.Helper.PreCheckinStatus = 1;
				Helper.Helper.IsPreCheckIn = true;
				await Navigation.PushAsync(new Views.PreCheckIn.PreCheckInPage());
				DependencyService.Get<IProgressBar>().Hide();
				return;
			}
			else if (responsePreCheckInService?.Result == 2)
			{
				Helper.Helper.PreCheckinStatus = 2;
				Helper.Helper.IsPreCheckIn = true;
				await Navigation.PushAsync(new Views.PreCheckIn.PreCheckInPage());
				DependencyService.Get<IProgressBar>().Hide();
				return;
			}
			else if (responsePreCheckInService?.Result == 3)
			{
				Application.Current.MainPage = new NavigationPage(new Views.PreCheckIn.AlreadyDonePreCheckInPage());
				DependencyService.Get<IProgressBar>().Hide();
				return;
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.ApartmentPreCheckinRequiredListResponse> preCheckinReservationInfo;
		public List<Models.ApartmentPreCheckinRequiredListResponse> PreCheckinReservationInfo
		{
			get => preCheckinReservationInfo;
			set
			{
				preCheckinReservationInfo = value;
				OnPropertyChanged("PreCheckinReservationInfo");
			}
		}

		private List<Models.ApartmentPreCheckinRequiredListResponse> preCheckinReservationHistory;
		public List<Models.ApartmentPreCheckinRequiredListResponse> PreCheckinReservationHistory
		{
			get => preCheckinReservationHistory;
			set
			{
				preCheckinReservationHistory = value;
				OnPropertyChanged("PreCheckinReservationHistory");
			}
		}
		#endregion
	}
}
