using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditCardToPayPage : ContentPage
	{
		EditCardToPayPageViewModel viewModel;
		public EditCardToPayPage(Models.CardDetailResponse card)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new EditCardToPayPageViewModel(this.Navigation);
			viewModel.CardDetailForEdit = card;
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.BindCardDetailCommand.Execute(null);
		}
	}
}