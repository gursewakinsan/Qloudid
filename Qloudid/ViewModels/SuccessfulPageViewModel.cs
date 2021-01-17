using System.Timers;
using Xamarin.Forms;
using System.Windows.Input;

namespace Qloudid.ViewModels
{
	public class SuccessfulPageViewModel : BaseViewModel
	{
		#region Local Variable.
		Timer timer;
		#endregion

		#region Constructor.
		public SuccessfulPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			timer = new Timer();
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			timer.Interval = 30000;
			timer.Enabled = true;
		}
		#endregion

		#region On Timed Event.
		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				CloseAppCommand.Execute(null);
			});
		}
		#endregion

		#region Close App Command.
		private ICommand closeAppCommand;
		public ICommand CloseAppCommand
		{
			get => closeAppCommand ?? (closeAppCommand = new Command(() => ExecuteCloseAppCommand()));
		}
		private async void ExecuteCloseAppCommand()
		{
			if (timer != null) timer.Enabled = false;
			Helper.Helper.IsBack = true;
			if (Helper.Helper.IsThirdPartyWebLogin)
				await Xamarin.Essentials.Launcher.OpenAsync("https://www.qloudid.com/user/index.php/LoginAccount/loginapp?next=eEFnQmlhS29sYjZHZXVZN01QajNVdz09&login=1");
			else
				await Xamarin.Essentials.Launcher.OpenAsync("https://www.qloudid.com/user/index.php/LoginAccount/loginapp");
			//System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			//System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
		}
		#endregion
	}
}
