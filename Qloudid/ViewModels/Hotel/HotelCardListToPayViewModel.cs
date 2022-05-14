using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class HotelCardListToPayViewModel : BaseViewModel
	{
		#region Constructor.
		public HotelCardListToPayViewModel(INavigation navigation)
		{
			Navigation = navigation;
			IsUserCardOrCompanyCard = Helper.Helper.CompanyId > 0 ? false : true;
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
			var response = await service.SubmitPurchaseDetailAsync(new Models.PurchaseDetail()
			{
				user_id = Helper.Helper.UserInfo.user_id,
				company_id = Helper.Helper.CompanyId,
				certificate_key = Helper.Helper.QrCertificateKey
			});

			int index = 0;
			foreach (var item in response)
			{
				item.FirstLetterNameBg = Helper.Helper.ColorList[index];
				index = index + 1;
			}
			CardList = response;
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

		#region User Invoice Address Command.
		private ICommand userInvoiceAddressCommand;
		public ICommand UserInvoiceAddressCommand
		{
			get => userInvoiceAddressCommand ?? (userInvoiceAddressCommand = new Command(() => ExecuteUserInvoiceAddressCommand()));
		}
		private void ExecuteUserInvoiceAddressCommand()
		{
			UserButtonBg = Color.FromHex("#0F9D58");
			CompnyButtonBg = Color.FromHex("#242A37");
			GetAllCardCommand.Execute(null);
		}
		#endregion

		#region Company Invoice Address Command.
		private ICommand companyInvoiceAddressCommand;
		public ICommand CompanyInvoiceAddressCommand
		{
			get => companyInvoiceAddressCommand ?? (companyInvoiceAddressCommand = new Command(() => ExecuteCompanyInvoiceAddressCommand()));
		}
		private void ExecuteCompanyInvoiceAddressCommand()
		{
			UserButtonBg = Color.FromHex("#242A37");
			CompnyButtonBg = Color.FromHex("#0F9D58");
			GetAllCardCommand.Execute(null);
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
			ICreateAccountService service = new CreateAccountService();
			int response = await service.UpdateCardPurchaseDetailAsync(new Models.UpdateCardPurchaseDetail()
			{
				card_id = CardId,
				certificate_key = Helper.Helper.QrCertificateKey
			});
			Helper.Helper.CardDetail = CardDetail;
			await Navigation.PushAsync(new Views.Hotel.HotelYourSignaturePage());
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

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Hotel.ClickedBackFromCardListPage());
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

		private bool isSingleCardDetail;
		public bool IsSingleCardDetail
		{
			get => isSingleCardDetail;
			set
			{
				isSingleCardDetail = value;
				OnPropertyChanged("IsSingleCardDetail");
			}
		}

		private bool isSubmit;
		public bool IsSubmit
		{
			get { return isSubmit; }
			set
			{
				isSubmit = value;
				OnPropertyChanged("IsSubmit");
			}
		}

		private Color userButtonBg = Color.FromHex("#0F9D58");
		public Color UserButtonBg
		{
			get { return userButtonBg; }
			set
			{
				userButtonBg = value;
				OnPropertyChanged("UserButtonBg");
			}
		}

		private Color compnyButtonBg = Color.FromHex("#242A37");
		public Color CompnyButtonBg
		{
			get { return compnyButtonBg; }
			set
			{
				compnyButtonBg = value;
				OnPropertyChanged("CompnyButtonBg");
			}
		}

		private bool isUserCardOrCompanyCard;
		public bool IsUserCardOrCompanyCard
		{
			get { return isUserCardOrCompanyCard; }
			set
			{
				isUserCardOrCompanyCard = value;
				OnPropertyChanged("IsUserCardOrCompanyCard");
			}
		}
		
		public int CardId { get; set; }
		#endregion
	}
}
