using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class OtherRoomsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public OtherRoomsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Other Room Info Command.
		private ICommand otherRoomInfoCommand;
		public ICommand OtherRoomInfoCommand
		{
			get => otherRoomInfoCommand ?? (otherRoomInfoCommand = new Command(async () => await ExecuteOtherRoomInfoCommand()));
		}
		private async Task ExecuteOtherRoomInfoCommand()
		{
			IsPageLoad = false;
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			OtherRoomInfo = await service.OtherRoomInfoAsync(new Models.OtherRoomInfoRequest()
			{
				ApartmentId = SelectedApartment.Id
			});
			DependencyService.Get<IProgressBar>().Hide();
			IsPageLoad = true;
		}
		#endregion

		#region Update Other Room Info Command.
		private ICommand updateOtherRoomInfoCommand;
		public ICommand UpdateOtherRoomInfoCommand
		{
			get => updateOtherRoomInfoCommand ?? (updateOtherRoomInfoCommand = new Command<string>(async (selectId) => await ExecuteUpdateOtherRoomInfoCommand(selectId)));
		}
		private async Task ExecuteUpdateOtherRoomInfoCommand(string selectId)
		{
			int id = System.Convert.ToInt32(selectId);
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			Models.UpdateOtherRoomInfoRequest updateRequest = new Models.UpdateOtherRoomInfoRequest()
			{
				ApartmentId = SelectedApartment.Id
			};
            switch (id)
            {
				case 1:
					OtherRoomInfo.HallRoomAvailable = !OtherRoomInfo.HallRoomAvailable;
					updateRequest.Id = 1;
					updateRequest.UpdateInfo = OtherRoomInfo.HallRoomAvailable ? 1 : 0;
					break;
				case 2:
					OtherRoomInfo.LivingRoomAvailable = !OtherRoomInfo.LivingRoomAvailable;
					updateRequest.Id = 2;
					updateRequest.UpdateInfo = OtherRoomInfo.LivingRoomAvailable ? 1 : 0;
					break;
				case 3:
					OtherRoomInfo.WorkRoomAvailable = !OtherRoomInfo.WorkRoomAvailable;
					updateRequest.Id = 3;
					updateRequest.UpdateInfo = OtherRoomInfo.WorkRoomAvailable ? 1 : 0;
					break;
				case 4:
					OtherRoomInfo.HobbyRoomAvailable = !OtherRoomInfo.HobbyRoomAvailable;
					updateRequest.Id = 4;
					updateRequest.UpdateInfo = OtherRoomInfo.HobbyRoomAvailable ? 1 : 0;
					break;
				case 5:
					OtherRoomInfo.SalRoomAvailable = !OtherRoomInfo.SalRoomAvailable;
					updateRequest.Id = 2;
					updateRequest.UpdateInfo = OtherRoomInfo.SalRoomAvailable ? 1 : 0;
					break;
				case 6:
					OtherRoomInfo.SalonRoomAvailable = !OtherRoomInfo.SalonRoomAvailable;
					updateRequest.Id = 6;
					updateRequest.UpdateInfo = OtherRoomInfo.SalonRoomAvailable ? 1 : 0;
					break;
				case 7:
					OtherRoomInfo.VestibuleRoomAvailable = !OtherRoomInfo.VestibuleRoomAvailable;
					updateRequest.Id = 7;
					updateRequest.UpdateInfo = OtherRoomInfo.VestibuleRoomAvailable ? 1 : 0;
					break;
				case 8:
					OtherRoomInfo.DiningRoomAvailable = !OtherRoomInfo.DiningRoomAvailable;
					updateRequest.Id = 8;
					updateRequest.UpdateInfo = OtherRoomInfo.DiningRoomAvailable ? 1 : 0;
					break;
				case 9:
					OtherRoomInfo.ChamberRoomAvailable = !OtherRoomInfo.ChamberRoomAvailable;
					updateRequest.Id = 9;
					updateRequest.UpdateInfo = OtherRoomInfo.ChamberRoomAvailable ? 1 : 0;
					break;
				case 10:
					OtherRoomInfo.BalconyAvailable = !OtherRoomInfo.BalconyAvailable;
					updateRequest.Id = 10;
					updateRequest.UpdateInfo = OtherRoomInfo.BalconyAvailable ? 1 : 0;
					break;
				case 11:
					OtherRoomInfo.TerraceAvailable = !OtherRoomInfo.TerraceAvailable;
					updateRequest.Id = 11;
					updateRequest.UpdateInfo = OtherRoomInfo.TerraceAvailable ? 1 : 0;
					break;
			}
            await service.UpdateOtherRoomInfoAsync(updateRequest);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private Models.OtherRoomInfoResponse otherRoomInfo;
		public Models.OtherRoomInfoResponse OtherRoomInfo
		{
			get => otherRoomInfo;
			set
			{
				otherRoomInfo = value;
				OnPropertyChanged("OtherRoomInfo");
			}
		}

		private bool isPageLoad = false;
		public bool IsPageLoad
		{
			get => isPageLoad;
			set
			{
				isPageLoad = value;
				OnPropertyChanged("IsPageLoad");
			}
		}
		public Models.UserDeliveryAddressesResponse SelectedApartment => Helper.Helper.SelectedUserDeliveryAddress;

        public Models.EditAddressResponse UserAddress => Helper.Helper.SelectedUserAddress;
        #endregion
    }
}
