using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class NickNameUpdatedPageViewModel : BaseViewModel
    {
		#region Constructor.
		public NickNameUpdatedPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
