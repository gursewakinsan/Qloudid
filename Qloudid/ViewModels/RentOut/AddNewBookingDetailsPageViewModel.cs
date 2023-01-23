using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AddNewBookingDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public AddNewBookingDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Check Availablity Dates Command.
		private ICommand checkAvailablityDatesCommand;
		public ICommand CheckAvailablityDatesCommand
		{
			get => checkAvailablityDatesCommand ?? (checkAvailablityDatesCommand = new Command(async () => await ExecuteCheckAvailablityDatesCommand()));
		}
		private async Task ExecuteCheckAvailablityDatesCommand()
		{
			if (string.IsNullOrWhiteSpace(Adults))
				await Helper.Alert.DisplayAlert("Adults is required.");
			else if (string.IsNullOrWhiteSpace(Children))
				await Helper.Alert.DisplayAlert("Children is required.");
			else if(string.IsNullOrWhiteSpace(Price))
				await Helper.Alert.DisplayAlert("Price is required.");
			else
			{
				if (CheckInDate == CheckOutDate)
					await Helper.Alert.DisplayAlert("Check-in and Check-out date cannot be same");
				else
				{
					DependencyService.Get<IProgressBar>().Show();
					IRentOutService service = new RentOutService();
					int response = await service.CheckAvailablityDatesAsync(new Models.CheckAvailablityDatesRequest()
					{
						ApartmentId = Address.Id,
						StartDate = $"{CheckInDate.Day}-{CheckInDate.Month}-{CheckInDate.Year}",
						EndDate = $"{CheckOutDate.Day}-{CheckOutDate.Month}-{CheckOutDate.Year}"
					});
					if (response == 0)
					{
						Models.SendBookingRequestInfoRequest request = new Models.SendBookingRequestInfoRequest()
						{
							ApartmentId = Address.Id,
							CheckinDate = $"{CheckInDate.Day}-{CheckInDate.Month}-{CheckInDate.Year}",
							CheckoutDate = $"{CheckOutDate.Day}-{CheckOutDate.Month}-{CheckOutDate.Year}",
							GuestAdults = Adults,
							GuestChildren = Children,
							HotelPropertyType = 2,
							IsPaid = Paid,
							RoomPrice = Price,
						};
						Helper.Helper.SendBookingRequestInfo = request;
						await Navigation.PushAsync(new Views.RentOut.AddNewBookingPhoneNumberDetailsPage());
					}
					else
						await Helper.Alert.DisplayAlert("Please select different dates");
					DependencyService.Get<IProgressBar>().Hide();
				}
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

		private DateTime checkInDate;
		public DateTime CheckInDate
		{
			get => checkInDate;
			set
			{
				checkInDate = value;
				OnPropertyChanged("CheckInDate");
			}
		}

		private DateTime checkOutDate;
		public DateTime CheckOutDate
		{
			get => checkOutDate;
			set
			{
				checkOutDate = value;
				OnPropertyChanged("CheckOutDate");
			}
		}

		private string adults;
		public string Adults
		{
			get => adults;
			set
			{
				adults = value;
				OnPropertyChanged("Adults");
			}
		}

		private string children;
		public string Children
		{
			get => children;
			set
			{
				children = value;
				OnPropertyChanged("Children");
			}
		}

		private int paid = 1;
		public int Paid
		{
			get => paid;
			set
			{
				paid = value;
				OnPropertyChanged("Paid");
			}
		}

		private string price;
		public string Price
		{
			get => price;
			set
			{
				price = value;
				OnPropertyChanged("Price");
			}
		}

		public DateTime BindCheckInMinimumDate => DateTime.Today;
		public DateTime BindCheckInMaximumDate => DateTime.Today.AddYears(70);

		public DateTime BindCheckOutMinimumDate => DateTime.Today;
		public DateTime BindCheckOutMaximumDate => DateTime.Today.AddYears(70);
		#endregion
	}
}
