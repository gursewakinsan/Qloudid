using Xamarin.Forms;
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
			Address = Helper.Helper.SelectedUserAddress;
			if (Address.ArrivalDepartureUpdated && Address.HouseRulesUpdated)
			{
				ArrivalAndRulesIconBg = Color.FromHex("#4CD964");
				IsArrivalAndRulesIconChecked = true;
			}
			else if (!Address.ArrivalDepartureUpdated && !Address.HouseRulesUpdated)
			{
				ArrivalAndRulesIconBg = Color.FromHex("#F40000");
				IsArrivalAndRulesIconChecked = false;
			}
			else if (!Address.ArrivalDepartureUpdated && Address.HouseRulesUpdated)
			{
				ArrivalAndRulesIconBg = Color.FromHex("#F4B400");
				IsArrivalAndRulesIconChecked = false;
			}
			else if (Address.ArrivalDepartureUpdated && !Address.HouseRulesUpdated)
			{
				ArrivalAndRulesIconBg = Color.FromHex("#F4B400");
				IsArrivalAndRulesIconChecked = false;
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
		#endregion
	}
}
