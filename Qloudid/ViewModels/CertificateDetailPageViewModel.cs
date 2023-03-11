using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class CertificateDetailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CertificateDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Certificate Detail Command.
		private ICommand getCertificateDetailCommand;
		public ICommand GetCertificateDetailCommand
		{
			get => getCertificateDetailCommand ?? (getCertificateDetailCommand = new Command(async () => await ExecuteGetCertificateDetailCommand()));
		}
		private async Task ExecuteGetCertificateDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			CertificateExpiryInfo = await service.GetCertificateExpiryInfoAsync(new Models.CertificateExpiryInfoRequest() { Certificatekey = Helper.Helper.QrCertificateKey });
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private Models.CertificateExpiryInfoResponse certificateExpiryInfo;
		public Models.CertificateExpiryInfoResponse CertificateExpiryInfo
		{
			get => certificateExpiryInfo;
			set
			{
				certificateExpiryInfo = value;
				OnPropertyChanged("CertificateExpiryInfo");
			}
		}
		#endregion
	}
}
