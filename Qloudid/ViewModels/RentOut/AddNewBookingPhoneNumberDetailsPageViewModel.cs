using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
    public class AddNewBookingPhoneNumberDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public AddNewBookingPhoneNumberDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
			CountryList = new ObservableCollection<Models.Country>(Helper.Helper.CountryList.OrderBy(x => x.CountryCode));
			SelectedCountry = CountryList[0];
		}
		#endregion

		#region Verify User Using Phone Detail Command.
		private ICommand verifyUserUsingPhoneDetailCommand;
		public ICommand VerifyUserUsingPhoneDetailCommand
		{
			get => verifyUserUsingPhoneDetailCommand ?? (verifyUserUsingPhoneDetailCommand = new Command(async () => await ExecuteVerifyUserUsingPhoneDetailCommand()));
		}
		private async Task ExecuteVerifyUserUsingPhoneDetailCommand()
		{
			if (string.IsNullOrWhiteSpace(PhoneNumber))
				await Helper.Alert.DisplayAlert("Phone number is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IRentOutService service = new RentOutService();
				var response = await service.VerifyUserUsingPhoneDetailAsync(new Models.VerifyUserUsingPhoneDetailRequest()
				{
					ApartmentId = Address.Id,
					CountryId = SelectedCountry.Id,
					PhoneNumber = PhoneNumber
				});
				if (response.Id > 0)
				{
					Helper.Helper.SendBookingRequestInfo.GuestUserId = response.Id;
					await Navigation.PushAsync(new Views.RentOut.AccountFoundPage($"{response.FirstName} {response.LastName}, {response.CountryName}"));
				}
				else
					await Navigation.PushAsync(new Views.RentOut.NoAccountFoundPage($"{SelectedCountry.DisplayCountryCode} {PhoneNumber}"));
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
		#endregion
	}
}