using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class AssignCleaningTaskNowPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AssignCleaningTaskNowPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Apartment Checked Out Cleening History Command.
		private ICommand apartmentCheckedOutCleeningHistoryCommand;
		public ICommand ApartmentCheckedOutCleeningHistoryCommand
		{
			get => apartmentCheckedOutCleeningHistoryCommand ?? (apartmentCheckedOutCleeningHistoryCommand = new Command(async () => await ExecuteApartmentCheckedOutCleeningHistoryCommand()));
		}
		private async Task ExecuteApartmentCheckedOutCleeningHistoryCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			var response = await service.ApartmentCheckedOutCleeningHistoryAsync(new Models.ApartmentCheckedOutCleeningHistoryRequest()
			{
				ApartmentId = Address.Id
			});
			foreach (var item in response)
			{
				if (item.IsCleaned == 0)
				{
					item.IconRed = true;
				}
				else if (item.IsCleaned == 1 && item.IsRentable == 0)
				{
					item.IconYellow = true;
				}
				else if (item.IsCleaned == 1 && item.IsRentable == 1)
				{
					item.IconGreen = true;
				}
			}
			if (response?.Count > 0)
			{
				if (!response[0].IconGreen)
					response[0].IsAction = true;
			}
			CleeningHistory = response;
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

		private List<Models.ApartmentCheckedOutCleeningHistoryResponse> cleeningHistory;
		public List<Models.ApartmentCheckedOutCleeningHistoryResponse> CleeningHistory
		{
			get => cleeningHistory;
			set
			{
				cleeningHistory = value;
				OnPropertyChanged("CleeningHistory");
			}
		}
		#endregion
	}
}
