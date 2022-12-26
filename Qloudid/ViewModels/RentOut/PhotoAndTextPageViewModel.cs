using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class PhotoAndTextPageViewModel : BaseViewModel
	{
		#region Constructor.
		public PhotoAndTextPageViewModel(INavigation navigation)
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
			Address = response;
			Helper.Helper.SelectedUserAddress = Address;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Photos Updated Page Command.
		private ICommand photosUpdatedPageCommand;
		public ICommand PhotosUpdatedPageCommand
		{
			get => photosUpdatedPageCommand ?? (photosUpdatedPageCommand = new Command(async () => await ExecutePhotosUpdatedPageCommand()));
		}
		private async Task ExecutePhotosUpdatedPageCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.PhotosUpdatedPage());
		}
		#endregion

		#region Nick Name Updated Page Command.
		private ICommand nickNameUpdatedPageCommand;
		public ICommand NickNameUpdatedPageCommand
		{
			get => nickNameUpdatedPageCommand ?? (nickNameUpdatedPageCommand = new Command(async () => await ExecuteNickNameUpdatedPageCommand()));
		}
		private async Task ExecuteNickNameUpdatedPageCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.NickNameUpdatedPage());
		}
		#endregion

		#region Head Line Updated Page Command.
		private ICommand headLineUpdatedPageCommand;
		public ICommand HeadLineUpdatedPageCommand
		{
			get => headLineUpdatedPageCommand ?? (headLineUpdatedPageCommand = new Command(async () => await ExecuteHeadLineUpdatedPageCommand()));
		}
		private async Task ExecuteHeadLineUpdatedPageCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.HeadLineUpdatedPage());
		}
		#endregion

		#region Description Updated Page Command.
		private ICommand descriptionUpdatedPageCommand;
		public ICommand DescriptionUpdatedPageCommand
		{
			get => descriptionUpdatedPageCommand ?? (descriptionUpdatedPageCommand = new Command(async () => await ExecuteDescriptionUpdatedPageCommand()));
		}
		private async Task ExecuteDescriptionUpdatedPageCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.DescriptionUpdatedPage());
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
