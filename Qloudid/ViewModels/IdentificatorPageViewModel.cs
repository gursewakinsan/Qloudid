using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class IdentificatorPageViewModel : BaseViewModel
	{
		#region Constructor.
		public IdentificatorPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			SelectedIdentificator = new Models.Identificator();
		}
		#endregion

		#region Save Identify Info Command.
		private ICommand saveIdentifyInfoCommand;
		public ICommand CreateAccountCommand
		{
			get => saveIdentifyInfoCommand ?? (saveIdentifyInfoCommand = new Command(async () => await ExecuteSaveIdentifyInfoCommand()));
		}
		private async Task ExecuteSaveIdentifyInfoCommand()
		{
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public Models.Identificator SelectedIdentificator { get; set; }

		private bool isShowIdentificator = false;
		public bool IsShowIdentificator
		{
			get { return isShowIdentificator; }
			set
			{
				if (isShowIdentificator != value)
				{
					isShowIdentificator = value;
					OnPropertyChanged("IsShowIdentificator");
				}
			}
		}
		#endregion
	}
}
