using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.PreCheckIn
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdultsAndChildrenInfoPage : ContentPage
	{
		AdultsAndChildrenInfoPageViewModel viewModel;
		int guestChildren = 0;
		int guestAdult = 0;
		public AdultsAndChildrenInfoPage(int _guestChildren, int _guestAdult)
		{
			InitializeComponent();
			guestChildren = _guestChildren;
			guestAdult = _guestAdult;
			BindingContext = viewModel = new AdultsAndChildrenInfoPageViewModel(this.Navigation);
			if (guestChildren == 0)
				viewModel.IsGuestChildren = false;
			else
				viewModel.IsGuestChildren = true;
			viewModel.TotalCount = guestChildren + guestAdult;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			BindableLayout.SetItemsSource(layoutInviteAdults, new string[guestAdult]);
			BindableLayout.SetItemsSource(layoutAddChild, new string[guestChildren]);
			viewModel.DependentsCheckedInListCommand.Execute(null);
		}

		private async void OnAdultsTapped(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new InviteAdultsPage());
		}

		private async void OnChildrenTapped(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new DependentsListForCheckinPage());
		}

		private void OnFrameReInviteAdultsTapped(object sender, System.EventArgs e)
		{
			Frame frame = sender as Frame;
			Models.AdultsCheckedInListResponse adults = frame.BindingContext as Models.AdultsCheckedInListResponse;
			if (!adults.IsConfirmed)
				viewModel.ResendInvitationCommand.Execute(adults.Id);
		}

		private void OnGridReInviteAdultsTapped(object sender, System.EventArgs e)
		{
			Grid grid = sender as Grid;
			Models.AdultsCheckedInListResponse adults = grid.BindingContext as Models.AdultsCheckedInListResponse;
			if (!adults.IsConfirmed)
				viewModel.ResendInvitationCommand.Execute(adults.Id);
		}

		private void OnLabelReInviteAdultsTapped(object sender, System.EventArgs e)
		{
			Label label = sender as Label;
			Models.AdultsCheckedInListResponse adults = label.BindingContext as Models.AdultsCheckedInListResponse;
			if (!adults.IsConfirmed)
				viewModel.ResendInvitationCommand.Execute(adults.Id);
		}

		private void OnButtonReInviteAdultsTapped(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			Models.AdultsCheckedInListResponse adults = button.BindingContext as Models.AdultsCheckedInListResponse;
			if (!adults.IsConfirmed)
				viewModel.ResendInvitationCommand.Execute(adults.Id);
		}
	}
}