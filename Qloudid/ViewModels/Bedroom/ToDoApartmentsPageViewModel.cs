using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class ToDoApartmentsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ToDoApartmentsPageViewModel(INavigation navigation)
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
			var response = await service.GetAddressByIdAsync(new Models.EditAddressRequest()
			{
				id = Helper.Helper.SelectedUserDeliveryAddress.Id
			});
			UserAddress = response;
			Helper.Helper.SelectedUserAddress = response;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Bedroom Page Command.
		private ICommand bedroomPageCommand;
		public ICommand BedroomPageCommand
		{
			get => bedroomPageCommand ?? (bedroomPageCommand = new Command(async () => await ExecuteBedroomPageCommand()));
		}
		private async Task ExecuteBedroomPageCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.UpdateMyHomeDetailsPage());
		}
		#endregion

		#region Bathroom Page Command.
		private ICommand bathroomPageCommand;
		public ICommand BathroomPageCommand
		{
			get => bathroomPageCommand ?? (bathroomPageCommand = new Command(async () => await ExecuteBathroomPageCommand()));
		}
		private async Task ExecuteBathroomPageCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.BathroomsDetailsPage());
		}
		#endregion

		#region Property Composition Page Command.
		private ICommand propertyCompositionPageCommand;
		public ICommand PropertyCompositionPageCommand
		{
			get => propertyCompositionPageCommand ?? (propertyCompositionPageCommand = new Command(async () => await ExecutePropertyCompositionPageCommand()));
		}
		private async Task ExecutePropertyCompositionPageCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.PropertyCompositionPage());
		}
		#endregion

		#region Other Rooms Page Command.
		private ICommand otherRoomsPageCommand;
		public ICommand OtherRoomsPageCommand
		{
			get => otherRoomsPageCommand ?? (otherRoomsPageCommand = new Command(async () => await ExecuteOtherRoomsPageCommand()));
		}
		private async Task ExecuteOtherRoomsPageCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.OtherRoomsPage());
		}
		#endregion

		#region Properties.
		private Models.EditAddressResponse userAddress;
		public Models.EditAddressResponse UserAddress
		{
			get => userAddress;
			set
			{
				userAddress = value;
				OnPropertyChanged("UserAddress");
			}
		}

		#endregion
	}
}
