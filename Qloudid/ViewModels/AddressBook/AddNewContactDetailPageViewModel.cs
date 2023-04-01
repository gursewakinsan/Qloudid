using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
    public class AddNewContactDetailPageViewModel : BaseViewModel
    {
		#region Constructor.
		public AddNewContactDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			ListOfContactEmailAddress = new ObservableCollection<Models.ContactEmailDetail>();
			ListOfContactEmailAddress.Add(new Models.ContactEmailDetail() { Id = 1, IsRemove = false , EmailType = "Home" });

			ListOfContactPhoneNumber = new ObservableCollection<Models.ContactPhoneNumberDetail>();
			ListOfContactPhoneNumber.Add(new Models.ContactPhoneNumberDetail() { Id = 1, IsRemove = false, PhoneType = "Mobile" });

			ListOfContactAddressNumber = new ObservableCollection<Models.ContactAddressDetail>();
			ListOfContactAddressNumber.Add(new Models.ContactAddressDetail() { Id = 1, IsRemove = false });

			ListOfContactCard = new ObservableCollection<Models.ContactCardDetail>();
			ListOfContactCard.Add(new Models.ContactCardDetail() { Id = 1, IsRemove = false, CardType = "Visa card" });
		}
		#endregion

		#region Add More Email Address Command.
		private ICommand addMoreEmailAddressCommand;
		public ICommand AddMoreEmailAddressCommand
		{
			get => addMoreEmailAddressCommand ?? (addMoreEmailAddressCommand = new Command(() => ExecuteAddMoreEmailAddressCommand()));
		}
		private void ExecuteAddMoreEmailAddressCommand()
		{
			var id = ListOfContactEmailAddress.LastOrDefault().Id;
			ListOfContactEmailAddress.Add(new Models.ContactEmailDetail() { Id = id + 1, IsRemove = true, EmailType = "Home" });
		}
		#endregion

		#region Add More Phone Number Command.
		private ICommand addMorePhoneNumberCommand;
		public ICommand AddMorePhoneNumberCommand
		{
			get => addMorePhoneNumberCommand ?? (addMorePhoneNumberCommand = new Command(() => ExecuteAddMorePhoneNumberCommand()));
		}
		private void ExecuteAddMorePhoneNumberCommand()
		{
			var id = ListOfContactPhoneNumber.LastOrDefault().Id;
			ListOfContactPhoneNumber.Add(new Models.ContactPhoneNumberDetail() { Id = id + 1, IsRemove = true, PhoneType = "Mobile" });
		}
		#endregion

		#region Add More Address Command.
		private ICommand addMoreAddressCommand;
		public ICommand AddMoreAddressCommand
		{
			get => addMoreAddressCommand ?? (addMoreAddressCommand = new Command(() => ExecuteAddMoreAddressCommand()));
		}
		private void ExecuteAddMoreAddressCommand()
		{
			var id = ListOfContactAddressNumber.LastOrDefault().Id;
			ListOfContactAddressNumber.Add(new Models.ContactAddressDetail() { Id = id + 1, IsRemove = true });
		}
		#endregion

		#region Add More Card Command.
		private ICommand addMoreCardCommand;
		public ICommand AddMoreCardCommand
		{
			get => addMoreCardCommand ?? (addMoreCardCommand = new Command(() => ExecuteAddMoreCardCommand()));
		}
		private void ExecuteAddMoreCardCommand()
		{
			var id = ListOfContactCard.LastOrDefault().Id;
			ListOfContactCard.Add(new Models.ContactCardDetail() { Id = id + 1, IsRemove = true , CardType= "Visa card"});
			}
		#endregion

		#region Submit Contact Info Command.
		private ICommand submitContactInfoCommand;
		public ICommand SubmitContactInfoCommand
		{
			get => submitContactInfoCommand ?? (submitContactInfoCommand = new Command(async () => await ExecuteSubmitContactInfoCommand()));
		}
		private async Task ExecuteSubmitContactInfoCommand()
		{
            foreach (var contactEmail in ListOfContactEmailAddress)
            {
				if (string.IsNullOrWhiteSpace(contactEmail.EmailAddress))
				{
					await Helper.Alert.DisplayAlert("Email is required.");
					return;
				}
            }
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.ContactEmailDetail> listOfContactEmailAddress;
		public ObservableCollection<Models.ContactEmailDetail> ListOfContactEmailAddress
		{
			get => listOfContactEmailAddress;
			set
			{
				listOfContactEmailAddress = value;
				OnPropertyChanged("ListOfContactEmailAddress");
			}
		}

		private ObservableCollection<Models.ContactPhoneNumberDetail> listOfContactPhoneNumber;
		public ObservableCollection<Models.ContactPhoneNumberDetail> ListOfContactPhoneNumber
		{
			get => listOfContactPhoneNumber; 
			set
			{
				listOfContactPhoneNumber = value;
				OnPropertyChanged("ListOfContactPhoneNumber");
			}
		}

		private ObservableCollection<Models.ContactAddressDetail> listOfContactAddressNumber;
		public ObservableCollection<Models.ContactAddressDetail> ListOfContactAddressNumber
		{
			get => listOfContactAddressNumber;
			set
			{
				listOfContactAddressNumber = value;
				OnPropertyChanged("ListOfContactAddressNumber");
			}
		}

		private ObservableCollection<Models.ContactCardDetail> listOfContactCard;
		public ObservableCollection<Models.ContactCardDetail> ListOfContactCard
		{
			get => listOfContactCard;
			set
			{
				listOfContactCard = value;
				OnPropertyChanged("ListOfContactCard");
			}
		}
		#endregion
	}
}
