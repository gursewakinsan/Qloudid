using Xamarin.Forms;
using System.Threading.Tasks;

namespace Qloudid.Helper
{
	public static class Alert
	{
		public static async Task DisplayAlert(string message)
		{
			await Application.Current.MainPage.DisplayAlert("", message, "OK");
		}

		public static async Task<bool> ShowAlertYesNo(string message)
		{
			return await Application.Current.MainPage.DisplayAlert("", message, "Yes", "No");
		}
	}
}