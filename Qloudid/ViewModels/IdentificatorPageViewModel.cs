using System.Linq;
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
					await Navigation.PushAsync(new Views.SelectedIdentificatorPage("ID number"));
					break;
				case "DriverLicenseNumber":
					await Navigation.PushAsync(new Views.SelectedIdentificatorPage("Driver license number"));
					break;
				case "PassportNumber":
					await Navigation.PushAsync(new Views.SelectedIdentificatorPage("Passport number"));
					break;
			}
		}
		#endregion

		#region Properties.
		public string CountryName => Helper.Helper.CountryList.FirstOrDefault(x => x.CountryCode.Equals(Helper.Helper.CountryCode)).CountryName;
		#endregion
	}
}
