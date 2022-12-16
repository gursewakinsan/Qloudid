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
			Address = response;
			Helper.Helper.SelectedUserAddress = Address;
			DependencyService.Get<IProgressBar>().Hide();
			IsPageLoad = true;
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
		#endregion
	}
}
