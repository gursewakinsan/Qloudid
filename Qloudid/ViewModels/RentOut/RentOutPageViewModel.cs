using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class RentOutPageViewModel : BaseViewModel
	{
		#region Constructor.
		public RentOutPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Address By Id Command.
		private ICommand getAddressByIdCommand;
		public ICommand GetAddressByIdCommand
		{
			get => getAddressByIdCommand ?? (getAddressByIdCommand = new Command(async () => await ExecuteGetAddressByIdCommand()));
		}
		private async Task ExecuteGetAddressByIdCommand()
        {
            IsPageLoad = false;
            DependencyService.Get<IProgressBar>().Show();
            IDashboardService service = new DashboardService();
            var response = await service.GetAddressByIdAsync(new Models.EditAddressRequest()
            {
                id = Helper.Helper.SelectedUserDeliveryAddress.Id
            });
            ApartmentUpdated(response);
            ArrivalAndRulesUpdated(response);
            PhotoTextAndAvailabilityUpdated(response);
            PricingFeesAndChannelsUpdated(response);
			GetStartedManualsUpdated(response);
			Address = response;
            Helper.Helper.SelectedUserAddress = Address;
            DependencyService.Get<IProgressBar>().Hide();
            IsPageLoad = true;
        }

        #endregion

        #region Rent out item updated
        void ApartmentUpdated(Models.EditAddressResponse response)
		{
			if (response.BedroomUpdated && response.BathroomUpdated && response.PropertyCompositionUpdated && response.OtherRoomUpdated)
			{
				IsApartment = true;
				ApartmentBg = Color.FromHex("#4CD964");
			}
			else if(!response.BedroomUpdated && !response.BathroomUpdated && !response.PropertyCompositionUpdated && !response.OtherRoomUpdated)
			{
				IsApartment = false;
				ApartmentBg = Color.FromHex("#F40000");
			}
			else if (!response.BedroomUpdated || !response.BathroomUpdated || !response.PropertyCompositionUpdated || !response.OtherRoomUpdated)
			{
				IsApartment = false;
				ApartmentBg = Color.FromHex("#F4B400");
			}
		}

		void ArrivalAndRulesUpdated(Models.EditAddressResponse response)
		{
			if (response.ArrivalDepartureUpdated && response.HouseRulesUpdated)
			{
				ArrivalAndRulesIconBg = Color.FromHex("#4CD964");
				IsArrivalAndRulesIconChecked = true;
			}
			else if (!response.ArrivalDepartureUpdated && !response.HouseRulesUpdated)
			{
				ArrivalAndRulesIconBg = Color.FromHex("#F40000");
				IsArrivalAndRulesIconChecked = false;
			}
			else if (!response.ArrivalDepartureUpdated && response.HouseRulesUpdated)
			{
				ArrivalAndRulesIconBg = Color.FromHex("#F4B400");
				IsArrivalAndRulesIconChecked = false;
			}
			else if (response.ArrivalDepartureUpdated && !response.HouseRulesUpdated)
			{
				ArrivalAndRulesIconBg = Color.FromHex("#F4B400");
				IsArrivalAndRulesIconChecked = false;
			}
		}

		void PhotoTextAndAvailabilityUpdated(Models.EditAddressResponse response)
		{
			if (response.PricingUpdated && response.NicknameUpdated && response.HeadLineUpdated && response.DescriptionUpdated)
			{
				IsPhotoTextAndAvailability = true;
				PhotoTextAndAvailabilityBg = Color.FromHex("#4CD964");
			}
			else if (!response.PricingUpdated && !response.NicknameUpdated && !response.HeadLineUpdated && !response.DescriptionUpdated)
			{
				IsPhotoTextAndAvailability = false;
				PhotoTextAndAvailabilityBg = Color.FromHex("#F40000");
			}
			else if (!response.PricingUpdated || !response.NicknameUpdated || !response.HeadLineUpdated || !response.DescriptionUpdated)
			{
				IsPhotoTextAndAvailability = false;
				PhotoTextAndAvailabilityBg = Color.FromHex("#F4B400");
			}
		}

		void PricingFeesAndChannelsUpdated(Models.EditAddressResponse response)
		{
			if (response.PricingUpdated && response.FeeUpdated && response.SecurityFeeUpdated && response.PolicyUpdated)
			{
				IsPricing = true;
				PricingBg = Color.FromHex("#4CD964");
			}
			else if (!response.PricingUpdated && !response.FeeUpdated && !response.SecurityFeeUpdated && !response.PolicyUpdated)
			{
				IsPricing = false;
				PricingBg = Color.FromHex("#F40000");
			}
			else if (!response.PricingUpdated || !response.FeeUpdated || !response.SecurityFeeUpdated || !response.PolicyUpdated)
			{
				IsPricing = false;
				PricingBg = Color.FromHex("#F4B400");
			}
		}

		void GetStartedManualsUpdated(Models.EditAddressResponse response)
		{
			if (response.GetStartedUpdated == 0)
			{
				IsGetStarted = false;
				GetStartedBg = Color.FromHex("#F40000");
			}
			else if (response.GetStartedUpdated == 1)
			{
				IsGetStarted = true;
				GetStartedBg = Color.FromHex("#4CD964");
			}
			else if (response.GetStartedUpdated == 2)
			{
				IsGetStarted = false;
				GetStartedBg = Color.FromHex("#F4B400");
			}
		}
		#endregion

		#region Arrival & Rules Command.
		private ICommand arrivalAndRulesCommand;
		public ICommand ArrivalAndRulesCommand
		{
			get => arrivalAndRulesCommand ?? (arrivalAndRulesCommand = new Command(async () => await ExecuteArrivalAndRulesCommand()));
		}
		private async Task ExecuteArrivalAndRulesCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.ArrivalAndRulesPage());
		}
		#endregion

		#region Go To Do Apartment Page Command.
		private ICommand goToDoApartmentPageCommand;
		public ICommand GoToDoApartmentPageCommand
		{
			get => goToDoApartmentPageCommand ?? (goToDoApartmentPageCommand = new Command(async () => await ExecuteGoToDoApartmentPageCommand()));
		}
		private async Task ExecuteGoToDoApartmentPageCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.ToDoApartmentsPage());
		}
		#endregion

		#region Pricing & Tax Page Command.
		private ICommand pricingAndTaxPageCommand;
		public ICommand PricingAndTaxPageCommand
		{
			get => pricingAndTaxPageCommand ?? (pricingAndTaxPageCommand = new Command(async () => await ExecutePricingAndTaxPageCommand()));
		}
		private async Task ExecutePricingAndTaxPageCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.PricingAndTaxPage());
		}
		#endregion

		#region Photo, Text & Availability Command.
		private ICommand photoTextAndAvailabilityCommand;
		public ICommand PhotoTextAndAvailabilityCommand
		{
			get => photoTextAndAvailabilityCommand ?? (photoTextAndAvailabilityCommand = new Command(async () => await ExecutePhotoTextAndAvailabilityCommand()));
		}
		private async Task ExecutePhotoTextAndAvailabilityCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.PhotoAndTextPage());
		}
		#endregion

		#region Started Manuals Page Command.
		private ICommand startedManualsPageCommand;
		public ICommand StartedManualsPageCommand
		{
			get => startedManualsPageCommand ?? (startedManualsPageCommand = new Command(async () => await ExecuteStartedManualsPageCommand()));
		}
		private async Task ExecuteStartedManualsPageCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.ManualsPage());
		}
		#endregion

		#region Publish Apartmenton Channel Command.
		private ICommand publishApartmentonChannelCommand;
		public ICommand PublishApartmentonChannelCommand
		{
			get => publishApartmentonChannelCommand ?? (publishApartmentonChannelCommand = new Command(async () => await ExecutePublishApartmentonChannelCommand()));
		}
		private async Task ExecutePublishApartmentonChannelCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			await service.PublishApartmentonChannelAsync(new Models.PublishApartmentonChannelRequest()
			{
				ApartmentId = Address.Id
			});
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

		private Color arrivalAndRulesIconBg;
		public Color ArrivalAndRulesIconBg
		{
			get => arrivalAndRulesIconBg;
			set
			{
				arrivalAndRulesIconBg = value;
				OnPropertyChanged("ArrivalAndRulesIconBg");
			}
		}

		private bool isArrivalAndRulesIconChecked;
		public bool IsArrivalAndRulesIconChecked
		{
			get => isArrivalAndRulesIconChecked;
			set
			{
				isArrivalAndRulesIconChecked = value;
				OnPropertyChanged("IsArrivalAndRulesIconChecked");
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

		private bool isPricing;
		public bool IsPricing
		{
			get => isPricing;
			set
			{
				isPricing = value;
				OnPropertyChanged("IsPricing");
			}
		}

		private Color pricingBg;
		public Color PricingBg
		{
			get => pricingBg;
			set
			{
				pricingBg = value;
				OnPropertyChanged("PricingBg");
			}
		}

		private Color getStartedBg;
		public Color GetStartedBg
		{
			get => getStartedBg;
			set
			{
				getStartedBg = value;
				OnPropertyChanged("GetStartedBg");
			}
		}

		private bool isGetStarted;
		public bool IsGetStarted
		{
			get => isGetStarted;
			set
			{
				isGetStarted = value;
				OnPropertyChanged("IsGetStarted");
			}
		}

		private Color apartmentBg;
		public Color ApartmentBg
		{
			get => apartmentBg;
			set
			{
				apartmentBg = value;
				OnPropertyChanged("ApartmentBg");
			}
		}

		private bool isApartment;
		public bool IsApartment
		{
			get => isApartment;
			set
			{
				isApartment = value;
				OnPropertyChanged("IsApartment");
			}
		}

		private Color photoTextAndAvailabilityBg;
		public Color PhotoTextAndAvailabilityBg
		{
			get => photoTextAndAvailabilityBg;
			set
			{
				photoTextAndAvailabilityBg = value;
				OnPropertyChanged("PhotoTextAndAvailabilityBg");
			}
		}

		private bool isPhotoTextAndAvailability;
		public bool IsPhotoTextAndAvailability
		{
			get => isPhotoTextAndAvailability;
			set
			{
				isPhotoTextAndAvailability = value;
				OnPropertyChanged("IsPhotoTextAndAvailability");
			}
		}
		#endregion
	}
}