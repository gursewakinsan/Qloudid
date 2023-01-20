using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AccountFoundPageViewModel : BaseViewModel
    {
		#region Constructor.
		public AccountFoundPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Send Booking Request Info Command.
		private ICommand sendBookingRequestInfoCommand;
		public ICommand SendBookingRequestInfoCommand
		{
			get => sendBookingRequestInfoCommand ?? (sendBookingRequestInfoCommand = new Command(async () => await ExecuteSendBookingRequestInfoCommand()));
		}
		private async Task ExecuteSendBookingRequestInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			await service.SendBookingRequestInfoAsync(Helper.Helper.SendBookingRequestInfo);
			SkipCommand.Execute(null);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Skip Command.
		private ICommand skipCommand;
		public ICommand SkipCommand
		{
			get => skipCommand ?? (skipCommand = new Command(async () => await ExecuteSkipCommand()));
		}
		private async Task ExecuteSkipCommand()
		{
			this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
			this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
			await Navigation.PopAsync();
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
		#endregion
	}
}
