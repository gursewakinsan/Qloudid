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

		#region Manage Reservations Command.
		private ICommand manageReservationsCommand;
		public ICommand ManageReservationsCommand
		{
			get => manageReservationsCommand ?? (manageReservationsCommand = new Command(async () => await ExecuteManageReservationsCommand()));
		}
		private async Task ExecuteManageReservationsCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			var response = await service.ApartmentReservationConfermationRequiredAsync(new Models.ApartmentReservationConfermationRequest()
			{
				UserId = Helper.Helper.UserId
			});
			if (response == null)
			{
				PreCheckinReservationInfo = response.Where(x => x.PreCheckInStatus == false).ToList();
				PreCheckinReservationHistory = response.Where(x => x.PreCheckInStatus == true).ToList();
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.ApartmentReservationConfermationResponse> preCheckinReservationInfo;
		public List<Models.ApartmentReservationConfermationResponse> PreCheckinReservationInfo
		{
			get => preCheckinReservationInfo;
			set
			{
				preCheckinReservationInfo = value;
				OnPropertyChanged("PreCheckinReservationInfo");
			}
		}

		private List<Models.ApartmentReservationConfermationResponse> preCheckinReservationHistory;
		public List<Models.ApartmentReservationConfermationResponse> PreCheckinReservationHistory
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
