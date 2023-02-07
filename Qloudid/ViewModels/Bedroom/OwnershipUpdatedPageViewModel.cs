using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
    public class OwnershipUpdatedPageViewModel : BaseViewModel
    {
		#region Constructor.
		public OwnershipUpdatedPageViewModel(INavigation navigation)
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

			IBedroomService bedroomService = new BedroomService();
			var responsesPropertyTypeInfo = await bedroomService.PropertyTypeAsync();
			PropertyTypeInfo = new ObservableCollection<Models.PropertyTypeResponse>(responsesPropertyTypeInfo);
			SelectedPropertyType = PropertyTypeInfo.FirstOrDefault(x => x.Id == UserAddress.PropertyType);
			OwnershipDetail = response.OwnershipDetail - 1;
			BoughtByYou = response.BoughtByYou == 1 ? 0 : 1;
			BoughtRentAllowed = response.BoughtRentAllowed == 1 ? 0 : 1;
			RentContractOnYou = response.RentContractOnYou == 1 ? 0 : 1;
			AllowedToRentOut = response.AllowedToRentOut == 1 ? 0 : 1;

			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Owner Info Command.
		private ICommand updateOwnerInfoCommand;
		public ICommand UpdateOwnerInfoCommand
		{
			get => updateOwnerInfoCommand ?? (updateOwnerInfoCommand = new Command(async () => await ExecuteUpdateOwnerInfoCommand()));
		}
		private async Task ExecuteUpdateOwnerInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			var responses = await service.UpdateOwnerInfoAsync(new Models.UpdateOwnerInfoRequest()
			{
				ApartmentId = SelectedApartment.Id,
				PropertyType = SelectedPropertyType.Id,
				OwnershipDetail = OwnershipDetail + 1,
				BoughtByYou = BoughtByYou == 0 ? 1 : 0,
				BoughtRentAllowed = BoughtRentAllowed == 0 ? 1 : 0,
				RentContractOnYou = RentContractOnYou == 0 ? 1 : 0,
				AllowedToRentOut = AllowedToRentOut == 0 ? 1 : 0
			});
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.PropertyTypeResponse> propertyTypeInfo;
		public ObservableCollection<Models.PropertyTypeResponse> PropertyTypeInfo
		{
			get => propertyTypeInfo;
			set
			{
				propertyTypeInfo = value;
				OnPropertyChanged("PropertyTypeInfo");
			}
		}

		private Models.PropertyTypeResponse selectedPropertyType;
		public Models.PropertyTypeResponse SelectedPropertyType
		{
			get => selectedPropertyType;
			set
			{
				selectedPropertyType = value;
				OnPropertyChanged("SelectedPropertyType");
			}
		}

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

		public int ownershipDetail;
		public int OwnershipDetail
		{
			get => ownershipDetail;
			set
			{
				ownershipDetail = value;
				OnPropertyChanged("OwnershipDetail");
			}
		}

		public int boughtByYou;
		public int BoughtByYou
		{
			get => boughtByYou;
			set
			{
				boughtByYou = value;
				OnPropertyChanged("BoughtByYou");
			}
		}

		public int boughtRentAllowed;
		public int BoughtRentAllowed
		{
			get => boughtRentAllowed;
			set
            {
                boughtRentAllowed = value;
				OnPropertyChanged("BoughtRentAllowed");
            }
		}

		public int rentContractOnYou;
		public int RentContractOnYou
		{
			get => rentContractOnYou; 
			set
            {
                rentContractOnYou = value;
				OnPropertyChanged("RentContractOnYou");
			}
		}

		public int allowedToRentOut;
		public int AllowedToRentOut
		{
			get => allowedToRentOut; set
            {
                allowedToRentOut = value;
                OnPropertyChanged("AllowedToRentOut");
            }
		}
		public Models.UserDeliveryAddressesResponse SelectedApartment => Helper.Helper.SelectedUserDeliveryAddress;
		#endregion
	}
}
