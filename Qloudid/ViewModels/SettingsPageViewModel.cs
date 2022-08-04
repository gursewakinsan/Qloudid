using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class SettingsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SettingsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Certificate Detail Command.
		private ICommand getCertificateDetailCommand;
		public ICommand GetCertificateDetailCommand
		{
			get => getCertificateDetailCommand ?? (getCertificateDetailCommand = new Command(async () => await ExecuteGetCertificateDetailCommand()));
		}
		private async Task ExecuteGetCertificateDetailCommand()
		{
			await Navigation.PushAsync(new Views.CertificateDetailPage());
		}
		#endregion

		#region Manage Card Command.
		private ICommand manageCardCommand;
		public ICommand ManageCardCommand
		{
			get => manageCardCommand ?? (manageCardCommand = new Command(async () => await ExecuteManageCardCommand()));
		}
		private async Task ExecuteManageCardCommand()
		{
			await Navigation.PushAsync(new Views.CardListPage());
		}
		#endregion

		#region Go To My Home Page Command.
		private ICommand goToMyHomePageCommand;
		public ICommand GoToMyHomePageCommand
		{
			get => goToMyHomePageCommand ?? (goToMyHomePageCommand = new Command(async () => await ExecuteGoToMyHomePageCommand()));
		}
		private async Task ExecuteGoToMyHomePageCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.MyHomePage());
		}
		#endregion

		#region Properties.
		public Models.User UserInfo => Helper.Helper.UserInfo;
		#endregion
	}
}
