using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class UserContactDetailsInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public UserContactDetailsInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region User Addess Book Contact Detail Info Command.
		private ICommand userAddessBookContactDetailInfoCommand;
		public ICommand UserAddessBookContactDetailInfoCommand
		{
			get => userAddessBookContactDetailInfoCommand ?? (userAddessBookContactDetailInfoCommand = new Command(async () => await ExecuteUserAddessBookContactDetailInfoCommand()));
		}
		private async Task ExecuteUserAddessBookContactDetailInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IAddressBookService service = new AddressBookService();
			UserAddessBookContactDetailInfo = await service.UserAddessBookContactDetailInfoAsync(new Models.UserAddessBookContactDetailInfoRequest()
			{
				ContactId = SelectedUser.Id,
				IsUser = SelectedUser.IsUser
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private Models.UserAddessBookContactDetailInfoResponse userAddessBookContactDetailInfo;
		public Models.UserAddessBookContactDetailInfoResponse UserAddessBookContactDetailInfo
		{
			get => userAddessBookContactDetailInfo;
			set
			{
				userAddessBookContactDetailInfo = value;
				OnPropertyChanged("UserAddessBookContactDetailInfo");
			}
		}

        public Models.UserAddressBookContactsResponse SelectedUser { get; set; }
        #endregion
    }
}
