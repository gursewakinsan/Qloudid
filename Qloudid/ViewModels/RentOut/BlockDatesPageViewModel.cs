using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class BlockDatesPageViewModel : BaseViewModel
    {
		#region Constructor.
		public BlockDatesPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
			IsDateDickerSelected = false;
			SelectedStartDate = DateTime.Today;
			SelectedEndDate = DateTime.Today;
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
		#endregion
	}
}
