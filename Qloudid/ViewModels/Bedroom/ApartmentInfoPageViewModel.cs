using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class ApartmentInfoPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ApartmentInfoPageViewModel(INavigation navigation)
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
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			Address = await service.GetAddressByIdAsync(new Models.EditAddressRequest()
			{
				id = Helper.Helper.SelectedUserDeliveryAddress.Id
			});
			Helper.Helper.SelectedUserAddress = Address;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Edit Wi Fi Command.
		private ICommand editWiFiCommand;
		public ICommand EditWiFiCommand
		{
			get => editWiFiCommand ?? (editWiFiCommand = new Command(async () => await ExecuteEditWiFiCommand()));
		}
		private async Task ExecuteEditWiFiCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			await Navigation.PushAsync(new Views.Bedroom.WiFiCodePage(Address));
			DependencyService.Get<IProgressBar>().Hide();
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
			DependencyService.Get<IProgressBar>().Show();
			await Navigation.PushAsync(new Views.Bedroom.ToDoApartmentsPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
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
