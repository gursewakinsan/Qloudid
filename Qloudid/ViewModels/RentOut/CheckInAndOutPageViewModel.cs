using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
    public class CheckInAndOutPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CheckInAndOutPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Time Info Command.
		private ICommand timeInfoCommand;
		public ICommand TimeInfoCommand
		{
			get => timeInfoCommand ?? (timeInfoCommand = new Command(async () => await ExecuteTimeInfoCommand()));
		}
		private async Task ExecuteTimeInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			var responseTimeInfo = await service.TimeInfoAsync();

			CheckInTimeInfo = new ObservableCollection<Models.TimeInfoResponse>(responseTimeInfo);
			SelectedCheckInTimeInfo = CheckInTimeInfo.FirstOrDefault(x => x.Id == Address.ArrivalTime);

			CheckOutTimeInfo = new ObservableCollection<Models.TimeInfoResponse>(responseTimeInfo);
			SelectedCheckOutTimeInfo = CheckInTimeInfo.FirstOrDefault(x => x.Id == Address.DepartureTime);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Submit Command.
		private ICommand submitCommand;
		public ICommand SubmitCommand
		{
			get => submitCommand ?? (submitCommand = new Command(async () => await ExecuteSubmitCommand()));
		}
		private async Task ExecuteSubmitCommand()
		{
			/*DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			DependencyService.Get<IProgressBar>().Hide();*/
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		private Models.EditAddressResponse address = Helper.Helper.SelectedUserAddress;
		public Models.EditAddressResponse Address
		{
			get => address;
			set
			{
				address = value;
				OnPropertyChanged("Address");
			}
		}

		private ObservableCollection<Models.TimeInfoResponse> checkInTimeInfo;
		public ObservableCollection<Models.TimeInfoResponse> CheckInTimeInfo
		{
			get => checkInTimeInfo;
			set
			{
				checkInTimeInfo = value;
				OnPropertyChanged("CheckInTimeInfo");
			}
		}

		private Models.TimeInfoResponse selectedCheckInTimeInfo;
		public Models.TimeInfoResponse SelectedCheckInTimeInfo
		{
			get => selectedCheckInTimeInfo;
			set
			{
				selectedCheckInTimeInfo = value;
				OnPropertyChanged("SelectedCheckInTimeInfo");
			}
		}

		private ObservableCollection<Models.TimeInfoResponse> checkOutTimeInfo;
		public ObservableCollection<Models.TimeInfoResponse> CheckOutTimeInfo
		{
			get => checkOutTimeInfo;
			set
			{
				checkOutTimeInfo = value;
				OnPropertyChanged("CheckOutTimeInfo");
			}
		}

		private Models.TimeInfoResponse selectedCheckOutTimeInfo;
		public Models.TimeInfoResponse SelectedCheckOutTimeInfo
		{
			get => selectedCheckOutTimeInfo;
			set
			{
				selectedCheckOutTimeInfo = value;
				OnPropertyChanged("SelectedCheckOutTimeInfo");
			}
		}
		#endregion
	}
}
