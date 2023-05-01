using System.Linq;
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
				if (item.TicketId == 1)//All room
                {
					item.TicketIconColor = "#89C99A";
					item.TicketIcon = Helper.QloudidAppFlatIcons.Flat_apartment;
                }
				else if (item.TicketId == 2)//Bathroom
                {
					item.TicketIconColor = "#55A4DC";
					item.TicketIcon = Helper.QloudidAppFlatIcons.Shower;
                }
				else if (item.TicketId == 3)//Kitchen
				{
					item.TicketIconColor = "#B7FFCA";
					item.TicketIcon = Helper.QloudidAppFlatIcons.Kitchen; //FoodForkDrink;

                }
				else if (item.TicketId == 4)//Entrance
                {
					item.TicketIconColor = "#A4D1F1";
					item.TicketIcon = Helper.QloudidAppFlatIcons.Outline_Login;
                }
				else if (item.TicketId == 5)//Balcony
                {
					item.TicketIconColor = "#FFE9AD";
					item.TicketIcon = Helper.QloudidAppFlatIcons.Outdoordining;
                }
				else if (item.TicketId == 6)//Storage
                {
					item.TicketIconColor = "#7BA5FF";
					item.TicketIcon = Helper.QloudidAppFlatIcons.Cycladichome;
                }
				else if (item.TicketId == 7)//Basement
                {
					item.TicketIconColor = "#EF793F";
					item.TicketIcon = Helper.QloudidAppFlatIcons.HouseLock;
                }
                else if (item.TicketId == 8)//Garage
                {
                    item.TicketIconColor = "#8579B9";
                    item.TicketIcon = Helper.QloudidAppFlatIcons.Parking;
                }
                else if (item.TicketId == 9)//Outdoor
                {
                    item.TicketIconColor = "#EF793F";
                    item.TicketIcon = Helper.QloudidAppFlatIcons.BBQgrill;
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

			
			if (response.Count == 2)
			{
				response[0].IsRightLine = true;
			}
			else if (response.Count == 3)
			{
				response[0].IsRightLine = true;
				response[1].IsRightLine = true;
			}
			else if (response.Count == 4)
			{
				response[0].IsBottomLine = true;
				response[1].IsBottomLine = true;
				response[2].IsBottomLine = true;

				response[0].IsRightLine = true;
				response[1].IsRightLine = true;
				response[2].IsRightLine = false;
				response[3].IsRightLine = true;
			}
			else if (response.Count == 5)
			{
				response[0].IsBottomLine = true;
				response[1].IsBottomLine = true;
				response[2].IsBottomLine = true;

				response[0].IsRightLine = true;
				response[1].IsRightLine = true;
				response[2].IsRightLine = false;
				response[3].IsRightLine = true;
				response[4].IsRightLine = true;
			}
			else if (response.Count == 6)
			{
				response[0].IsBottomLine = true;
				response[1].IsBottomLine = true;
				response[2].IsBottomLine = true;

				response[0].IsRightLine = true;
				response[1].IsRightLine = true;
				response[2].IsRightLine = false;
				response[3].IsRightLine = true;
				response[4].IsRightLine = true;
			}
			else if (response.Count == 7)
			{
				response[0].IsBottomLine = true;
				response[1].IsBottomLine = true;
				response[2].IsBottomLine = true;
				response[3].IsBottomLine = true;
				response[4].IsBottomLine = true;
				response[5].IsBottomLine = true;

				response[0].IsRightLine = true;
				response[1].IsRightLine = true;
				response[3].IsRightLine = true;
				response[4].IsRightLine = true;
				response[5].IsRightLine = true;
			}
			else if (response.Count == 8)
			{
				response[0].IsBottomLine = true;
				response[1].IsBottomLine = true;
				response[2].IsBottomLine = true;
				response[3].IsBottomLine = true;
				response[4].IsBottomLine = true;
				response[5].IsBottomLine = true;

				response[0].IsRightLine = true;
				response[1].IsRightLine = true;
				response[3].IsRightLine = true;
				response[4].IsRightLine = true;
				response[6].IsRightLine = true;
				response[7].IsRightLine = true;
			}
			else if (response.Count == 9)
			{
				response[0].IsBottomLine = true;
				response[1].IsBottomLine = true;
				response[2].IsBottomLine = true;
				response[3].IsBottomLine = true;
				response[4].IsBottomLine = true;
				response[5].IsBottomLine = true;

				response[0].IsRightLine = true;
				response[1].IsRightLine = true;
				response[3].IsRightLine = true;
				response[4].IsRightLine = true;
				response[6].IsRightLine = true;
				response[7].IsRightLine = true;
			}
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
