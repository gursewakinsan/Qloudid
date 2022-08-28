using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AddVisitingCountryPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddVisitingCountryPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
