using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class MyHomeDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public MyHomeDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		public Models.UserDeliveryAddressesResponse SelectedUserDeliveryAddress => Helper.Helper.SelectedUserDeliveryAddress;
		#endregion
	}
}
