using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class LandLoardConsentDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public LandLoardConsentDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Approve Tenant Request Command.
		private ICommand approveTenantRequestCommand;
		public ICommand ApproveTenantRequestCommand
		{
			get => approveTenantRequestCommand ?? (approveTenantRequestCommand = new Command(async () => await ExecuteApproveTenantRequestCommand()));
		}
		private async Task ExecuteApproveTenantRequestCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			var response = await service.ApproveTenantRequestAsync(new Models.ApproveTenantRequest()
			{
				UserId = Helper.Helper.UserId,
				Id = selectedTenantsDetail.Id
			});
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Reject Tenant Request Command.
		private ICommand rejectTenantRequestCommand;
		public ICommand RejectTenantRequestCommand
		{
			get => rejectTenantRequestCommand ?? (rejectTenantRequestCommand = new Command(async () => await ExecuteRejectTenantRequestCommand()));
		}
		private async Task ExecuteRejectTenantRequestCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			var response = await service.RejectTenantRequestAsync(new Models.RejectTenantRequest()
			{
				UserId = Helper.Helper.UserId,
				Id = selectedTenantsDetail.Id
			});
			await Navigation.PopAsync();
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
		private Models.TenantsRequestDetail selectedTenantsDetail;
		public  Models.TenantsRequestDetail SelectedTenantsDetail
		{
			get => selectedTenantsDetail;
			set
			{
				selectedTenantsDetail = value;
				OnPropertyChanged("SelectedTenantsDetail");
			}
		}

		public string UserName => Helper.Helper.UserInfo.DisplayUserName;
		#endregion
	}
}
