using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FinalStepToPayPage : ContentPage
	{
		FinalStepToPayPageViewModel viewModel;
		public FinalStepToPayPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new FinalStepToPayPageViewModel(this.Navigation);
			viewModel.GetAllCardCommand.Execute(null);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private void CardListSelectedIndexChanged(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				Models.CardDetailResponse card = picker.SelectedItem as Models.CardDetailResponse;
				if (card != null)
				{
					viewModel.CardId = card.id;
					viewModel.GetCardDetailsCommand.Execute(null);
				}
			}
		}
	}
}