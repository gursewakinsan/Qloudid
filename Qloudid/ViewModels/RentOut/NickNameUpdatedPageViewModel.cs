using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class NickNameUpdatedPageViewModel : BaseViewModel
    {
		#region Constructor.
		public NickNameUpdatedPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Update Nick Name Command.
		private ICommand updateNickNameCommand;
		public ICommand UpdateNickNameCommand
		{
			get => updateNickNameCommand ?? (updateNickNameCommand = new Command(async () => await ExecuteUpdateNickNameCommand()));
		}
		private async Task ExecuteUpdateNickNameCommand()
		{
			if (string.IsNullOrWhiteSpace(Address.PropertyNickname))
				await Helper.Alert.DisplayAlert("Nick name is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IRentOutService service = new RentOutService();
				await service.UpdateNicknameAsync(new Models.UpdateTextOrAvailabilityRequest()
				{
					ApartmentId = Address.Id,
					PropertyNickName = Address.PropertyNickname
				});
				await Navigation.PopAsync();
				DependencyService.Get<IProgressBar>().Hide();
			}
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
