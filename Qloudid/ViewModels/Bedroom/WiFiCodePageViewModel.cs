using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class WiFiCodePageViewModel : BaseViewModel
    {
		#region Constructor.
		public WiFiCodePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
