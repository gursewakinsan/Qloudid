using AndroidHUD;
using Xamarin.Forms;
using Qloudid.Interfaces;

[assembly: Dependency(typeof(Qloudid.Droid.Services.ProgressBar))]
namespace Qloudid.Droid.Services
{
	public class ProgressBar : IProgressBar
	{
		public void Hide()
		{
			AndHUD.Shared.Dismiss();
		}

		public void Show()
		{
			AndHUD.Shared.Show(Forms.Context, "Loading...", -1, MaskType.Black);
		}
	}
}