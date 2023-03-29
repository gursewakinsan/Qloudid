using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class RepairListPageViewModel : BaseViewModel
    {
		#region Constructor.
		public RepairListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region User Apartment Ticket List Command.
		private ICommand userApartmentTicketListCommand;
		public ICommand UserApartmentTicketListCommand
		{
			get => userApartmentTicketListCommand ?? (userApartmentTicketListCommand = new Command(async () => await ExecuteUserApartmentTicketListCommand()));
		}
		private async Task ExecuteUserApartmentTicketListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRepairService service = new RepairService();
			var response = await service.UserApartmentTicketListAsync(new Models.UserApartmentTicketListRequest()
			{
				ApartmentId = Address.Id
			});
            foreach (var item in response)
            {
				if (item.TicketStatus == 0)
				{
					item.IconRed = true;
					item.IsAction = true;
				}
				else if (item.TicketStatus == 1)
				{
					item.IconYellow = true;
					item.IsAction = false;
				}
				else if (item.TicketStatus == 2)
				{
					item.IconGreen = true;
					item.IsAction = false;
				}
			}
			UserApartmentTicketList = response;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Create New Repair Ticket Page Command.
		private ICommand createNewRepairTicketPageCommand;
		public ICommand CreateNewRepairTicketPageCommand
		{
			get => createNewRepairTicketPageCommand ?? (createNewRepairTicketPageCommand = new Command(async () => await ExecuteCreateNewRepairTicketPageCommand()));
		}
		private async Task ExecuteCreateNewRepairTicketPageCommand()
		{
			await Navigation.PushAsync(new Views.Repair.CreateNewRepairTicketPage());
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage.Navigation.PushAsync(new Views.Bedroom.ApartmenHometInfoPage());
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

		private List<Models.UserApartmentTicketListResponse> userApartmentTicketList;
		public List<Models.UserApartmentTicketListResponse> UserApartmentTicketList
		{
			get => userApartmentTicketList;
			set
			{
				userApartmentTicketList = value;
				OnPropertyChanged("UserApartmentTicketList");
			}
		}
		#endregion
	}
}
