﻿using Xamarin.Forms;
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

		private void OnCardsItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.CardDetailResponse card = e.Item as Models.CardDetailResponse;
			viewModel.CardId = card.id;
			viewModel.CardDetail = card;
			listCards.SelectedItem = null;
			/*foreach (var item in viewModel.CardList)
			{
				if (item.id.Equals(card.id))
				{
					card.IsSelect = !card.IsSelect;
					viewModel.IsSubmit = card.IsSelect;
				}
				else
					item.IsSelect = false;
			}*/
			viewModel.SelectedFinalStepToPayCommand.Execute(null);
		}

		private void OnButtonFirstLetterNameClicked(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			Models.CardDetailResponse card = button.BindingContext as Models.CardDetailResponse;
			viewModel.CardId = card.id;
			viewModel.CardDetail = card;
			viewModel.SelectedFinalStepToPayCommand.Execute(null);
		}

		private void OnStackLayoutCardInfoTapped(object sender, System.EventArgs e)
		{
			StackLayout layout = sender as StackLayout;
			Models.CardDetailResponse card = layout.BindingContext as Models.CardDetailResponse;
			viewModel.CardId = card.id;
			viewModel.CardDetail = card;
			viewModel.SelectedFinalStepToPayCommand.Execute(null);
		}

		private void OnLabelCardInfoTapped(object sender, System.EventArgs e)
		{
			Label label = sender as Label;
			Models.CardDetailResponse card = label.BindingContext as Models.CardDetailResponse;
			viewModel.CardId = card.id;
			viewModel.CardDetail = card;
			viewModel.SelectedFinalStepToPayCommand.Execute(null);
		}
	}
}