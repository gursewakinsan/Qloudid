using System.Linq;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class IdentificatorPageForCheckInViewModel : BaseViewModel
	{
		#region Constructor.
		public IdentificatorPageForCheckInViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Selected Identificator Command.
		private ICommand selectedIdentificatorCommand;
		public ICommand SelectedIdentificatorCommand
		{
			get => selectedIdentificatorCommand ?? (selectedIdentificatorCommand = new Command<string>(async (identificator) => await ExecuteSelectedIdentificatorCommand(identificator)));
		}
		private async Task ExecuteSelectedIdentificatorCommand(string identificator)
		{
			switch (identificator)
			{
				case "IdNumber":
					Helper.Helper.SelectedIdentificatorText = "ID";
					Helper.Helper.SelectedIdentificatorId = 1;
					await Navigation.PushAsync(new Views.IdentificatorPhotoPage());
					break;
				case "PassportNumber":
					Helper.Helper.SelectedIdentificatorId = 3;
					Helper.Helper.SelectedIdentificatorText = "Passport";
					await Navigation.PushAsync(new Views.IdentificatorPhotoPage());
					break;
			}
		}
		#endregion
	}
}
