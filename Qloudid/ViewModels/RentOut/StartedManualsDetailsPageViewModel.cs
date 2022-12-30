using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class StartedManualsDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public StartedManualsDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
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

		private Models.GetSratedDetailResponse selectedStartedManuals;
		public Models.GetSratedDetailResponse SelectedStartedManuals
		{
			get => selectedStartedManuals;
			set
			{
				selectedStartedManuals = value;
				OnPropertyChanged("SelectedStartedManuals");
			}
		}
		#endregion
	}
}
