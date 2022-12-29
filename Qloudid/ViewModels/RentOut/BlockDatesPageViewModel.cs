using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class BlockDatesPageViewModel : BaseViewModel
    {
		#region Constructor.
		public BlockDatesPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
			IsDateDickerSelected = true;
			SelectedStartDate = DateTime.Today;
			SelectedEndDate = DateTime.Today;
		}
		#endregion

		#region Get Blocked Dates Command.
		private ICommand getBlockedDatesCommand;
		public ICommand GetBlockedDatesCommand
		{
			get => getBlockedDatesCommand ?? (getBlockedDatesCommand = new Command(async () => await ExecuteGetBlockedDatesCommand()));
		}
		private async Task ExecuteGetBlockedDatesCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			var response = await service.GetBlockedDatesAsync(new Models.GetBlockedDatesRequest()
			{
				ApartmentId = Address.Id
			});
			if (response?.Count > 0)
			{
				List<DateTime> dateTimes = new List<DateTime>();
				foreach (var date in response)
					dateTimes.Add(Convert.ToDateTime(date.BlockedDate));
				BlackoutDateList = dateTimes;
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Blocked Command.
		private ICommand updateBlockedCommand;
		public ICommand UpdateBlockedCommand
		{
			get => updateBlockedCommand ?? (updateBlockedCommand = new Command(async () => await ExecuteUpdateBlockedCommand()));
		}
		private async Task ExecuteUpdateBlockedCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			await service.UpdateBlockedAsync(new Models.UpdateBlockedRequest()
			{
				ApartmentId = Address.Id,
				StartDate = $"{SelectedStartDate.Day}-{SelectedStartDate.Month}-{SelectedStartDate.Year}",
				EndDate = $"{SelectedEndDate.Day}-{SelectedEndDate.Month}-{SelectedEndDate.Year}"
			});
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Available Command.
		private ICommand updateAvailableCommand;
		public ICommand UpdateAvailableCommand
		{
			get => updateAvailableCommand ?? (updateAvailableCommand = new Command(async () => await ExecuteUpdateAvailableCommand()));
		}
		private async Task ExecuteUpdateAvailableCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			await service.UpdateAvailableAsync(new Models.UpdateAvailableRequest()
			{
				ApartmentId = Address.Id,
				StartDate = $"{SelectedStartDate.Day}-{SelectedStartDate.Month}-{SelectedStartDate.Year}",
				EndDate = $"{SelectedEndDate.Day}-{SelectedEndDate.Month}-{SelectedEndDate.Year}"
			});
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Selected Date Picker Command.
		private ICommand selectedDatePickerCommand;
		public ICommand SelectedDatePickerCommand
		{
			get => selectedDatePickerCommand ?? (selectedDatePickerCommand = new Command(() => ExecuteSelectedDatePickerCommand()));
		}
		private void ExecuteSelectedDatePickerCommand()
		{
			IsDateDickerSelected = !IsDateDickerSelected;
		}
		#endregion

		#region Date Range Command.
		private ICommand dateRangeCommand;
		public ICommand DateRangeCommand
		{
			get => dateRangeCommand ?? (dateRangeCommand = new Command(() => ExecuteDateRangeCommand()));
		}
		private async void ExecuteDateRangeCommand()
		{
			if (SelectedEndDate < SelectedStartDate)
				await Helper.Alert.DisplayAlert("End date should never be less than start date.");
			else
			{
				if (PickerSelectedAction == 0)
					UpdateAvailableCommand.Execute(null);
				else
					UpdateBlockedCommand.Execute(null);
			}
		}
		#endregion

		#region Save Selected Dates Command.
		private ICommand saveSelectedDatesCommand;
		public ICommand SaveSelectedDatesCommand
		{
			get => saveSelectedDatesCommand ?? (saveSelectedDatesCommand = new Command(() => ExecuteSaveSelectedDatesCommand()));
		}
		private async void ExecuteSaveSelectedDatesCommand()
		{
			if (SelectedDateList?.Count == 0)
				await Helper.Alert.DisplayAlert("Please select dates");
			else
			{
				if (PickerSelectedAction == 0)
					UpdateSelectedAvailableCommand.Execute(null);
				else
					UpdateSelectedBlockedCommand.Execute(null);
			}
		}
		#endregion

		#region Update Selected Blocked Command.
		private ICommand updateSelectedBlockedCommand;
		public ICommand UpdateSelectedBlockedCommand
		{
			get => updateSelectedBlockedCommand ?? (updateSelectedBlockedCommand = new Command(async () => await ExecuteUpdateSelectedBlockedCommand()));
		}
		private async Task ExecuteUpdateSelectedBlockedCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			List<string> dates = new List<string>();
            foreach (var item in SelectedDateList)
				dates.Add($"{item.Year}-{item.Month}-{item.Day}");
			await service.UpdateSelectedBlockedAsync(new Models.UpdateSelectedBlockedRequest()
			{
				ApartmentId = Address.Id,
				SelectedDates = string.Join(",", dates)
			});
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Selected Available Command.
		private ICommand updateSelectedAvailableCommand;
		public ICommand UpdateSelectedAvailableCommand
		{
			get => updateSelectedAvailableCommand ?? (updateSelectedAvailableCommand = new Command(async () => await ExecuteUpdateSelectedAvailableCommand()));
		}
		private async Task ExecuteUpdateSelectedAvailableCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			List<string> dates = new List<string>();
			foreach (var item in SelectedDateList)
				dates.Add($"{item.Year}-{item.Month}-{item.Day}");
			await service.UpdateSelectedAvailableAsync(new Models.UpdateSelectedBlockedRequest()
			{
				ApartmentId = Address.Id,
				SelectedDates = string.Join(",", dates)
			});
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
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

		private bool isDateDickerSelected;
		public bool IsDateDickerSelected
		{
			get => isDateDickerSelected;
			set
			{
				isDateDickerSelected = value;
				if (value)
				{
					DateDickerBg = Color.FromHex("#0C8CE8");
					RangeBg = Color.Transparent;
				}
				else
				{
					RangeBg = Color.FromHex("#0C8CE8");
					DateDickerBg = Color.Transparent;
				}
				OnPropertyChanged("IsDateDickerSelected");
			}
		}

		private Color dateDickerBg;
		public Color DateDickerBg
		{
			get => dateDickerBg;
			set
			{
				dateDickerBg = value;
				OnPropertyChanged("DateDickerBg");
			}
		}

		private Color rangeBg;
		public Color RangeBg
		{
			get => rangeBg;
			set
			{
				rangeBg = value;
				OnPropertyChanged("RangeBg");
			}
		}

        public int PickerSelectedAction { get; set; }

		private DateTime selectedStartDate;
		public DateTime SelectedStartDate
		{
			get => selectedStartDate;
			set
			{
				selectedStartDate = value;
				OnPropertyChanged("SelectedStartDate");
			}
		}

		private DateTime selectedEndDate;
		public DateTime SelectedEndDate
		{
			get => selectedEndDate;
			set
			{
				selectedEndDate = value;
				OnPropertyChanged("SelectedEndDate");
			}
		}

		private List<DateTime> blackoutDateList;
		public List<DateTime> BlackoutDateList
		{
			get => blackoutDateList;
			set
			{
				blackoutDateList = value;
				OnPropertyChanged("BlackoutDateList");
			}
		}

		private List<DateTime> selectedDateList;
		public List<DateTime> SelectedDateList
		{
			get => selectedDateList;
			set
			{
				selectedDateList = value;
				OnPropertyChanged("SelectedDateList");
			}
		}
		#endregion
	}
}
