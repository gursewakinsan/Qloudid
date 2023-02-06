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
			UserAddress = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Property Type Command.
		private ICommand propertyTypeCommand;
		public ICommand PropertyTypeCommand
		{
			get => propertyTypeCommand ?? (propertyTypeCommand = new Command(async () => await ExecutePropertyTypeCommand()));
		}
		private async Task ExecutePropertyTypeCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			var responsesPropertyTypeInfo = await service.PropertyTypeAsync();
			PropertyTypeInfo = new ObservableCollection<Models.PropertyTypeResponse>(responsesPropertyTypeInfo);
			SelectedPropertyType = PropertyTypeInfo[0];
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
				OwnershipDetail = OwnershipDetail,
				BoughtByYou = BoughtByYou,
				BoughtRentAllowed = BoughtRentAllowed,
				RentContractOnYou = RentContractOnYou,
				AllowedToRentOut = AllowedToRentOut
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
		public int OwnershipDetail { get; set; } = 1;
		public int BoughtByYou { get; set; } = 1;
		public int BoughtRentAllowed { get; set; } = 1;
		public int RentContractOnYou { get; set; } = 1;
		public int AllowedToRentOut { get; set; } = 1;
        public Models.UserDeliveryAddressesResponse SelectedApartment => Helper.Helper.SelectedUserDeliveryAddress;
		#endregion
	}
}