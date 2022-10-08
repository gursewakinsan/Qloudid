using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class LandLoardConsentPageViewModel : BaseViewModel
    {
		#region Constructor.
		public LandLoardConsentPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Received Request Detail Tenants Command.
		private ICommand receivedRequestDetailTenantsCommand;
		public ICommand ReceivedRequestDetailTenantsCommand
		{
			get => receivedRequestDetailTenantsCommand ?? (receivedRequestDetailTenantsCommand = new Command(async () => await ExecuteReceivedRequestDetailTenantsCommand()));
		}
		private async Task ExecuteReceivedRequestDetailTenantsCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			var response = await service.ReceivedRequestDetailTenantsAsync(new Models.ReceivedRequestDetailTenantsRequest()
			{
				UserId = Helper.Helper.UserId
			});
			List<Models.TenantsRequestDetail> tenantsResponses = new List<Models.TenantsRequestDetail>();
			if (response != null)
			{
				//Received Request.
				foreach (var requestReceived in response.RequestReceivedDetail)
                {
					requestReceived.ActionName = "Action";
					requestReceived.IsRequestReceived = true;
					requestReceived.RowBg = Color.FromHex("#242A37");
					tenantsResponses.Add(requestReceived);
				}

				//Accepted Request.
				foreach (var requestApproved in response.RequestApprovedDetail)
				{
					requestApproved.ActionName = "Accepted";
					requestApproved.IsRequestReceived = false;
					requestApproved.RowBg = Color.Transparent;
					tenantsResponses.Add(requestApproved);
				}

				//Rejected Request.
				foreach (var requestRejected in response.RequestRejectedDetail)
				{
					requestRejected.ActionName = "Rejected";
					requestRejected.IsRequestReceived = false;
					requestRejected.RowBg = Color.Transparent;
					tenantsResponses.Add(requestRejected);
				}
			}
			TenantsRequestDetail = tenantsResponses;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Back Button Control Command.
		private ICommand backButtonControlCommand;
		public ICommand BackButtonControlCommand
		{
			get => backButtonControlCommand ?? (backButtonControlCommand = new Command(async () => await ExecuteBackButtonControlCommand()));
		}
		private async Task ExecuteBackButtonControlCommand()
		{
			await Navigation.PopAsync();
		}
		#endregion

		#region Properties.
		private List<Models.TenantsRequestDetail> tenantsRequestDetail;
		public List<Models.TenantsRequestDetail> TenantsRequestDetail
		{
			get => tenantsRequestDetail;
			set
			{
				tenantsRequestDetail = value;
				OnPropertyChanged("TenantsRequestDetail");
			}
		}
		#endregion
	}
}
