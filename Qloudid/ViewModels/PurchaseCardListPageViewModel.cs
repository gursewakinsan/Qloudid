using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class PurchaseCardListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public PurchaseCardListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Add New Card Command.
		private ICommand addNewCardCommand;
		public ICommand AddNewCardCommand
		{
			get => addNewCardCommand ?? (addNewCardCommand = new Command(async () => await ExecuteAddNewCardCommand()));
		}
		private async Task ExecuteAddNewCardCommand()
		{
			await Navigation.PushAsync(new Views.AddNewPurchaseCardPage());
		}
		#endregion

		#region Card Details Command.
		private ICommand cardDetailsCommand;
		public ICommand CardDetailsCommand
		{
			get => cardDetailsCommand ?? (cardDetailsCommand = new Command<int>(async (cardId) => await ExecuteCardDetailsCommand(cardId)));
		}
		private async Task ExecuteCardDetailsCommand(int cardId)
		{
			int companyId = IsAddNewCardVisible ? 0 : 1;
			await Navigation.PushAsync(new Views.CardDetailsPage(cardId, companyId));
		}
		#endregion

		#region Properties.
		private List<Models.CardDetailResponse> purchaseCardList;
		public List<Models.CardDetailResponse> PurchaseCardList
		{
			get => purchaseCardList;
			set
			{
				purchaseCardList = value;
				OnPropertyChanged("PurchaseCardList");
			}
		}

		private bool isAddNewCardVisible;
		public bool IsAddNewCardVisible
		{
			get => isAddNewCardVisible;
			set
			{
				isAddNewCardVisible = value;
				OnPropertyChanged("IsAddNewCardVisible");
			}
		}
		#endregion
	}
}
