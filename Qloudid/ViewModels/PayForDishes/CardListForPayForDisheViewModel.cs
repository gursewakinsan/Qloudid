using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class CardListForPayForDisheViewModel : BaseViewModel
	{
		#region Constructor.
		public CardListForPayForDisheViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Card List Command.
		private ICommand getCardListCommand;
		public ICommand GetCardListCommand
		{
			get => getCardListCommand ?? (getCardListCommand = new Command(async () => await ExecuteGetCardListCommand()));
		}
		private async Task ExecuteGetCardListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IPurchaseService service = new PurchaseService();
			List<Models.CardDetailResponse> response = await service.SubmitPurchaseDetailAsync(new Models.PurchaseDetail()
			{
				user_id = Helper.Helper.UserInfo.user_id,
				company_id = Helper.Helper.CompanyId,
				certificate_key = Helper.Helper.QrCertificateKey
			});
			if (response == null)
				await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
			else
				CardList = response;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Submit Card Details Command.
		private ICommand submitCardDetailsCommand;
		public ICommand SubmitCardDetailsCommand
		{
			get => submitCardDetailsCommand ?? (submitCardDetailsCommand = new Command<int>(async (cardId) => await ExecuteSubmitCardDetailsCommand(cardId)));
		}
		private async Task ExecuteSubmitCardDetailsCommand(int cardId)
		{
			DependencyService.Get<IProgressBar>().Show();
			ICreateAccountService service = new CreateAccountService();
			int response = await service.UpdateCardPurchaseDetailAsync(new Models.UpdateCardPurchaseDetail()
			{
				card_id = cardId,
				certificate_key = Helper.Helper.QrCertificateKey
			});
			if (response == 0)
				await Helper.Alert.DisplayAlert("Something went wrong, Please try again.");
			else if (response == 1)
			{
				if (Helper.Helper.IsScanQrPayForDishe)
					Application.Current.MainPage = new NavigationPage(new Views.PayForDishes.SuccessfulPayForDishePage());
				else
				{
					Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
					if (Helper.Helper.IsCashPayForDishe)
						await Xamarin.Essentials.Launcher.OpenAsync("https://www.qloudid.com/user/index.php/LoginAccount/payForDishes/RVRFQlRRRUFXZWtBamk3LysxRVJiQT09?response_type=code&client_id=MjI5MktKdzBMdmNPMjZNRnhYRkJRdz09&state=xyz&payForDishes=0");
					else
						await Xamarin.Essentials.Launcher.OpenAsync("https://www.qloudid.com/user/index.php/LoginAccount/payForDishes/RVRFQlRRRUFXZWtBamk3LysxRVJiQT09?response_type=code&client_id=MjI5MktKdzBMdmNPMjZNRnhYRkJRdz09&state=xyz&payForDishes=1");
				}
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.CardDetailResponse> cardList;
		public List<Models.CardDetailResponse> CardList
		{
			get => cardList;
			set
			{
				cardList = value;
				OnPropertyChanged("CardList");
			}
		}
		#endregion
	}
}
