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
			var responses = await service.GetUserAddressBookContactsAsync(new Models.UserAddressBookContactsRequest()
			{
				UserId = Helper.Helper.UserId
			});
            foreach (var item in responses)
				item.Relation = "Friend";
			Models.UserAddressBookContactsResponse user = new Models.UserAddressBookContactsResponse()
			{
				ContactFirstName = Helper.Helper.UserInfo.first_name,
				ContactLastName = Helper.Helper.UserInfo.last_name,
				UserImage = Helper.Helper.UserInfo.UserImage,
				Relation = "You"
			};
			responses.Insert(0, user);
			UserAddressBookContacts = responses;
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

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage.Navigation.PushAsync(new Views.AppStorePage());
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
