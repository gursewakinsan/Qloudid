using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class ApartmentInfoPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ApartmentInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
