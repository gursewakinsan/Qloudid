using System;
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
			IsMondayOpen = IsTuesdayOpen = IsWednesdayOpen = false;
			IsThursdayOpen = IsFridayOpen = IsSaturdayOpen = IsSundayOpen = false;
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
					IsMondayOpen = !IsMondayOpen;
					break;
				case "Tuesday":
					IsTuesdayOpen = !IsTuesdayOpen;
					break;
				case "Wednesday":
					IsWednesdayOpen = !IsWednesdayOpen;
					break;
				case "Thursday":
					IsThursdayOpen = !IsThursdayOpen;
					break;
				case "Friday":
					IsFridayOpen = !IsFridayOpen;
					break;
				case "Saturday":
					IsSaturdayOpen = !IsSaturdayOpen;
					break;
				case "Sunday":
					IsSundayOpen = !IsSundayOpen;
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
			if (ShortestDuration > 1)
				ShortestDuration--;

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
			ShortestDuration++;
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
			if (DiscountForSeven > 0)
				DiscountForSeven--;
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
			DiscountForSeven++;
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
			if (TNights > 1)
				TNights--;
		}
		#endregion

		#region Minimum Nights Stay Plus Command.
		private ICommand minimumNightsStayPlusCommand;
		public ICommand MinimumNightsStayPlusCommand
		{
			get => minimumNightsStayPlusCommand ?? (minimumNightsStayPlusCommand = new Command(() => ExecuteMinimumNightsStayPlusCommand()));
		}
		private void ExecuteMinimumNightsStayPlusCommand()
		{
			TNights++;
		}
		#endregion

		#region Add Pricing Period Command.
		private ICommand addPricingPeriodCommand;
		public ICommand AddPricingPeriodCommand
		{
			get => addPricingPeriodCommand ?? (addPricingPeriodCommand = new Command(async() =>await ExecuteAddPricingPeriodCommand()));
		}
		private async Task ExecuteAddPricingPeriodCommand()
		{
			IsPageLoad = false;
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			AddPricingPeriod = await service.AddPricingPeriodAsync(new Models.AddPricingPeriodRequest()
			{
				ApartmentId = Address.Id
			});
			SelectedExpiryDate = Convert.ToDateTime(AddPricingPeriod.EndDate);
			DependencyService.Get<IProgressBar>().Hide();
			IsPageLoad = true;
		}
		#endregion

		#region Add Pricing Command.
		private ICommand addPricingCommand;
		public ICommand AddPricingCommand
		{
			get => addPricingCommand ?? (addPricingCommand = new Command(async () => await ExecuteAddPricingCommand()));
		}
		private async Task ExecuteAddPricingCommand()
		{
			if(IsManualOrGeneric)
			{
				if (string.IsNullOrEmpty(PricingTitle))
					await Helper.Alert.DisplayAlert("Pricing title is required.");
				else if (!IsMondayOpen && !IsTuesdayOpen && !IsWednesdayOpen && !IsThursdayOpen && !IsFridayOpen && !IsSaturdayOpen && !IsSundayOpen)
					await Helper.Alert.DisplayAlert("Please select days can guests arrive.");
				else if (IsMondayOpen && MondayPrice == 0)
					await Helper.Alert.DisplayAlert("Monday price cannot be zero");
				else if (IsTuesdayOpen && TuesdayPrice == 0)
					await Helper.Alert.DisplayAlert("Tuesday price cannot be zero");
				else if (IsWednesdayOpen && WednesdayPrice == 0)
					await Helper.Alert.DisplayAlert("Wednesday price cannot be zero");
				else if (IsThursdayOpen && ThursdayPrice == 0)
					await Helper.Alert.DisplayAlert("Thursday price cannot be zero");
				else if (IsFridayOpen && FridayPrice == 0)
					await Helper.Alert.DisplayAlert("Friday price cannot be zero");
				else if (IsSaturdayOpen && SaturdayPrice == 0)
					await Helper.Alert.DisplayAlert("Saturday price cannot be zero");
				else if (IsSundayOpen && SundayPrice == 0)
					await Helper.Alert.DisplayAlert("Sunday price cannot be zero");
				else
				{
					IsPageLoad = false;
					DependencyService.Get<IProgressBar>().Show();
					IRentOutService service = new RentOutService();
					Models.AddPricingRequest request = new Models.AddPricingRequest()
					{
						ApartmentId = Address.Id,
						Title = PricingTitle,
						StartDate = AddPricingPeriod.StartDate,
						EndDate = $"{SelectedExpiryDate.Year}-{SelectedExpiryDate.Month}-{SelectedExpiryDate.Day}",
						MondayOpen = IsMondayOpen ? 1 : 0,
						TuesdayOpen = IsTuesdayOpen ? 1 : 0,
						WednesdayOpen = IsWednesdayOpen ? 1 : 0,
						ThursdayOpen = IsThursdayOpen ? 1 : 0,
						FridayOpen = IsFridayOpen ? 1 : 0,
						SaturdayOpen = IsSaturdayOpen ? 1 : 0,
						SundayOpen = IsSundayOpen ? 1 : 0,
						ShortestDuration = ShortestDuration,
						DiscountForSeven = DiscountForSeven,
						MondayPrice = MondayPrice,
						TuesdayPrice = TuesdayPrice,
						WednesdayPrice = WednesdayPrice,
						ThursdayPrice = ThursdayPrice,
						FridayPrice = FridayPrice,
						SaturdayPrice = SundayPrice,
						SundayPrice = SundayPrice,
					};
					int[] array = { MondayPrice, TuesdayPrice, WednesdayPrice, ThursdayPrice, FridayPrice, SaturdayPrice, SundayPrice };
					int max = array[0];
					int min = array[0];
					for (int i = 0; i <= array.Length - 1; i++)
					{
						if (array[i] > max)
						{
							if (array[i] > 0)
								max = array[i];
						}
						if (array[i] < min)
						{
							if (array[i] > 0)
								min = array[i];
						}
					}
					request.MinimumPrice = min;
					request.MaximumPrice = max;
					await service.AddPricingAsync(request);
					await Navigation.PopAsync();
					DependencyService.Get<IProgressBar>().Hide();
					IsPageLoad = true;
				}
			}
			else
			{
				if (StandardPricePerNight == 0)
					await Helper.Alert.DisplayAlert("Price per night cannot be zero.");
				else
				{
					DependencyService.Get<IProgressBar>().Show();
					IRentOutService service = new RentOutService();
					Models.GeneratePricingRequest generatePricingRequest = new Models.GeneratePricingRequest()
					{
						DatePicker = $"{SelectedStartDate.Year}-{SelectedStartDate.Month}-{SelectedStartDate.Day}",
						StandardPricePerNight = StandardPricePerNight,
						ApartmentId = Address.Id,
						SeasonalityTemplate = SeasonalityTemplate,
						TNights = TNights
					};
					await service.GeneratePricingAsync(generatePricingRequest);
					await Navigation.PopAsync();
					DependencyService.Get<IProgressBar>().Hide();
				}
			}
		}
		#endregion

		#region Properties.
		private Models.AddPricingPeriodResponse addPricingPeriod;
		public Models.AddPricingPeriodResponse AddPricingPeriod
		{
			get => addPricingPeriod;
			set
			{
				addPricingPeriod = value;
				OnPropertyChanged("AddPricingPeriod");
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

		private string pricingTitle;
		public string PricingTitle
		{
			get => pricingTitle;
			set
			{
				pricingTitle = value;
				OnPropertyChanged("PricingTitle");
			}
		}

		private bool isMondayOpen;
		public bool IsMondayOpen
		{
			get => isMondayOpen;
			set
			{
				isMondayOpen = value;
				OnPropertyChanged("IsMondayOpen");
				MondayOpenBg = value ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
				if (!value) MondayPrice = 0;
			}
		}

		private Color mondayOpenBg;
		public Color MondayOpenBg
		{
			get => mondayOpenBg;
			set
			{
				mondayOpenBg = value;
				OnPropertyChanged("MondayOpenBg");
			}
		}

		private bool isTuesdayOpen;
		public bool IsTuesdayOpen
		{
			get => isTuesdayOpen;
			set
			{
				isTuesdayOpen = value;
				OnPropertyChanged("IsTuesdayOpen");
				TuesdayOpenBg = value ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
				if (!value) TuesdayPrice = 0;
			}
		}

		private Color tuesdayOpenBg;
		public Color TuesdayOpenBg
		{
			get => tuesdayOpenBg;
			set
			{
				tuesdayOpenBg = value;
				OnPropertyChanged("TuesdayOpenBg");
			}
		}

		private bool isWednesdayOpen;
		public bool IsWednesdayOpen
		{
			get => isWednesdayOpen;
			set
			{
				isWednesdayOpen = value;
				OnPropertyChanged("IsWednesdayOpen");
				WednesdayOpenBg = value ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
				if (!value) WednesdayPrice = 0;
			}
		}

		private Color wednesdayOpenBg;
		public Color WednesdayOpenBg
		{
			get => wednesdayOpenBg;
			set
			{
				wednesdayOpenBg = value;
				OnPropertyChanged("WednesdayOpenBg");
			}
		}

		private bool isThursdayOpen;
		public bool IsThursdayOpen
		{
			get => isThursdayOpen;
			set
			{
				isThursdayOpen = value;
				OnPropertyChanged("IsThursdayOpen");
				ThursdayOpenBg = value ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
				if (!value) ThursdayPrice = 0;
			}
		}

		private Color thursdayOpenBg;
		public Color ThursdayOpenBg
		{
			get => thursdayOpenBg;
			set
			{
				thursdayOpenBg = value;
				OnPropertyChanged("ThursdayOpenBg");
			}
		}

		private bool isFridayOpen;
		public bool IsFridayOpen
		{
			get => isFridayOpen;
			set
			{
				isFridayOpen = value;
				OnPropertyChanged("IsFridayOpen");
				FridayOpenBg = value ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
				if (!value) FridayPrice = 0;
			}
		}

		private Color fridayOpenBg;
		public Color FridayOpenBg
		{
			get => fridayOpenBg;
			set
			{
				fridayOpenBg = value;
				OnPropertyChanged("FridayOpenBg");
			}
		}

		private bool isSaturdayOpen;
		public bool IsSaturdayOpen
		{
			get => isSaturdayOpen;
			set
			{
				isSaturdayOpen = value;
				OnPropertyChanged("IsSaturdayOpen");
				SaturdayOpenBg = value ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
				if (!value) SaturdayPrice = 0;
			}
		}

		private Color saturdayOpenBg;
		public Color SaturdayOpenBg
		{
			get => saturdayOpenBg;
			set
			{
				saturdayOpenBg = value;
				OnPropertyChanged("SaturdayOpenBg");
			}
		}

		private bool isSundayOpen;
		public bool IsSundayOpen
		{
			get => isSundayOpen;
			set
			{
				isSundayOpen = value;
				OnPropertyChanged("IsSundayOpen");
				SundayOpenBg = value ? Color.FromHex("#0C8CE8") : Color.FromHex("#242A37");
				if (!value) SundayPrice = 0;
			}
		}

		private Color sundayOpenBg;
		public Color SundayOpenBg
		{
			get => sundayOpenBg;
			set
			{
				sundayOpenBg = value;
				OnPropertyChanged("SundayOpenBg");
			}
		}

		private DateTime selectedExpiryDate;
		public DateTime SelectedExpiryDate
		{
			get => selectedExpiryDate;
			set
			{
				selectedExpiryDate = value;
				OnPropertyChanged("SelectedExpiryDate");
			}
		}

		private int shortestDuration = 1;
		public int ShortestDuration
		{
			get => shortestDuration;
			set
			{
				shortestDuration = value;
				OnPropertyChanged("ShortestDuration");
			}
		}

		private int discountForSeven;
		public int DiscountForSeven
		{
			get => discountForSeven;
			set
			{
				discountForSeven = value;
				OnPropertyChanged("DiscountForSeven");
			}
		}

		private int mondayPrice;
		public int MondayPrice
		{
			get => mondayPrice;
			set
			{
				mondayPrice = value;
				OnPropertyChanged("MondayPrice");
			}
		}

		private int tuesdayPrice;
		public int TuesdayPrice
		{
			get => tuesdayPrice;
			set
			{
				tuesdayPrice = value;
				OnPropertyChanged("TuesdayPrice");
			}
		}

		private int wednesdayPrice;
		public int WednesdayPrice
		{
			get => wednesdayPrice;
			set
			{
				wednesdayPrice = value;
				OnPropertyChanged("WednesdayPrice");
			}
		}

		private int thursdayPrice;
		public int ThursdayPrice
		{
			get => thursdayPrice;
			set
			{
				thursdayPrice = value;
				OnPropertyChanged("ThursdayPrice");
			}
		}

		private int fridayPrice;
		public int FridayPrice
		{
			get => fridayPrice;
			set
			{
				fridayPrice = value;
				OnPropertyChanged("FridayPrice");
			}
		}

		private int saturdayPrice;
		public int SaturdayPrice
		{
			get => saturdayPrice;
			set
			{
				saturdayPrice = value;
				OnPropertyChanged("SaturdayPrice");
			}
		}

		private int sundayPrice;
		public int SundayPrice
		{
			get => sundayPrice;
			set
			{
				sundayPrice = value;
				OnPropertyChanged("SundayPrice");
			}
		}
		public DateTime BindExpiryMinimumDate => DateTime.Today;
		public DateTime BindExpiryMaximumDate => DateTime.Today.AddYears(70);

		//Generic Tab
		private DateTime selectedStartDate = DateTime.Today;
		public DateTime SelectedStartDate
		{
			get => selectedStartDate;
			set
			{
				selectedStartDate = value;
				OnPropertyChanged("SelectedStartDate");
			}
		}

		private int standardPricePerNight;
		public int StandardPricePerNight
		{
			get => standardPricePerNight;
			set
			{
				standardPricePerNight = value;
				OnPropertyChanged("StandardPricePerNight");
			}
		}

		private int seasonalityTemplate;
		public int SeasonalityTemplate
		{
			get => seasonalityTemplate;
			set
			{
				seasonalityTemplate = value;
				OnPropertyChanged("SeasonalityTemplate");
			}
		}

		private int tNights = 1;
		public int TNights
		{
			get => tNights;
			set
			{
				tNights = value;
				OnPropertyChanged("TNights");
			}
		}
		public DateTime BindStartMinimumDate => DateTime.Today;
		public DateTime BindStartMaximumDate => DateTime.Today.AddYears(70);
		#endregion
	}
}
