using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class ManageYourReservationsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ManageYourReservationsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
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
	}
}
