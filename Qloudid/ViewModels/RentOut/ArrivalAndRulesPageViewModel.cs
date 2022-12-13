using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class ArrivalAndRulesPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ArrivalAndRulesPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Check-in & Out Command.
		private ICommand checkInAndOutCommand;
		public ICommand CheckInAndOutCommand
		{
			get => checkInAndOutCommand ?? (checkInAndOutCommand = new Command(async () => await ExecuteCheckInAndOutCommand()));
		}
		private async Task ExecuteCheckInAndOutCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.CheckInAndOutPage());
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
		#endregion
	}
}
