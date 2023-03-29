using Xamarin.Forms;
using Qloudid.Service;
using Xamarin.Essentials;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class CreateNewRepairTicketPageViewModel : BaseViewModel
    {
		#region Constructor.
		public CreateNewRepairTicketPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Home Repair Page Command.
		private ICommand homeRepairPageCommand;
		public ICommand HomeRepairPageCommand
		{
			get => homeRepairPageCommand ?? (homeRepairPageCommand = new Command(async () => await ExecuteHomeRepairPageCommand()));
		}
		private async Task ExecuteHomeRepairPageCommand()
		{
			await Navigation.PushAsync(new Views.Repair.HomeRepairPage());
		}
		#endregion
	}
}
