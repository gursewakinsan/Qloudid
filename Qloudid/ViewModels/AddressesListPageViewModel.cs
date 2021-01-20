using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class AddressesListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddressesListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get All Address Command.
		private ICommand getAllAddressCommand;
		public ICommand GetAllAddressCommand
		{
			get => getAllAddressCommand ?? (getAllAddressCommand = new Command(async () => await ExecuteGetAllAddressCommand()));
		}
		private async Task ExecuteGetAllAddressCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			AddressesList = await service.GetAddressesAsync(new Models.AddressesRequest() { UserId = Helper.Helper.UserId });
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Add New Address Command.
		private ICommand addNewAddressCommand;
		public ICommand AddNewAddressCommand
		{
			get => addNewAddressCommand ?? (addNewAddressCommand = new Command(async () => await ExecuteAddNewAddressCommand()));
		}
		private async Task ExecuteAddNewAddressCommand()
		{
			Helper.Helper.IsAddMoreAddresses = true;
			await Navigation.PushAsync(new Views.AddDeliveryAddressPage());
		}
		#endregion

		#region Properties.
		private List<Models.AddressesResponse> addressesList;
		public List<Models.AddressesResponse> AddressesList
		{
			get => addressesList;
			set
			{
				addressesList = value;
				OnPropertyChanged("AddressesList");
			}
		}
		#endregion
	}
}
