using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class ArrivalAndRulesPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ArrivalAndRulesPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		private Models.EditAddressResponse address = Helper.Helper.SelectedUserAddress;
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
