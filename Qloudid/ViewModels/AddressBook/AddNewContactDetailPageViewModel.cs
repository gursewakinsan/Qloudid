using System;
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
			ListOfContactEmailAddress = new ObservableCollection<Models.ContactEmailDetail>();
			ListOfContactEmailAddress.Add(new Models.ContactEmailDetail()
			{
				Id = 1,
				IsRemove = true,
				EmailType = "Home",
				UserId = Helper.Helper.UserId
			});

			ListOfContactPhoneNumber = new ObservableCollection<Models.ContactPhoneNumberDetail>();
			ListOfContactPhoneNumber.Add(new Models.ContactPhoneNumberDetail()
			{
				Id = 1,
				IsRemove = true,
				PhoneType = "Mobile",
				UserId = Helper.Helper.UserId,
				CountryList = Helper.Helper.CountryList.OrderBy(x => x.CountryCode).ToList(),
				SelectedCountry = Helper.Helper.CountryList[0] });

			ListOfContactAddressNumber = new ObservableCollection<Models.ContactAddressDetail>();
			ListOfContactAddressNumber.Add(new Models.ContactAddressDetail() { Id = 1, IsRemove = true, CountryList = Helper.Helper.CountryList, SelectedCountry = Helper.Helper.CountryList[0] });

			ListOfContactCard = new ObservableCollection<Models.ContactCardDetail>();
			ListOfContactCard.Add(new Models.ContactCardDetail() { Id = 1, IsRemove = true, CardType = "Visa card" });

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
				EmailType = "Home",
				UserId = Helper.Helper.UserId
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
			ListOfContactPhoneNumber.Add(new Models.ContactPhoneNumberDetail()
			{
				Id = id + 1,
				IsRemove = true,
				PhoneType = "Mobile",
				UserId = Helper.Helper.UserId,
				CountryList = Helper.Helper.CountryList.OrderBy(x => x.CountryCode).ToList(),
				SelectedCountry = Helper.Helper.CountryList[0]});
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
			else if (CroppedImage1 == null)
			{
				await Helper.Alert.DisplayAlert("Please select photo.");
				return;
			}
			foreach (var contactEmail in ListOfContactEmailAddress)
            {
				if (string.IsNullOrWhiteSpace(contactEmail.EmailAddress))
				{
					await Helper.Alert.DisplayAlert("Email is required.");
					contactEmail.IsError = 1;
					return;
				}
				else if (!Helper.Helper.IsValid(contactEmail.EmailAddress))
				{
					await Helper.Alert.DisplayAlert("Email is valid.");
					contactEmail.IsError = 1;
					return;
				}
				else
					contactEmail.IsError = 0;
			}

			foreach (var contactPhone in ListOfContactPhoneNumber)
			{
				if (string.IsNullOrWhiteSpace(contactPhone.PhoneNumber))
				{
					await Helper.Alert.DisplayAlert("Phone number is required.");
					contactPhone.IsError = 1;
					return;
				}
				else
					contactPhone.IsError = 0;
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
			DependencyService.Get<IProgressBar>().Show();
			IAddressBookService service = new AddressBookService();
			var emailResponse = await service.CheckValidEmailsAsync(ListOfContactEmailAddress);
			if (emailResponse?.Count > 0)
			{
				var emailData = emailResponse.FirstOrDefault(x => x.IsError == 1);
				if (emailData != null)
				{
					ListOfContactEmailAddress = emailResponse;
					DependencyService.Get<IProgressBar>().Hide();
					return;
				}
			}

			var phoneResponse = await service.CheckValidPhoneNumbersAsync(ListOfContactPhoneNumber);
			if (phoneResponse?.Count > 0)
			{
				var phoneData = phoneResponse.FirstOrDefault(x => x.IsError == 1);
				if (phoneData != null)
				{
					ListOfContactPhoneNumber = phoneResponse;
					DependencyService.Get<IProgressBar>().Hide();
					return;
				}
			}

			Models.AddContactInfoRequest model = new Models.AddContactInfoRequest()
			{
				UserId = Helper.Helper.UserId,
				FirstName = FirstName,
				LastName = LastName,
				ImageData = Convert.ToBase64String(CroppedImage1)
			};
            foreach (var emailDetail in ListOfContactEmailAddress)
            {
				if (model.EmailInfo == null)
					model.EmailInfo = new List<Models.EmailInfo>();
				model.EmailInfo.Add(new Models.EmailInfo()
				{
					EmailType = emailDetail.EmailType,
					EmailAddress = emailDetail.EmailAddress
				});
			}
			foreach (var phoneNumberDetail in ListOfContactPhoneNumber)
			{
				if (model.PhoneInfo == null)
					model.PhoneInfo = new List<Models.PhoneInfo>();
				model.PhoneInfo.Add(new Models.PhoneInfo()
				{
					CountryCode = phoneNumberDetail.SelectedCountry.Id,
					PhoneType = phoneNumberDetail.PhoneType,
					PhoneNumber = phoneNumberDetail.PhoneNumber,

				});
			}
			foreach (var contactAddressDetail in ListOfContactAddressNumber)
			{
				if (model.AddressInfo == null)
					model.AddressInfo = new List<Models.AddressInfo>();
				model.AddressInfo.Add(new Models.AddressInfo()
				{
					Address = contactAddressDetail.Address,
					CodeNumber = contactAddressDetail.Number,
					ZipCode = contactAddressDetail.ZipCode,
					City = contactAddressDetail.City,
					State = contactAddressDetail.State,
					CountryCode = contactAddressDetail.SelectedCountry.Id,
				});
			}
			foreach (var cardDetail in ListOfContactCard)
			{
				if (model.CardInfo == null)
					model.CardInfo = new List<Models.CardInfo>();
				model.CardInfo.Add(new Models.CardInfo()
				{
					CardType = cardDetail.CardType,
					CardNumber = cardDetail.CardNumber
				});
			}
			
			await service.AddNewContactInfoAsync(model);

			Application.Current.MainPage.Navigation.PushAsync(new Views.AddressBook.AddressBookListPage());
			DependencyService.Get<IProgressBar>().Hide();
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

		public byte[] CroppedImage1;
		#endregion
	}
}
