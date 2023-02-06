using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AddCreateYourPropertyPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddCreateYourPropertyPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Manually Command.
		private ICommand manuallyCommand;
		public ICommand ManuallyCommand
		{
			get => manuallyCommand ?? (manuallyCommand = new Command(async () => await ExecuteManuallyCommand()));
		}
		private async Task ExecuteManuallyCommand()
		{
			await Navigation.PushAsync(new Views.Bedroom.ProfileEnterPropertyDetailsPage());
		}
		#endregion
	}
}
