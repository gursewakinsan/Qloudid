using System;
using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class DependentProfilePageViewModel : BaseViewModel
	{
		#region Constructor.
		public DependentProfilePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
