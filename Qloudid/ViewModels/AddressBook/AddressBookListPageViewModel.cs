using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class AddressBookListPageViewModel : BaseViewModel
    {
		#region Constructor.
		public AddressBookListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			 var userAddressBookContacts = new List<Models.UserAddressBookContactsResponse>();
            for (int i = 0; i < 10; i++)
            {
				userAddressBookContacts.Add(new Models.UserAddressBookContactsResponse()
				{
					Title = $"Title {i}",
					SubTitle = $"SubTitle {i}"
				});
			}
			UserAddressBookContacts = userAddressBookContacts;
		}
		#endregion

		#region Get User Address Book Contacts Command.
		private ICommand getUserAddressBookContactsCommand;
		public ICommand GetUserAddressBookContactsCommand
		{
			get => getUserAddressBookContactsCommand ?? (getUserAddressBookContactsCommand = new Command(async () => await ExecuteGetUserAddressBookContactsCommand()));
		}
		private async Task ExecuteGetUserAddressBookContactsCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IAddressBookService service = new AddressBookService();
			UserAddressBookContacts = await service.GetUserAddressBookContactsAsync(new Models.UserAddressBookContactsRequest()
			{
				UserId = Helper.Helper.UserId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Add New Contact Detail Page Command.
		private ICommand addNewContactDetailPageCommand;
		public ICommand AddNewContactDetailPageCommand
		{
			get => addNewContactDetailPageCommand ?? (addNewContactDetailPageCommand = new Command(async () => await ExecuteAddNewContactDetailPageCommand()));
		}
		private async Task ExecuteAddNewContactDetailPageCommand()
		{
			await Navigation.PushAsync(new Views.AddressBook.AddNewContactDetailPage());
		}
		#endregion

		#region Properties.
		private List<Models.UserAddressBookContactsResponse> userAddressBookContacts;
		public List<Models.UserAddressBookContactsResponse> UserAddressBookContacts
		{
			get => userAddressBookContacts;
			set
			{
				userAddressBookContacts = value;
				OnPropertyChanged("UserAddressBookContacts");
			}
		}
		#endregion
	}
}
