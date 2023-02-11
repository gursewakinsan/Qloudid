using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class ProcessToCheckInPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ProcessToCheckInPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Check Out Apartment Guest Command.
		private ICommand checkOutApartmentGuestCommand;
		public ICommand CheckOutApartmentGuestCommand
		{
			get => checkOutApartmentGuestCommand ?? (checkOutApartmentGuestCommand = new Command(async () => await ExecuteCheckOutApartmentGuestCommand()));
		}
		private async Task ExecuteCheckOutApartmentGuestCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			await service.CheckoutApartmentGuestAsync(new Models.CheckoutApartmentGuestRequest()
			{
				CheckoutId = SelectedApartmentCheckedInInfo.Id,
				ActualCheckoutDate = $"{CheckOutDate.Day}-{CheckOutDate.Month}-{CheckOutDate.Year}"
			});
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private Models.ApartmentCheckedinInfoResponse selectedApartmentCheckedInInfo;
		public Models.ApartmentCheckedinInfoResponse SelectedApartmentCheckedInInfo
		{
			get => selectedApartmentCheckedInInfo;
			set
			{
				selectedApartmentCheckedInInfo = value;
				OnPropertyChanged("SelectedApartmentCheckedInInfo");
				CheckOutDate = Convert.ToDateTime(selectedApartmentCheckedInInfo.CheckinDate);
				BindCheckOutMinimumDate = Convert.ToDateTime(selectedApartmentCheckedInInfo.CheckinDate);
				BindCheckOutMaximumDate = Convert.ToDateTime(selectedApartmentCheckedInInfo.CheckinDate).AddYears(70);
			}
		}

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

		private DateTime checkOutDate = DateTime.Today;
		public DateTime CheckOutDate
		{
			get => checkOutDate;
			set
			{
				checkOutDate = value;
				OnPropertyChanged("CheckOutDate");
			}
		}

		private DateTime bindCheckOutMinimumDate = DateTime.Today;
		public DateTime BindCheckOutMinimumDate
		{
			get => bindCheckOutMinimumDate;
			set
			{
				bindCheckOutMinimumDate = value;
				OnPropertyChanged("BindCheckOutMinimumDate");
			}
		}

		private DateTime bindCheckOutMaximumDate = DateTime.Today.AddYears(70);
		public DateTime BindCheckOutMaximumDate
		{
			get => bindCheckOutMaximumDate;
			set
			{
				bindCheckOutMaximumDate = value;
				OnPropertyChanged("BindCheckOutMaximumDate");
			}
		}
		#endregion
	}
}
