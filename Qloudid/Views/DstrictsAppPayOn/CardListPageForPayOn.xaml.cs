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
	}
}