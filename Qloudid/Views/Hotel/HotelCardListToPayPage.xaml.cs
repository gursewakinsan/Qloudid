using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HotelCardListToPayPage : ContentPage
	{
		HotelCardListToPayViewModel viewModel;
		public HotelCardListToPayPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new HotelCardListToPayViewModel(this.Navigation);
			viewModel.GetAllCardCommand.Execute(null);
		}

		private void OnCardsItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.CardDetailResponse card = e.Item as Models.CardDetailResponse;
			viewModel.CardId = card.id;
			viewModel.CardDetail = card;
			listCards.SelectedItem = null;
			viewModel.SelectedFinalStepToPayCommand.Execute(null);
		}
	}
}