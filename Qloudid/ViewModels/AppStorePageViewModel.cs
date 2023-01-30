using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AppStorePageViewModel : BaseViewModel
    {
		#region Constructor.
		public AppStorePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Children Command.
		private ICommand childrenCommand;
		public ICommand ChildrenCommand
		{
			get => childrenCommand ?? (childrenCommand = new Command(async () => await ExecuteChildrenCommand()));
		}
		private async Task ExecuteChildrenCommand()
		{
			//await Navigation.PushAsync(new Views.Dependent.DependentListPage());
			await Navigation.PushAsync(new Views.MyCountries.ChangeProfilePage());
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
	}
}
