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
			int index = 0;
			var list = new List<Models.DeliveryAddressInfo>();
			if (response?.UserAddress?.Count > 0)
			{
				Models.DeliveryAddressInfo listPersonal = new Models.DeliveryAddressInfo();
				foreach (var item in response.UserAddress)
				{
					item.FirstLetterNameBg = Helper.Helper.ColorList[index];
					index = index + 1;
					listPersonal.Add(item);
				}
				listPersonal.Heading = "Personal";
				list.Add(listPersonal);
			}

			if (response?.CompanyAddress?.Count > 0)
			{
				Models.DeliveryAddressInfo listCompanies = new Models.DeliveryAddressInfo();
				foreach (var item in response.CompanyAddress)
				{
					item.FirstLetterNameBg = Helper.Helper.ColorList[index];
					index = index + 1;
					listCompanies.Add(item);
				}
				listCompanies.Heading = "Companies";
				list.Add(listCompanies);
			}
			ListOfDeliveryAddress = list;
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
			IDashboardService service = new DashboardService();
			Models.EditAddressResponse address = new Models.EditAddressResponse()
			{
				Id = DeliveryAddressDetail.Id,
				DeliveredAt = Helper.Helper.UserOrCompanyAddress > 1 ? 0 : 1,
				CertificateKey = Helper.Helper.QrCertificateKey
			};
			int response = await service.UpdateCompanyAddressAsync(address);
			Helper.Helper.DeliveryAddressDetail = DeliveryAddressDetail;
			if (Helper.Helper.IsEditDeliveryAddressFromInvoicing)
			{
				Helper.Helper.IsEditDeliveryAddressFromInvoicing = false;
				await Navigation.PushAsync(new Views.ReadOnlyInvoicingAddressPage());
			}
			else if (Helper.Helper.IsEditAddressFromYourSignature)
			{
				Helper.Helper.IsEditAddressFromYourSignature = false;
				await Navigation.PushAsync(new Views.YourSignaturePage());
			}
			else
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

		private List<Models.DeliveryAddressInfo> listOfDeliveryAddress;
		public List<Models.DeliveryAddressInfo> ListOfDeliveryAddress
		{
			get { return listOfDeliveryAddress; }
			set
			{
				listOfDeliveryAddress = value;
				OnPropertyChanged("ListOfDeliveryAddress");
			}
		}

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

		public int SelectedAddressId { get; set; }
		public string UserName => Helper.Helper.UserInfo.DisplayUserName;
		public string StreetAndNr => "Street & nr";
		#endregion
	}
}
