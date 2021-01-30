using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class CardDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CardDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Card Details Command.
		private ICommand getCardDetailsCommand;
		public ICommand GetCardDetailsCommand
		{
			get => getCardDetailsCommand ?? (getCardDetailsCommand = new Command(async () => await ExecuteGetCardDetailsCommand()));
		}
		private async Task ExecuteGetCardDetailsCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICreateAccountService service = new CreateAccountService();
			CardDetail = await service.GetCardDetailsByIdAsync(new Models.CardDetailsRequest() { card_id = CardId });
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Submit Card Details Command.
		private ICommand submitCardDetailsCommand;
		public ICommand SubmitCardDetailsCommand
		{
			get => submitCardDetailsCommand ?? (submitCardDetailsCommand = new Command(async () => await ExecuteSubmitCardDetailsCommand()));
		}
		private async Task ExecuteSubmitCardDetailsCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICreateAccountService service = new CreateAccountService();
			int response = await service.UpdateCardPurchaseDetailAsync(new Models.UpdateCardPurchaseDetail()
			{
				card_id = CardId,
				certificate_key = Helper.Helper.QrCertificateKey
			});
			if (response == 0)
				await Helper.Alert.DisplayAlert("Something went wrong, Please try again.");
			else if (response == 1)
			{
				if (Helper.Helper.IsThirdPartyWebLogin)
				{
					Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
					if (Helper.Helper.PurchaseIndex == 1)
						await Xamarin.Essentials.Launcher.OpenAsync("https://www.qloudid.com/user/index.php/LoginAccount/loginPurchaseVerify");
					else
						await Xamarin.Essentials.Launcher.OpenAsync("https://www.qloudid.com/user/index.php/LoginAccount/loginPurchase");
				}
				else
					Application.Current.MainPage = new NavigationPage(new Views.PurchaseSuccessfulPage());
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		public int CardId { get; set; }

		private Models.CardDetailsResponse cardDetail;
		public Models.CardDetailsResponse CardDetail
		{
			get => cardDetail;
			set
			{
				cardDetail = value;
				OnPropertyChanged("CardDetail");
			}
		}
		#endregion
	}
}
