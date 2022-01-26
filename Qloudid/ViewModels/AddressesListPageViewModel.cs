using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
			if (AddressesList != null && AddressesList.Count == 1)
			{
				IsSingleDeliveryAddress = false;
				SelectedAddressId = AddressesList[0].Id;
				GetDeliveryAddressDetailCommand.Execute(null);
			}
			else
				IsSingleDeliveryAddress = true;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Get Delivery Address Command.
		private ICommand getDeliveryAddressCommand;
		public ICommand GetDeliveryAddressCommand
		{
			get => getDeliveryAddressCommand ?? (getDeliveryAddressCommand = new Command(async () => await ExecuteGetDeliveryAddressCommand()));
		}
		private async Task ExecuteGetDeliveryAddressCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			var response = await service.GetDeliveryAddressesAsync(new Models.DeliveryAddressesRequest() { UserId = Helper.Helper.UserId });
			var list = new List<Models.UserAddress>();
			if (response?.UserAddress?.Count > 0)
			{
				foreach (var item in response.UserAddress)
				{
					item.UserName = string.Empty;
					item.IsPersonal = true;
					item.IsBusiness = false;
					list.Add(item);
				}
			}

			if (response?.CompanyAddress?.Count > 0)
			{
				foreach (var item in response.CompanyAddress)
				{
					item.UserName = UserName;
					item.IsPersonal = false;
					item.IsBusiness = false;
					list.Add(item);
				}
			}
			CopyUserAddress = list;
			ListOfDeliveryAddress = new ObservableCollection<Models.UserAddress>(list);
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
			IPickupService pickupService = new PickupService();
			var pickupServiceResponse = await pickupService.PickupAddressDetailAsync(new Models.PickupAddressDetailRequest()
			{
				Certificate = Helper.Helper.QrCertificateKey,
				CompanyId = Helper.Helper.VerifyUserConsentClientId
			});
			if (pickupServiceResponse?.Count > 0)
			{
				Helper.Helper.PickupAddressList = pickupServiceResponse;
				await Navigation.PushAsync(new Views.Pickup.SelectHomeOrPickUpPage());
			}
			else
			{
				Helper.Helper.IsPickupAddress = false;
				await Navigation.PushAsync(new Views.ReadOnlyDeliveryAddressPage());
			}
		}
		#endregion

		#region Show Personal Addresses Command.
		private ICommand showPersonalAddressesCommand;
		public ICommand ShowPersonalAddressesCommand
		{
			get => showPersonalAddressesCommand ?? (showPersonalAddressesCommand = new Command(async () => await ExecuteShowPersonalAddressesCommand()));
		}
		private async Task ExecuteShowPersonalAddressesCommand()
		{
			IsPersonalOrBusiness = true;
			BtnPersonalBg = "#6263ED";
			BtnBusinessBg = "#2A2A31";
			foreach (var personalAddresses in CopyUserAddress)
			{
				personalAddresses.IsBusiness = false;
				if (personalAddresses.User_address == 1)
					personalAddresses.IsPersonal = true;
				else
					personalAddresses.IsPersonal = false;
			}
			ListOfDeliveryAddress = new ObservableCollection<Models.UserAddress>(CopyUserAddress);
			await Task.CompletedTask;
		}
		#endregion

		#region Show Business Addresses Command.
		private ICommand showBusinessAddressesCommand;
		public ICommand ShowBusinessAddressesCommand
		{
			get => showBusinessAddressesCommand ?? (showBusinessAddressesCommand = new Command(async () => await ExecuteShowBusinessAddressesCommand()));
		}
		private async Task ExecuteShowBusinessAddressesCommand()
		{
			IsPersonalOrBusiness = false;
			BtnPersonalBg = "#2A2A31"; 
			BtnBusinessBg = "#6263ED";
			foreach (var personalAddresses in CopyUserAddress)
			{
				personalAddresses.IsPersonal = false;
				if (personalAddresses.User_address == 0)
					personalAddresses.IsBusiness = true;
				else
					personalAddresses.IsBusiness = false;
			}
			ListOfDeliveryAddress = new ObservableCollection<Models.UserAddress>(CopyUserAddress);
			await Task.CompletedTask;
		}
		#endregion

		#region Search Command.
		private ICommand searchCommand;
		public ICommand SearchCommand
		{
			get => searchCommand ?? (searchCommand = new Command(async () => await ExecuteSearchCommand()));
		}
		private async Task ExecuteSearchCommand()
		{
			if (!string.IsNullOrWhiteSpace(SearchText))
			{
				string text = SearchText.ToLower();
				if (CopyUserAddress?.Count > 0)
				{
					List<Models.UserAddress> addresses = null;
					if (IsPersonalOrBusiness)
						addresses = CopyUserAddress.Where(x => x.AddressForSearch.ToLower().Contains(text) && x.IsPersonal == true).ToList();
					else
						addresses = CopyUserAddress.Where(x => x.AddressForSearch.ToLower().Contains(text) && x.IsBusiness == true).ToList();
					ListOfDeliveryAddress = new ObservableCollection<Models.UserAddress>(addresses);
				}
			}
			else
			{
				if (IsPersonalOrBusiness)
					ShowPersonalAddressesCommand.Execute(null);
				else
					ShowBusinessAddressesCommand.Execute(null);
			}
			await Task.CompletedTask;
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
			DeliveryAddressDetail = await service.DeliveryAddressDetailAsync(new Models.DeliveryAddressDetailRequest()
			{ Id = SelectedAddressId, UserAddress = Helper.Helper.UserOrCompanyAddress });
			Helper.Helper.DeliveryAddressDetail = DeliveryAddressDetail;
			SelectedAddressCommand.Execute(null);
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

		private bool isSingleDeliveryAddress = true;
		public bool IsSingleDeliveryAddress
		{
			get => isSingleDeliveryAddress;
			set
			{
				isSingleDeliveryAddress = value;
				OnPropertyChanged("IsSingleDeliveryAddress");
			}
		}

		private ObservableCollection<Models.UserAddress> listOfDeliveryAddress;
		public ObservableCollection<Models.UserAddress> ListOfDeliveryAddress
		{
			get { return listOfDeliveryAddress; }
			set
			{
				listOfDeliveryAddress = value;
				OnPropertyChanged("ListOfDeliveryAddress");
			}
		}

		public List<Models.UserAddress> CopyUserAddress { get; set; }

		private bool isSubmit;
		public bool IsSubmit
		{
			get { return isSubmit; }
			set
			{
				isSubmit = value;
				OnPropertyChanged("IsSubmit");
			}
		}

		private string btnPersonalBg = "#6263ED";
		public string BtnPersonalBg
		{
			get { return btnPersonalBg; }
			set
			{
				btnPersonalBg = value;
				OnPropertyChanged("BtnPersonalBg");
			}
		}

		private string btnBusinessBg = "#2A2A31";
		public string BtnBusinessBg
		{
			get { return btnBusinessBg; }
			set
			{
				btnBusinessBg = value;
				OnPropertyChanged("BtnBusinessBg");
			}
		}

		private string searchText;
		public string SearchText
		{
			get { return searchText; }
			set
			{
				searchText = value;
				OnPropertyChanged("SearchText");
			}
		}

		public bool IsPersonalOrBusiness { get; set; } = true;
		public int SelectedAddressId { get; set; }
		public string UserName => Helper.Helper.UserInfo.DisplayUserName;
		public string StreetAndNr => "Street & nr";
		#endregion
	}
}
