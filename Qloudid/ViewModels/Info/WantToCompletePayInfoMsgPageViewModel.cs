using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class WantToCompletePayInfoMsgPageViewModel : BaseViewModel
	{
		#region Constructor.
		public WantToCompletePayInfoMsgPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Continue Command.
		private ICommand continueCommand;
		public ICommand ContinueCommand
		{
			get => continueCommand ?? (continueCommand = new Command(async () => await ExecuteContinueCommand()));
		}
		private async Task ExecuteContinueCommand()
		{
			await Task.CompletedTask;
		}
		#endregion

		#region Cancel Command.
		private ICommand cancelCommand;
		public ICommand CancelCommand
		{
			get => cancelCommand ?? (cancelCommand = new Command(async () => await ExecuteCancelCommand()));
		}
		private async Task ExecuteCancelCommand()
		{
			await Task.CompletedTask;
		}
		#endregion
	}
}
