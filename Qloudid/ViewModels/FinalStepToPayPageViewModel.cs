using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class FinalStepToPayPageViewModel : BaseViewModel
	{
		#region Constructor.
		public FinalStepToPayPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get All Card Command.
		private ICommand getAllCardCommand;
		public ICommand GetAllCardCommand
		{
			get => getAllCardCommand ?? (getAllCardCommand = new Command(async () => await ExecuteGetAllCardCommand()));
		}
		private async Task ExecuteGetAllCardCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IsVisibleCardDetail = false;
			IPurchaseService service = new PurchaseService();
			CardList = await service.SubmitPurchaseDetailAsync(new Models.PurchaseDetail()
			{
				user_id = Helper.Helper.UserInfo.user_id,
				company_id = Helper.Helper.CompanyId,
				certificate_key = Helper.Helper.QrCertificateKey
			});
			DependencyService.Get<IProgressBar>().Hide();
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
			CardDetail = CardList.FirstOrDefault(x => x.id == CardId);
			IsVisibleCardDetail = true;
			await Task.CompletedTask;
		}
		#endregion

		#region Selected Final Step To Pay Command.
		private ICommand selectedFinalStepToPayCommand;
		public ICommand SelectedFinalStepToPayCommand
		{
			get => selectedFinalStepToPayCommand ?? (selectedFinalStepToPayCommand = new Command(async () => await ExecuteSelectedFinalStepToPayCommand()));
		}
		private async Task ExecuteSelectedFinalStepToPayCommand()
		{
			Helper.Helper.CardDetail = CardDetail;
			await Navigation.PushAsync(new Views.YourSignaturePage());
		}
		#endregion

		#region Add New Card For Paying Command.
		private ICommand addNewCardForPayingCommand;
		public ICommand AddNewCardForPayingCommand
		{
			get => addNewCardForPayingCommand ?? (addNewCardForPayingCommand = new Command(async () => await ExecuteAddNewCardForPayingCommand()));
		}
		private async Task ExecuteAddNewCardForPayingCommand()
		{
			await Navigation.PushAsync(new Views.AddNewCardToPayPage());
		}
		#endregion

		#region Edit Card For Paying Command.
		private ICommand editCardForPayingCommand;
		public ICommand EditCardForPayingCommand
		{
			get => editCardForPayingCommand ?? (editCardForPayingCommand = new Command(async () => await ExecuteEditCardForPayingCommand()));
		}
		private async Task ExecuteEditCardForPayingCommand()
		{
			await Navigation.PushAsync(new Views.EditCardToPayPage(CardDetail));
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

		private Models.CardDetailResponse cardDetail;
		public Models.CardDetailResponse CardDetail
		{
			get => cardDetail;
			set
			{
				cardDetail = value;
				OnPropertyChanged("CardDetail");
			}
		}

		private bool isVisibleCardDetail;
		public bool IsVisibleCardDetail
		{
			get => isVisibleCardDetail;
			set
			{
				isVisibleCardDetail = value;
				OnPropertyChanged("IsVisibleCardDetail");
			}
		}
		public bool IsUserCardOrCompanyCard => Helper.Helper.CompanyId > 0 ? false : true;
		public int CardId { get; set; }
		#endregion
	}
}
