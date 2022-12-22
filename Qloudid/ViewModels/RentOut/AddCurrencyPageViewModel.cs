using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AddCurrencyPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddCurrencyPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Add Currency Command.
		private ICommand addCurrencyCommand;
		public ICommand AddCurrencyCommand
		{
			get => addCurrencyCommand ?? (addCurrencyCommand = new Command(async () => await ExecuteAddCurrencyCommand()));
		}
		private async Task ExecuteAddCurrencyCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			await service.AddCurrencyAsync(new Models.AddCurrencyRequest()
			{
				ApartmentId = Address.Id,
				CurrencyId = CurrencyId,
			});
			Helper.Helper.IsFromCurrencyPage = true;
			await Navigation.PushAsync(new Views.RentOut.NightlyPricingListPage());
			DependencyService.Get<IProgressBar>().Hide();
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

		public int CurrencyId { get; set; } = 1;
        #endregion
    }
}
