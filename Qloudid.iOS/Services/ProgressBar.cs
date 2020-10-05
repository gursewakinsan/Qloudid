using Xamarin.Forms;
using Qloudid.Interfaces;

[assembly: Dependency(typeof(Qloudid.iOS.Services.ProgressBar))]
namespace Qloudid.iOS.Services
{
	public class ProgressBar : IProgressBar
	{
		public void Hide()
		{
			BigTed.BTProgressHUD.Dismiss();
		}

		public void Show()
		{
			BigTed.BTProgressHUD.Show("Loading...", -1, BigTed.ProgressHUD.MaskType.Black);
		}
	}
}