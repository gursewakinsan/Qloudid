using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardListPage : ContentPage
	{
		CardListPageViewModel viewModel;
		public CardListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CardListPageViewModel(this.Navigation);
			
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (!Helper.Helper.IsAddMoreCard)
				viewModel.GetAllCardCommand.Execute(null);
		}

		private void OnCardsItemTapped(object sender, ItemTappedEventArgs e)
		{
			listCards.SelectedItem = null;
		}
	}
}