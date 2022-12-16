using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class NightlyPricingPageViewModel : BaseViewModel
    {
		#region Constructor.
		public NightlyPricingPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
			ManualBg = Color.FromHex("#0C8CE8");
			IsManualOrGeneric = true;
		}
		#endregion

		#region Selected Price Command.
		private ICommand selectedPriceCommand;
		public ICommand SelectedPriceCommand
		{
			get => selectedPriceCommand ?? (selectedPriceCommand = new Command<string>((selectedPrice) => ExecuteSelectedPriceCommand(selectedPrice)));
		}
		private void ExecuteSelectedPriceCommand(string selectedPrice)
		{
			switch (selectedPrice)
			{
				case "Manual":
					ManualBg = Color.FromHex("#0C8CE8");
					GenericBg = Color.Transparent;
					IsManualOrGeneric = true;
					break;
				case "Generic":
					ManualBg = Color.Transparent;
					GenericBg = Color.FromHex("#0C8CE8");
					IsManualOrGeneric = false;
					break;
			}
		}
		#endregion

		#region Selected Day Command.
		private ICommand selectedDayCommand;
		public ICommand SelectedDayCommand
		{
			get => selectedDayCommand ?? (selectedDayCommand = new Command<string>((day) => ExecuteSelectedDayCommand(day)));
		}
		private void ExecuteSelectedDayCommand(string day)
		{
			switch (day)
			{
				case "Monday":
					break;
				case "Tuesday":
					break;
				case "Wednesday":
					break;
				case "Thursday":
					break;
				case "Friday":
					break;
				case "Saturday":
					break;
				case "Sunday":
					break;
			}
		}
		#endregion

		#region Guest Duration Stay Minus Command.
		private ICommand guestDurationStayMinusCommand;
		public ICommand GuestDurationStayMinusCommand
		{
			get => guestDurationStayMinusCommand ?? (guestDurationStayMinusCommand = new Command(() => ExecuteGuestDurationStayMinusCommand()));
		}
		private void ExecuteGuestDurationStayMinusCommand()
		{
			if (GuestDurationStayCount > 1)
				GuestDurationStayCount = GuestDurationStayCount - 1;

		}
		#endregion

		#region Guest Duration Stay Plus Command.
		private ICommand guestDurationStayPlusCommand;
		public ICommand GuestDurationStayPlusCommand
		{
			get => guestDurationStayPlusCommand ?? (guestDurationStayPlusCommand = new Command(() => ExecuteGuestDurationStayPlusCommand()));
		}
		private void ExecuteGuestDurationStayPlusCommand()
		{
			GuestDurationStayCount = GuestDurationStayCount + 1;
		}
		#endregion

		#region Stay Offer Discount Minus Command.
		private ICommand stayOfferDiscountMinusCommand;
		public ICommand StayOfferDiscountMinusCommand
		{
			get => stayOfferDiscountMinusCommand ?? (stayOfferDiscountMinusCommand = new Command(() => ExecuteStayOfferDiscountMinusCommand()));
		}
		private void ExecuteStayOfferDiscountMinusCommand()
		{
		}
		#endregion

		#region Stay Offer Discount Plus Command.
		private ICommand stayOfferDiscountPlusCommand;
		public ICommand StayOfferDiscountPlusCommand
		{
			get => stayOfferDiscountPlusCommand ?? (stayOfferDiscountPlusCommand = new Command(() => ExecuteStayOfferDiscountPlusCommand()));
		}
		private void ExecuteStayOfferDiscountPlusCommand()
		{
		}
		#endregion

		#region Minimum Nights Stay Minus Command.
		private ICommand minimumNightsStayMinusCommand;
		public ICommand MinimumNightsStayMinusCommand
		{
			get => minimumNightsStayMinusCommand ?? (minimumNightsStayMinusCommand = new Command(() => ExecuteMinimumNightsStayMinusCommand()));
		}
		private void ExecuteMinimumNightsStayMinusCommand()
		{
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

		private bool isManualOrGeneric;
		public bool IsManualOrGeneric
		{
			get => isManualOrGeneric;
			set
			{
				isManualOrGeneric = value;
				OnPropertyChanged("IsManualOrGeneric");
			}
		}

		private Color manualBg;
		public Color ManualBg
		{
			get => manualBg;
			set
			{
				manualBg = value;
				OnPropertyChanged("ManualBg");
			}
		}

		private Color genericBg;
		public Color GenericBg
		{
			get => genericBg;
			set
			{
				genericBg = value;
				OnPropertyChanged("GenericBg");
			}
		}

		private int guestDurationStayCount = 1;
		public int GuestDurationStayCount
		{
			get => guestDurationStayCount;
			set
			{
				guestDurationStayCount = value;
				OnPropertyChanged("GuestDurationStayCount");
			}
		}
		#endregion
	}
}
