using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

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

		#region ReceivedRequestDetailTenantsCommand.
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
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion
	}
}
