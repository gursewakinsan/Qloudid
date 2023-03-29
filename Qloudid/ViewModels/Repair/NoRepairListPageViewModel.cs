using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class NoRepairListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public NoRepairListPageViewModel(INavigation navigation)
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
			await Navigation.PushAsync(new Views.Repair.CreateNewRepairTicketPage());
		}
		#endregion
	}
}
