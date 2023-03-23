using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class CheckOutGuestPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CheckOutGuestPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Apartment Checked Out Info Command.
		private ICommand apartmentCheckedOutInfoCommand;
		public ICommand ApartmentCheckedOutInfoCommand
		{
			get => apartmentCheckedOutInfoCommand ?? (apartmentCheckedOutInfoCommand = new Command(async () => await ExecuteApartmentCheckedOutInfoCommand()));
		}
		private async Task ExecuteApartmentCheckedOutInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			var responses = await service.ApartmentCheckedOutInfoAsync(new Models.ApartmentCheckedinInfoRequest()
			{
				ApartmentId = Address.Id //28
			});

			
			if (responses?.Count > 0)
			{
				foreach (var item in responses)
				{
					if (item.CheckedIn == 1)
					{
						item.IconRed = true;
						item.IsAction = true;
					}
					else if (item.CheckedIn == 2)
					{
						item.IconGreen = true;
						item.IsAction = false;
					}
				}
			}
			ApartmentCheckedOutInfo = responses;
			DependencyService.Get<IProgressBar>().Hide();
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

		private List<Models.ApartmentCheckedinInfoResponse> apartmentCheckedOutInfo;
		public List<Models.ApartmentCheckedinInfoResponse> ApartmentCheckedOutInfo
		{
			get => apartmentCheckedOutInfo;
			set
			{
				apartmentCheckedOutInfo = value;
				OnPropertyChanged("ApartmentCheckedOutInfo");
			}
		}
		#endregion
	}
}
