using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class CleanByPageViewModel : BaseViewModel
    {
		#region Constructor.
		public CleanByPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Clean Now Page Command.
		private ICommand cleanNowPageCommand;
		public ICommand CleanNowPageCommand
		{
			get => cleanNowPageCommand ?? (cleanNowPageCommand = new Command(async () => await ExecuteCleanNowPageCommand()));
		}
		private async Task ExecuteCleanNowPageCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.ProcessToCheckOutPage(ApartmentCheckedIn));
		}
		#endregion

		#region Properties.
		public Models.ApartmentCheckedinInfoResponse ApartmentCheckedIn { get; set; }
		#endregion
	}
}
