using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class AddNewContactDetailPageViewModel : BaseViewModel
    {
		#region Constructor.
		public AddNewContactDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			EmailTypeInfo = new List<Models.EmailTypeInfo>();
			EmailTypeInfo.Add(new Models.EmailTypeInfo() { Id = 1, EmailType = "Home" });
			EmailTypeInfo.Add(new Models.EmailTypeInfo() { Id = 2, EmailType = "Work" });
			EmailTypeInfo.Add(new Models.EmailTypeInfo() { Id = 3, EmailType = "School" });
			EmailTypeInfo.Add(new Models.EmailTypeInfo() { Id = 4, EmailType = "iCloud" });
			EmailTypeInfo.Add(new Models.EmailTypeInfo() { Id = 5, EmailType = "Other" });
			EmailTypeInfo.Add(new Models.EmailTypeInfo() { Id = 6, EmailType = "Primary" });

			ListOfContactEmailAddress = new ObservableCollection<Models.ContactEmailDetail>();
			ListOfContactEmailAddress.Add(new Models.ContactEmailDetail()
			{
				Id = 1,
				IsRemove = false,
				EmailTypeInfoList = EmailTypeInfo,
				SelectedEmailTypeInfo = EmailTypeInfo[0]
			});

			ListOfContactPhoneNumber = new ObservableCollection<Models.ContactPhoneNumberDetail>();
			ListOfContactPhoneNumber.Add(new Models.ContactPhoneNumberDetail() { Id = 1, IsRemove = false, PhoneType = "Mobile", CountryList = Helper.Helper.CountryList, SelectedCountry = Helper.Helper.CountryList[0] });

			ListOfContactAddressNumber = new ObservableCollection<Models.ContactAddressDetail>();
			ListOfContactAddressNumber.Add(new Models.ContactAddressDetail() { Id = 1, IsRemove = false, CountryList = Helper.Helper.CountryList, SelectedCountry = Helper.Helper.CountryList[0] });

			ListOfContactCard = new ObservableCollection<Models.ContactCardDetail>();
			ListOfContactCard.Add(new Models.ContactCardDetail() { Id = 1, IsRemove = false, CardType = "Visa card" });

			var res = Helper.Helper.CountryList;
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
			ListOfContactEmailAddress.Add(new Models.ContactEmailDetail()
			{
				Id = id + 1,
				IsRemove = true,
				EmailTypeInfoList = EmailTypeInfo,
				SelectedEmailTypeInfo = EmailTypeInfo[0]
			});
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
			ListOfContactPhoneNumber.Add(new Models.ContactPhoneNumberDetail() { Id = id + 1, IsRemove = true, PhoneType = "Mobile", CountryList = Helper.Helper.CountryList, SelectedCountry = Helper.Helper.CountryList[0]});
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
			ListOfContactAddressNumber.Add(new Models.ContactAddressDetail() { Id = id + 1, IsRemove = true, CountryList = Helper.Helper.CountryList, SelectedCountry = Helper.Helper.CountryList[0] });
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
			ListOfContactCard.Add(new Models.ContactCardDetail() { Id = id + 1, IsRemove = true, CardType = "Visa card" });
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
			if (string.IsNullOrWhiteSpace(FirstName))
			{
				await Helper.Alert.DisplayAlert("First name is required.");
				return;
			}
			else if (string.IsNullOrWhiteSpace(LastName))
			{
				await Helper.Alert.DisplayAlert("Last name is required.");
				return;
			}
			foreach (var contactEmail in ListOfContactEmailAddress)
            {
				if (string.IsNullOrWhiteSpace(contactEmail.EmailAddress))
				{
					await Helper.Alert.DisplayAlert("Email is required.");
					return;
				}
				else if (!Helper.Helper.IsValid(contactEmail.EmailAddress))
				{
					await Helper.Alert.DisplayAlert("Email is valid.");
					return;
				}
			}

			foreach (var contactPhone in ListOfContactPhoneNumber)
			{
				if (string.IsNullOrWhiteSpace(contactPhone.PhoneNumber))
				{
					await Helper.Alert.DisplayAlert("Phone number is required.");
					return;
				}
			}

			foreach (var contactAddress in ListOfContactAddressNumber)
			{
				if (string.IsNullOrWhiteSpace(contactAddress.Address))
				{
					await Helper.Alert.DisplayAlert("Address is required.");
					return;
				}
				else if (string.IsNullOrWhiteSpace(contactAddress.Number))
				{
					await Helper.Alert.DisplayAlert("Number is required.");
					return;
				}
				else if (string.IsNullOrWhiteSpace(contactAddress.ZipCode))
				{
					await Helper.Alert.DisplayAlert("Zip code is required.");
					return;
				}
				else if (string.IsNullOrWhiteSpace(contactAddress.City))
				{
					await Helper.Alert.DisplayAlert("City is required.");
					return;
				}
				else if (string.IsNullOrWhiteSpace(contactAddress.State))
				{
					await Helper.Alert.DisplayAlert("State is required.");
					return;
				}
			}

			foreach (var contactCard in ListOfContactCard)
			{
				if (string.IsNullOrWhiteSpace(contactCard.CardNumber))
				{
					await Helper.Alert.DisplayAlert("Card number is required.");
					return;
				}
			}

			Models.AddContactInfoRequest model = new Models.AddContactInfoRequest()
			{
				FirstName = FirstName,
				LastName = LastName
			};
            foreach (var emailDetail in ListOfContactEmailAddress)
            {
				model.EmailTypeInfo.Add(new Models.EmailTypeInfo()
				{
					 Id = emailDetail.SelectedEmailTypeInfo.Id,
					  EmailType
				});
			}
		}
		#endregion

		#region Properties.
		private string firstName;
		public string FirstName
		{
			get => firstName;
			set
			{
				firstName = value;
				OnPropertyChanged("FirstName");
			}
		}

		private string lastName;
		public string LastName
		{
			get => lastName;
			set
			{
				lastName = value;
				OnPropertyChanged("LastName");
			}
		}

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

        public List<Models.EmailTypeInfo> EmailTypeInfo { get; set; }
		#endregion
	}
}
