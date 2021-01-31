using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardDetailsPage : ContentPage
	{
		CardDetailsPageViewModel viewModel;
		public CardDetailsPage(int cardId, int companyId)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CardDetailsPageViewModel(this.Navigation);
			viewModel.CardId = cardId;
			viewModel.CompanyId = companyId;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetCardDetailsCommand.Execute(null);
		}
	}
}