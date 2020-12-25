using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class RestorePageViewModel : BaseViewModel
	{
		#region Constructor.
		public RestorePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region New User Command.
		private ICommand newUserCommand;
		public ICommand NewUserCommand
		{
			get => newUserCommand ?? (newUserCommand = new Command(async () => await ExecuteNewUserCommand()));
		}
		private async Task ExecuteNewUserCommand()
		{
			await Navigation.PushAsync(new Views.CreateAccountPage());
		}
		#endregion

		#region User Restore Command.
		private ICommand userRestoreCommand;
		public ICommand UserRestoreCommand
		{
			get => userRestoreCommand ?? (userRestoreCommand = new Command(async () => await ExecuteUserRestoreCommand()));
		}
		private async Task ExecuteUserRestoreCommand()
		{
			await Navigation.PushAsync(new Views.RestoreEmailPage());
		}
		#endregion
	}
}
