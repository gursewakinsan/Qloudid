using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AddNewContactDetailPageViewModel : BaseViewModel
    {
		#region Constructor.
		public AddNewContactDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
