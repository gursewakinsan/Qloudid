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
			var res = Helper.Helper.CountryList.FirstOrDefault(x => x.CountryCode.Equals(Helper.Helper.CountryCode));
			if (res != null)
				CountryName = res.CountryName;
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
					await Navigation.PushAsync(new Views.SelectedIdentificatorPage());
					break;
				case "DriverLicenseNumber":
					Helper.Helper.SelectedIdentificatorText = "Driver license";
					await Navigation.PushAsync(new Views.SelectedIdentificatorPage());
					break;
				case "PassportNumber":
					Helper.Helper.SelectedIdentificatorText = "Passport";
					await Navigation.PushAsync(new Views.SelectedIdentificatorPage());
					break;
			}
		}
		#endregion

		#region Skip Identify Info Command.
		private ICommand skipIdentifyInfoCommand;
		public ICommand SkipIdentifyInfoCommand
		{
			get => skipIdentifyInfoCommand ?? (skipIdentifyInfoCommand = new Command(async () => await ExecuteSkipIdentifyInfoCommand()));
		}
		private async Task ExecuteSkipIdentifyInfoCommand()
		{
			//Helper.Helper.IsAddMoreCard = false;
			Application.Current.MainPage = new NavigationPage(new Views.GenerateCertificatePage());
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		//public string CountryName => "hhhh";//Helper.Helper.CountryList.FirstOrDefault(x => x.CountryCode.Equals(Helper.Helper.CountryCode)).CountryName;
		public string countryName = string.Empty;
		public string CountryName
		{
			get => countryName;
			set
			{
				countryName = value;
				OnPropertyChanged("CountryName");
			}
		}
		#endregion
	}
}
