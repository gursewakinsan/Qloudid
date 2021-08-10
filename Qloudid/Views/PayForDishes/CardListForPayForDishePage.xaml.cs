using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.PayForDishes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardListForPayForDishePage : ContentPage
	{
		CardListForPayForDisheViewModel viewModel;
		public CardListForPayForDishePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CardListForPayForDisheViewModel(this.Navigation);
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
		}
	}
}