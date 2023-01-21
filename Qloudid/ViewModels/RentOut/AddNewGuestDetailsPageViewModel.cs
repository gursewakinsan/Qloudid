using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
    public class AddNewGuestDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public AddNewGuestDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
			CountryList = new ObservableCollection<Models.Country>(Helper.Helper.CountryList);
			SelectedCountry = CountryList[0];
		}
		#endregion

		#region Add New Guest Details Command.
		private ICommand addNewGuestDetailsCommand;
		public ICommand AddNewGuestDetailsCommand
		{
			get => addNewGuestDetailsCommand ?? (addNewGuestDetailsCommand = new Command(async () => await ExecuteAddNewGuestDetailsCommand()));
		}
		private async Task ExecuteAddNewGuestDetailsCommand()
		{
			if (string.IsNullOrWhiteSpace(FirstName))
				await Helper.Alert.DisplayAlert("First name is required.");
			else if (string.IsNullOrWhiteSpace(LastName))
				await Helper.Alert.DisplayAlert("Last name is required.");
			else if (string.IsNullOrWhiteSpace(PhoneNumber))
				await Helper.Alert.DisplayAlert("Phone number is required.");
			else if (PhoneNumber.StartsWith("0"))
				await Helper.Alert.DisplayAlert("Phone number cannot be start from zero.");
			else if (string.IsNullOrWhiteSpace(EmailAddress))
				await Helper.Alert.DisplayAlert("Email address is required.");
			else if (!Helper.Helper.IsValid(EmailAddress))
				await Helper.Alert.DisplayAlert("Please enter valid email address.");
			else if (string.IsNullOrWhiteSpace(IDNumber))
				await Helper.Alert.DisplayAlert("Passport number is required.");
			else if (UserImageDataFront == null)
				await Helper.Alert.DisplayAlert("Passport front side photo is required.");
			else if (UserImageDataBack == null)
				await Helper.Alert.DisplayAlert("Passport back side photo is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IRentOutService service = new RentOutService();
				int phoneInfoResponse = await service.CheckPhoneInfoAsync(new Models.CheckPhoneInfoRequest()
				{
					CountryId = SelectedCountry.Id,
					PhoneNumber = PhoneNumber
				});
				if (phoneInfoResponse == 0)
				{
					int emailInfoResponse = await service.CheckEmailInfoAsync(new Models.CheckEmailInfoRequest()
					{
						Email = EmailAddress
					});
					if (emailInfoResponse == 0)
					{
						IMyCountriesService myCountriesService = new MyCountriesService();
						int passportInfoResponse = await myCountriesService.CheckPassportInfoAsync(new Models.CheckPassportInfoRequest()
						{
							CountryId = SelectedCountry.Id,
							IdNumber = IDNumber
						});
						if (passportInfoResponse != 0)
							await Helper.Alert.DisplayAlert("Passport number already in use.");
						else
						{
							int guestUserId = await service.CreateUserAsync(new Models.CreateUserRequest()
							{
								FirstName = FirstName,
								LastName = LastName,
								Email = EmailAddress,
								PCountry = SelectedCountry.Id,
								PNumber = PhoneNumber
							});

							int addIdentificatorResponse = await service.AddIdentificatorRegisteredUserAsync(new Models.AddIdentificatorRegisteredUserRequest()
							{
								CountryId = SelectedCountry.Id,
								IssueDate = $"{SelectedIssueDate.Day}/{SelectedIssueDate.Month}/{SelectedIssueDate.Year}",
								ExpiryDate = $"{SelectedExpiryDate.Day}/{SelectedExpiryDate.Month}/{SelectedExpiryDate.Year}",
								GuestUserId = guestUserId,
								IdentificatorId = 1,
								IdentificatorText = IDNumber
							});

							await service.AddIdentificatorImagesRegisteredUserAsync(new Models.AddIdentificatorImagesRegisteredUserRequest()
							{
								ImageId = 1,
								GuestUserId = guestUserId,
								ImageData = Convert.ToBase64String(UserImageDataFront)
							});

							await service.AddIdentificatorImagesRegisteredUserAsync(new Models.AddIdentificatorImagesRegisteredUserRequest()
							{
								ImageId = 2,
								GuestUserId = guestUserId,
								ImageData = Convert.ToBase64String(UserImageDataBack)
							});

							await service.SendBookingToNewUserAsync(new Models.SendBookingToNewUserRequest()
							{
								GuestUserId = guestUserId,
								
							});
							await Navigation.PushAsync(new Views.RentOut.PaymentsPersonalPage());
						}
					}
					else
						await Helper.Alert.DisplayAlert("Email already in use.");
				}
				else
					await Helper.Alert.DisplayAlert("Phone number already in use.");
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

		private ObservableCollection<Models.Country> countryList;
		public ObservableCollection<Models.Country> CountryList
		{
			get => countryList;
			set
			{
				countryList = value;
				OnPropertyChanged("CountryList");
			}
		}

		private Models.Country selectedCountry;
		public Models.Country SelectedCountry
		{
			get => selectedCountry;
			set
			{
				selectedCountry = value;
				OnPropertyChanged("SelectedCountry");
			}
		}

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

		private string phoneNumber;
		public string PhoneNumber
		{
			get => phoneNumber;
			set
			{
				phoneNumber = value;
				OnPropertyChanged("PhoneNumber");
			}
		}

		private string emailAddress;
		public string EmailAddress
		{
			get => emailAddress;
			set
			{
				emailAddress = value;
				OnPropertyChanged("EmailAddress");
			}
		}

		private string iDNumber;
		public string IDNumber
		{
			get => iDNumber;
			set
			{
				iDNumber = value;
				OnPropertyChanged("IDNumber");
			}
		}

		

		public DateTime BindIssueMinimumDate => DateTime.Today.AddYears(-70);
		public DateTime BindIssueMaximumDate => DateTime.Today.AddDays(-1);
		public DateTime SelectedIssueDate { get; set; } = DateTime.Today;
		public DateTime BindExpiryMinimumDate => DateTime.Today;
		public DateTime BindExpiryMaximumDate => DateTime.Today.AddYears(70);
		public DateTime SelectedExpiryDate { get; set; } = DateTime.Today;
		public byte[] UserImageDataFront { get; set; }
		public byte[] UserImageDataBack { get; set; }
		#endregion
	}
}