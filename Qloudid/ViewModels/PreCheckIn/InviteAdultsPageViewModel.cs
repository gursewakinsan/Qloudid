using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class InviteAdultsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public InviteAdultsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Invite Adults By Phone Command.
		private ICommand inviteAdultsByPhoneCommand;
		public ICommand InviteAdultsByPhoneCommand
		{
			get => inviteAdultsByPhoneCommand ?? (inviteAdultsByPhoneCommand = new Command(async () => await ExecuteInviteAdultsByPhoneCommand()));
		}
		private async Task ExecuteInviteAdultsByPhoneCommand()
		{
			await Navigation.PushAsync(new Views.PreCheckIn.InviteAdultsByPhonePage());
		}
		#endregion

		#region Invite Adults By Email Command.
		private ICommand inviteAdultsByEmailCommand;
		public ICommand InviteAdultsByEmailCommand
		{
			get => inviteAdultsByEmailCommand ?? (inviteAdultsByEmailCommand = new Command(async () => await ExecuteInviteAdultsByEmailCommand()));
		}
		private async Task ExecuteInviteAdultsByEmailCommand()
		{
			await Navigation.PushAsync(new Views.PreCheckIn.InviteAdultsByEmailPage());
		}
		#endregion

		#region Back Button Control Command.
		private ICommand backButtonControlCommand;
		public ICommand BackButtonControlCommand
		{
			get => backButtonControlCommand ?? (backButtonControlCommand = new Command(async() =>await ExecuteBackButtonControlCommand()));
		}
		private async Task ExecuteBackButtonControlCommand()
		{
			await Navigation.PopAsync();
		}
		#endregion
	}
}
