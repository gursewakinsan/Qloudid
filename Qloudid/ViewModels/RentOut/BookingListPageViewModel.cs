using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class BookingListPageViewModel : BaseViewModel
    {
		#region Constructor.
		public BookingListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Apartment Booking List Command.
		private ICommand apartmentBookingListCommand;
		public ICommand ApartmentBookingListCommand
		{
			get => apartmentBookingListCommand ?? (apartmentBookingListCommand = new Command(async () => await ExecuteApartmentBookingListCommand()));
		}
		private async Task ExecuteApartmentBookingListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			ApartmentBookingList = await service.ApartmentBookingListAsync(new Models.ApartmentBookingListRequest()
			{
				ApartmentId = Address.Id
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Add New Apartment Booking Command.
		private ICommand addNewApartmentBookingCommand;
		public ICommand AddNewApartmentBookingCommand
		{
			get => addNewApartmentBookingCommand ?? (addNewApartmentBookingCommand = new Command(async () => await ExecuteAddNewApartmentBookingCommand()));
		}
		private async Task ExecuteAddNewApartmentBookingCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.AddNewBookingDetailsPage());
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

		private List<Models.ApartmentBookingListResponse> apartmentBookingList;
		public List<Models.ApartmentBookingListResponse> ApartmentBookingList
		{
			get => apartmentBookingList;
			set
			{
				apartmentBookingList = value;
				OnPropertyChanged("ApartmentBookingList");
			}
		}
		#endregion
	}
}
