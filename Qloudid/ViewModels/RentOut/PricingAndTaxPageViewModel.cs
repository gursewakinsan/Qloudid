using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class PricingAndTaxPageViewModel : BaseViewModel
    {
		#region Constructor.
		public PricingAndTaxPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Address By Id Command.
		private ICommand getAddressByIdCommand;
		public ICommand GetAddressByIdCommand
		{
			get => getAddressByIdCommand ?? (getAddressByIdCommand = new Command(async () => await ExecuteGetAddressByIdCommand()));
		}
		private async Task ExecuteGetAddressByIdCommand()
		{
			IsPageLoad = false;
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			var response = await service.GetAddressByIdAsync(new Models.EditAddressRequest()
			{
				id = Helper.Helper.SelectedUserDeliveryAddress.Id
			});
			Address = response;
			Helper.Helper.SelectedUserAddress = Address;
			DependencyService.Get<IProgressBar>().Hide();
			IsPageLoad = true;
		}
		#endregion

		#region Nightly Pricing Page Command.
		private ICommand nightlyPricingPageCommand;
		public ICommand NightlyPricingPageCommand
		{
			get => nightlyPricingPageCommand ?? (nightlyPricingPageCommand = new Command(async () => await ExecuteNightlyPricingPageCommand()));
		}
		private async Task ExecuteNightlyPricingPageCommand()
		{
			if (Address.IsCurrencyUpdated)
				await Navigation.PushAsync(new Views.RentOut.NightlyPricingListPage());
			else
				await Navigation.PushAsync(new Views.RentOut.AddCurrencyPage());
		}
		#endregion

		#region Cleaning Fee Page Command.
		private ICommand cleaningFeePageCommand;
		public ICommand CleaningFeePageCommand
		{
			get => cleaningFeePageCommand ?? (cleaningFeePageCommand = new Command(async () => await ExecuteCleaningFeePageCommand()));
		}
		private async Task ExecuteCleaningFeePageCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.CleaningFeePage());
		}
		#endregion

		#region Security Deposit Page Command.
		private ICommand securityDepositPageCommand;
		public ICommand SecurityDepositPageCommand
		{
			get => securityDepositPageCommand ?? (securityDepositPageCommand = new Command(async () => await ExecuteSecurityDepositPageCommand()));
		}
		private async Task ExecuteSecurityDepositPageCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.SecurityDepositPage());
			
		}
		#endregion

		#region Tourist Tax Page Command.
		private ICommand touristTaxPageCommand;
		public ICommand TouristTaxPageCommand
		{
			get => touristTaxPageCommand ?? (touristTaxPageCommand = new Command(async () => await ExecuteTouristTaxPageCommand()));
		}
		private async Task ExecuteTouristTaxPageCommand()
		{
			await Navigation.PushAsync(new Views.RentOut.TouristAndTaxPage());

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

		private bool isPageLoad = false;
		public bool IsPageLoad
		{
			get => isPageLoad;
			set
			{
				isPageLoad = value;
				OnPropertyChanged("IsPageLoad");
			}
		}
		#endregion
	}
}