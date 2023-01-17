using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class ManageYourReservationsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ManageYourReservationsPageViewModel(INavigation navigation)
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
			ApartmentReservationConfermation = await service.ApartmentReservationConfermationRequiredAsync(new Models.ApartmentReservationConfermationRequest()
			{
				UserId = Helper.Helper.UserId
			});

			ApartmentReservationHistory = await service.ApartmentReservationHistoryAsync(new Models.ApartmentReservationHistoryRequest()
			{
				UserId = Helper.Helper.UserId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.ApartmentReservationConfermationResponse> apartmentReservationConfermation;
		public List<Models.ApartmentReservationConfermationResponse> ApartmentReservationConfermation
		{
			get => apartmentReservationConfermation;
			set
			{
				apartmentReservationConfermation = value;
				OnPropertyChanged("ApartmentReservationConfermation");
			}
		}

		private List<Models.ApartmentReservationHistoryResponse> apartmentReservationHistory;
		public List<Models.ApartmentReservationHistoryResponse> ApartmentReservationHistory
		{
			get => apartmentReservationHistory;
			set
			{
				apartmentReservationHistory = value;
				OnPropertyChanged("ApartmentReservationHistory");
			}
		}
		#endregion
	}
}