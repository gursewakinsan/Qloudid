using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class KeyAvailablePageViewModel : BaseViewModel
	{
		#region Constructor.
		public KeyAvailablePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Key Available Command.
		private ICommand keyAvailableCommand;
		public ICommand KeyAvailableCommand
		{
			get => keyAvailableCommand ?? (keyAvailableCommand = new Command(() => ExecuteKeyAvailableCommand()));
		}
		private void ExecuteKeyAvailableCommand()
		{
			Address.KeyAvailable = !Address.KeyAvailable;
		}
		#endregion

		#region Properties.
		private Models.EditAddressResponse address;
		public Models.EditAddressResponse Address
		{
			get => address;
			set
			{
				address = value;
				OnPropertyChanged("Address");
			}
		}
		#endregion
	}
}