using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class ManageCheckedInAndOutPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ManageCheckedInAndOutPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Apartment Checkedin Info Command.
		private ICommand apartmentCheckedinInfoCommand;
		public ICommand ApartmentCheckedinInfoCommand
		{
			get => apartmentCheckedinInfoCommand ?? (apartmentCheckedinInfoCommand = new Command(async () => await ExecuteApartmentCheckedinInfoCommand()));
		}
		private async Task ExecuteApartmentCheckedinInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			ApartmentCheckedinInfo = await service.ApartmentCheckedinInfoAsync(new Models.ApartmentCheckedinInfoRequest()
			{
				ApartmentId = Address.Id //28
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.ApartmentCheckedinInfoResponse> apartmentCheckedinInfo;
		public List<Models.ApartmentCheckedinInfoResponse> ApartmentCheckedinInfo
		{
			get => apartmentCheckedinInfo;
			set
			{
				apartmentCheckedinInfo = value;
				OnPropertyChanged("ApartmentCheckedinInfo");
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
		#endregion
	}
}
