using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
    public class ManualsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ManualsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region GetSrated Manuals Detail Command.
		private ICommand getSratedManualsDetailCommand;
		public ICommand GetSratedManualsDetailCommand
		{
			get => getSratedManualsDetailCommand ?? (getSratedManualsDetailCommand = new Command(async () => await ExecuteGetSratedManualsDetailCommand()));
		}
		private async Task ExecuteGetSratedManualsDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			var response = await service.GetSratedDetailAsync(new Models.GetSratedDetailRequest()
			{
				ApartmentId = Address.Id
			});
			StartedManuals = new ObservableCollection<Models.GetSratedDetailResponse>(response);
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

		private ObservableCollection<Models.GetSratedDetailResponse> startedManuals;
		public ObservableCollection<Models.GetSratedDetailResponse> StartedManuals
		{
			get => startedManuals;
			set
			{
				startedManuals = value;
				OnPropertyChanged("StartedManuals");
			}
		}
		#endregion
	}
}
