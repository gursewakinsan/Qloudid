using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class ToDoApartmentsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public ToDoApartmentsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
