using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class TenantInvoicePayNowInfoPageViewModel : BaseViewModel
    {
		#region Constructor.
		public TenantInvoicePayNowInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Pay it Command.
		private ICommand payItCommand;
		public ICommand PayItCommand
		{
			get => payItCommand ?? (payItCommand = new Command(async () => await ExecutePayItCommand()));
		}
		private async Task ExecutePayItCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.VerifyHotelPasswordPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public Models.TenantInvoicePayNow TenantInvoicePayNowInfo => Helper.Helper.TenantInvoicePayNow;
        #endregion
    }
}
