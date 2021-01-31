using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Collections.Generic;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PurchaseCardListPage : ContentPage
	{
		PurchaseCardListPageViewModel viewModel;
		public PurchaseCardListPage(List<Models.CardDetailResponse> cards)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new PurchaseCardListPageViewModel(this.Navigation);
			viewModel.PurchaseCardList = cards;
			if (cards?.Count > 0)
				viewModel.IsAddNewCardVisible = cards[0].company_id > 0 ? false : true;
		}

		private void OnPurchaseCardItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.CardDetailResponse card = e.Item as Models.CardDetailResponse;
			listPurchaseCard.SelectedItem = null;
			viewModel.CardDetailsCommand.Execute(card.id);
		}
	}
}