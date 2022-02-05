using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.DstrictsAppPayOn
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardListPageForPayOn : ContentPage
	{
		CardListPageForPayOnViewModel viewModel;
		public CardListPageForPayOn()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CardListPageForPayOnViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetCardListCommand.Execute(null);
		}

		private void OnPurchaseCardItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.CardDetailResponse card = e.Item as Models.CardDetailResponse;
			listPurchaseCard.SelectedItem = null;
			viewModel.SubmitCardDetailsCommand.Execute(card.id);
		}

		private void OnButtonFirstLetterNameClicked(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			Models.CardDetailResponse card = button.BindingContext as Models.CardDetailResponse;
			listPurchaseCard.SelectedItem = null;
			viewModel.SubmitCardDetailsCommand.Execute(card.id);
		}

		private void OnStackLayoutCardInfoTapped(object sender, System.EventArgs e)
		{
			StackLayout layout = sender as StackLayout;
			Models.CardDetailResponse card = layout.BindingContext as Models.CardDetailResponse;
			listPurchaseCard.SelectedItem = null;
			viewModel.SubmitCardDetailsCommand.Execute(card.id);
		}

		private void OnLabelCardInfoTapped(object sender, System.EventArgs e)
		{
			Label label = sender as Label;
			Models.CardDetailResponse card = label.BindingContext as Models.CardDetailResponse;
			listPurchaseCard.SelectedItem = null;
			viewModel.SubmitCardDetailsCommand.Execute(card.id);
		}
	}
}