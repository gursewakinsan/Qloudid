using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class AddNewDependentPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddNewDependentPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
