using System.Timers;
using Xamarin.Forms;
using System.Windows.Input;

namespace Qloudid.ViewModels
{
	public class PurchaseSuccessfulViewModel : BaseViewModel
	{
		#region Local Variable.
		Timer timer;
		#endregion

		#region Constructor.
		public PurchaseSuccessfulViewModel(INavigation navigation)
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
				CloseCommand.Execute(null);
			});
		}
		#endregion

		#region Close Command.
		private ICommand closeCommand;
		public ICommand CloseCommand
		{
			get => closeCommand ?? (closeCommand = new Command(() => ExecuteCloseCommand()));
		}
		private void ExecuteCloseCommand()
		{
			if (timer != null) timer.Enabled = false;
			Helper.Helper.IsBack = true;
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
		}
		#endregion
	}
}
