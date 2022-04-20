using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class MissingPreCheckInInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public MissingPreCheckInInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Card Command.
		private ICommand cardCommand;
		public ICommand CardCommand
		{
			get => cardCommand ?? (cardCommand = new Command(async () => await ExecuteCardCommand()));
		}
		private async Task ExecuteCardCommand()
		{
			await Navigation.PushAsync(new Views.AddNewCardPage());
		}
		#endregion

		#region Address Command.
		private ICommand addressCommand;
		public ICommand AddressCommand
		{
			get => addressCommand ?? (addressCommand = new Command(async () => await ExecuteAddressCommand()));
		}
		private async Task ExecuteAddressCommand()
		{
			if (UserActiveStatusInfo.Cards == 0) return;
			await Navigation.PushAsync(new Views.AddDeliveryAddressPage());
		}
		#endregion

		#region Passport Command.
		private ICommand passportCommand;
		public ICommand PassportCommand
		{
			get => passportCommand ?? (passportCommand = new Command(async () => await ExecutePassportCommand()));
		}
		private async Task ExecutePassportCommand()
		{
			if (UserActiveStatusInfo.Cards == 0) return;
			Helper.Helper.SelectedIdentificatorText = "Passport";

			if (UserActiveStatusInfo.Passport == 0 && UserActiveStatusInfo.PassportId == 0)
				await Navigation.PushAsync(new Views.SelectedIdentificatorPage());
			else
				await Navigation.PushAsync(new Views.IdentificatorPhotoPage());
		}
		#endregion

		#region Properties.
		public Models.GetPreCheckinStatusResponse PreCheckinStatusInfo => Helper.Helper.PreCheckinStatusInfo;
		public Models.GetUserActiveStatusResponse UserActiveStatusInfo => Helper.Helper.PreCheckInUserActiveStatusInfo;
		#endregion
	}
}
