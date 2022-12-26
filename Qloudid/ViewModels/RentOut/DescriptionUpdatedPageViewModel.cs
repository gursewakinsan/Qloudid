using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class DescriptionUpdatedPageViewModel : BaseViewModel
	{
		#region Constructor.
		public DescriptionUpdatedPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
