using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class NoAccountFoundPageViewModel : BaseViewModel
    {
		#region Constructor.
		public NoAccountFoundPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Create Account Command.
		private ICommand createAccountCommand;
		public ICommand CreateAccountCommand
		{
			get => createAccountCommand ?? (createAccountCommand = new Command(async () => await ExecuteCreateAccountCommand()));
		}
		private async Task ExecuteCreateAccountCommand()
		{
		}
		#endregion

		#region Try Again Command.
		private ICommand tryAgainCommand;
		public ICommand TryAgainCommand
		{
			get => tryAgainCommand ?? (tryAgainCommand = new Command(async () => await ExecuteTryAgainCommand()));
		}
		private async Task ExecuteTryAgainCommand()
		{
			await Navigation.PopAsync();
		}
		#endregion
	}
}
