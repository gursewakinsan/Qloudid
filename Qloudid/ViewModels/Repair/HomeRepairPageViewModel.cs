using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class HomeRepairPageViewModel : BaseViewModel
	{
		#region Constructor.
		public HomeRepairPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region User Apartment Problem Detail Command.
		private ICommand userApartmentProblemDetailCommand;
		public ICommand UserApartmentProblemDetailCommand
		{
			get => userApartmentProblemDetailCommand ?? (userApartmentProblemDetailCommand = new Command(async () => await ExecuteUserApartmentProblemDetailCommand()));
		}
		private async Task ExecuteUserApartmentProblemDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRepairService service = new RepairService();
			var response = await service.UserApartmentProblemDetailAsync(new Models.UserApartmentProblemDetailRequest()
			{
				ApartmentId = Address.Id
			});
			foreach (var item in response)
			{
				if (item.TicketId == 11)//Bedroom
				{
					item.TicketIconColor = "#78BDEE";
					item.TicketIcon = Helper.QloudidAppFlatIcons.BedQueen;
				}
				else if (item.TicketId == 1)//Bathroom
				{
					item.TicketIconColor = "#FFECB8";
					item.TicketIcon = Helper.QloudidAppFlatIcons.ScaleBathroom;
				}
				else if (item.TicketId == 9)//Kitchen
				{
					item.TicketIconColor = "#B7FFCA";
					item.TicketIcon = Helper.QloudidAppFlatIcons.FoodForkDrink;
				}
				else if (item.TicketId == 12)//Living room
				{
					item.TicketIconColor = "#D587FA";
					item.TicketIcon = Helper.QloudidAppFlatIcons.SofaSingle;
				}
				else if (item.TicketId == 7)//Hall way
				{
					item.TicketIconColor = "#FFE9AD";
					item.TicketIcon = Helper.QloudidAppFlatIcons.CeilingLight;
				}
				else if (item.TicketId == 2)//Balcony
				{
					item.TicketIconColor = "#EF793F";
					item.TicketIcon = Helper.QloudidAppFlatIcons.Beach;
				}
				else if (item.TicketId == 8)//Basement
				{
					item.TicketIconColor = "#B7FFCA";
					item.TicketIcon = Helper.QloudidAppFlatIcons.Door;
				}
				else
				{
					item.TicketIconColor = "#D587FA";
					item.TicketIcon = Helper.QloudidAppFlatIcons.SofaSingle;
				}
			}

			if (response.Count <= 3)
				ListViewHeightRequest = 120;
			else if (response.Count <= 6)
				ListViewHeightRequest = 240;
			else if (response.Count <= 9)
				ListViewHeightRequest = 360;
			else if (response.Count <= 12)
				ListViewHeightRequest = 480;
			else
				ListViewHeightRequest = 540;
			UserApartmentProblemDetail = response;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Home Repair Category Info Command.
		private ICommand homeRepairCategoryInfoCommand;
		public ICommand HomeRepairCategoryInfoCommand
		{
			get => homeRepairCategoryInfoCommand ?? (homeRepairCategoryInfoCommand = new Command(async () => await ExecuteHomeRepairCategoryInfoCommand()));
		}
		private async Task ExecuteHomeRepairCategoryInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IBedroomService service = new BedroomService();
			var response = await service.HomeRepairCategoryInfoAsync(new Models.HomeRepairCategoryInfoRequest()
			{
				ApartmentId = Address.Id
			});
			if (response.Count <= 3)
				ListViewHeightRequest = 120;
			else if (response.Count <= 6)
				ListViewHeightRequest = 240;
			else if (response.Count <= 9)
				ListViewHeightRequest = 360;
			else if (response.Count <= 12)
				ListViewHeightRequest = 480;
			else
				ListViewHeightRequest = 540;
			HomeRepairCategoryInfo = response;
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

		private List<Models.UserApartmentProblemDetailResponse> userApartmentProblemDetail;
		public List<Models.UserApartmentProblemDetailResponse> UserApartmentProblemDetail
		{
			get => userApartmentProblemDetail;
			set
			{
				userApartmentProblemDetail = value;
				OnPropertyChanged("UserApartmentProblemDetail");
			}
		}

		private List<Models.HomeRepairCategoryInfoResponse> homeRepairCategoryInfo;
		public List<Models.HomeRepairCategoryInfoResponse> HomeRepairCategoryInfo
		{
			get => homeRepairCategoryInfo;
			set
			{
				homeRepairCategoryInfo = value;
				OnPropertyChanged("HomeRepairCategoryInfo");
			}
		}

		private double listViewHeightRequest;
		public double ListViewHeightRequest
		{
			get => listViewHeightRequest;
			set
			{
				listViewHeightRequest = value;
				OnPropertyChanged("ListViewHeightRequest");
			}
		}
		#endregion
	}
}
