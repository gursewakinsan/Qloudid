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
			IsVisibleDeliveryAddress = false;
			IDashboardService service = new DashboardService();
			AddressesList = await service.GetAddressesAsync(new Models.AddressesRequest() { UserId = Helper.Helper.UserId, UserAddress = Helper.Helper.UserOrCompanyAddress });
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

		#region Edit Address Command.
		private ICommand editAddressCommand;
		public ICommand EditAddressCommand
		{
			get => editAddressCommand ?? (editAddressCommand = new Command(async () => await ExecuteEditAddressCommand()));
		}
		private async Task ExecuteEditAddressCommand()
		{
			Helper.Helper.DeliveryAddress = new Models.AddressesResponse();
			Helper.Helper.DeliveryAddress.UserAddress = 1;
			Helper.Helper.DeliveryAddress.Id = DeliveryAddressDetail.Id;
			await Navigation.PushAsync(new Views.EditAddressPage());
		}
		#endregion

		#region Selected Address Command.
		private ICommand selectedAddressCommand;
		public ICommand SelectedAddressCommand
		{
			get => selectedAddressCommand ?? (selectedAddressCommand = new Command(async () => await ExecuteSelectedAddressCommand()));
		}
		private async Task ExecuteSelectedAddressCommand()
		{
			Helper.Helper.DeliveryAddressDetail = DeliveryAddressDetail;
			await Navigation.PushAsync(new Views.WhoIsPayingPage());
		}
		#endregion

		#region Get Delivery Address Detail Command.
		private ICommand getDeliveryAddressDetailCommand;
		public ICommand GetDeliveryAddressDetailCommand
		{
			get => getDeliveryAddressDetailCommand ?? (getDeliveryAddressDetailCommand = new Command(async () => await ExecuteGetDeliveryAddressDetailCommand()));
		}
		private async Task ExecuteGetDeliveryAddressDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			DeliveryAddressDetail = await service.DeliveryAddressDetailAsync(new Models.DeliveryAddressDetailRequest() { Id = SelectedAddressId, UserAddress = Helper.Helper.UserOrCompanyAddress });
			IsVisibleDeliveryAddress = true;
			DependencyService.Get<IProgressBar>().Hide();
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

		private Models.DeliveryAddressDetailResponse deliveryAddressDetail;
		public Models.DeliveryAddressDetailResponse DeliveryAddressDetail
		{
			get => deliveryAddressDetail;
			set
			{
				deliveryAddressDetail = value;
				OnPropertyChanged("DeliveryAddressDetail");
			}
		}

		private bool isVisibleDeliveryAddress = false;
		public bool IsVisibleDeliveryAddress
		{
			get => isVisibleDeliveryAddress;
			set
			{
				isVisibleDeliveryAddress = value;
				OnPropertyChanged("IsVisibleDeliveryAddress");
			}
		}

		private bool isUserAddress = Helper.Helper.UserOrCompanyAddress == 1 ? true : false;
		public bool IsUserAddress
		{
			get => isUserAddress;
			set
			{
				isUserAddress = value;
				OnPropertyChanged("IsUserAddress");
			}
		}

		private bool isCompanyAddress = Helper.Helper.UserOrCompanyAddress > 1 ? true : false;
		public bool IsCompanyAddress
		{
			get => isCompanyAddress;
			set
			{
				isCompanyAddress = value;
				OnPropertyChanged("IsCompanyAddress");
			}
		}
		public int SelectedAddressId { get; set; }
		public string UserName => Helper.Helper.UserInfo.DisplayUserName;
		#endregion
	}
}
