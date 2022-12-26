using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class HeadLineUpdatedPageViewModel : BaseViewModel
    {
		#region Constructor.
		public HeadLineUpdatedPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
