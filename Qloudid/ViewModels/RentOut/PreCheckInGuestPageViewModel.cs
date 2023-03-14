using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class PreCheckInGuestPageViewModel : BaseViewModel
	{
		#region Constructor.
		public PreCheckInGuestPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Reservation History List Command.
		private ICommand reservationHistoryListCommand;
		public ICommand ReservationHistoryListCommand
		{
			get => reservationHistoryListCommand ?? (reservationHistoryListCommand = new Command(async () => await ExecuteReservationHistoryListCommand()));
		}
		private async Task ExecuteReservationHistoryListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			var responses = await service.ReservationHistoryListAsync(new Models.ReservationHistoryListRequest()
			{
				UserId = Helper.Helper.UserId,
				ApartmentId = SelectedApartment.Id
			});
			if (responses?.Count > 0)
			{
				foreach (var item in responses)
				{
					if (item.PreCheckInStatus == 0)
					{
						item.IconRed = true;
						item.IsAction = true;
					}
					else if (item.PreCheckInStatus == 1)
					{
						item.IconGreen = true;
						item.IsAction = false;
					}
					else if (item.PreCheckInStatus == 2)
					{
						item.IconYellow = true;
						item.IsAction = true;
					}
					else if (item.PreCheckInStatus == 3)
					{
						item.IconBlue = true;
						item.IsAction = false;
					}
				}
			}
			ReservationHistoryList = responses;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Resend Pre Check In Info Command.
		private ICommand resendPreCheckInInfoCommand;
		public ICommand ResendPreCheckInInfoCommand
		{
			get => resendPreCheckInInfoCommand ?? (resendPreCheckInInfoCommand = new Command<string>(async (checkId) => await ExecuteResendPreCheckInInfoCommand(checkId)));
		}
		private async Task ExecuteResendPreCheckInInfoCommand(string checkId)
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			await service.ResendPrecheckinInfoAsync(new Models.ResendPrecheckinInfoRequest()
			{
				CheckId = System.Convert.ToInt32(checkId)
			});
			ReservationHistoryListCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		public Models.UserDeliveryAddressesResponse SelectedApartment => Helper.Helper.SelectedUserDeliveryAddress;

		private List<Models.ReservationHistoryListResponse> reservationHistoryList;
		public List<Models.ReservationHistoryListResponse> ReservationHistoryList
		{
			get => reservationHistoryList;
			set
			{
				reservationHistoryList = value;
				OnPropertyChanged("ReservationHistoryList");
			}
		}
		#endregion
	}

	public class TestItems
	{
		public int Id { get; set; }

		public string CategoryName { get; set; }

		public string Address { get; set; }

		public string PortNumber { get; set; }

		public int CleaningJobStatus { get; set; }

		public string Enc { get; set; }

		public Color CircleBg { get; set; }

		public bool IsAction { get; set; }

		public bool NotClean { get; set; } = false;

		public bool CleaningStart { get; set; } = false;

		public bool Cleaned { get; set; } = false;
	}
}
