using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class ProcessToCheckOutPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ProcessToCheckOutPageViewModel(INavigation navigation)
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
			await service.UpdateDamagedRentableInfoAsync(new Models.UpdateDamagedRentableInfoRequest()
			{
				ApartmentId = Address.Id,
				IfDamaged = IfDamaged,
				IfRentable = IfRentable,
				IsCleened = IsCleened,
				CheckoutId = SelectedApartmentCheckedInInfo.Id,
				CleeningDate = IsCleened == 1 ? $"{CleanedDate.Day}/{CleanedDate.Month}/{CleanedDate.Year}" : string.Empty
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

		private int isCleened = 1;
		public int IsCleened
		{
			get => isCleened;
			set
			{
				isCleened = value;
				if (value == 1)
					IsCleanedDate = true;
				else
					IsCleanedDate = false;
				OnPropertyChanged("IsCleened");
			}
		}

		private bool isCleanedDate;
		public bool IsCleanedDate
		{
			get => isCleanedDate;
			set
			{
				isCleanedDate = value;
				OnPropertyChanged("IsCleanedDate");
			}
		}

		private int ifDamaged = 0;
		public int IfDamaged
		{
			get => ifDamaged;
			set
			{
				ifDamaged = value;
				OnPropertyChanged("IfDamaged");
			}
		}

		private int ifRentable = 1;
		public int IfRentable
		{
			get => ifRentable;
			set
			{
				ifRentable = value;
				OnPropertyChanged("IfRentable");
			}
		}

		public DateTime BindCleanedDateMinimumDate => DateTime.Today.AddYears(-70);
		public DateTime BindCleanedDateMaximumDate => DateTime.Today;
		public DateTime CleanedDate { get; set; } = DateTime.Today;
		#endregion
	}
}
//,,,cleening_date,apartment_id