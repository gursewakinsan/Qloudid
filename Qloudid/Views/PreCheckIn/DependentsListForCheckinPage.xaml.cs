using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.PreCheckIn
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DependentsListForCheckinPage : ContentPage
	{
		DependentsListForCheckinPageViewModel viewModel;
		public DependentsListForCheckinPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new DependentsListForCheckinPageViewModel(this.Navigation);
			viewModel.DependentsListForCheckinDstrictCommand.Execute(null);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private void OnDependentsForCheckinItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.DependentsListForCheckinDstrictResponse response = e.Item as Models.DependentsListForCheckinDstrictResponse;
			listDependentsForCheckin.SelectedItem = null;
			foreach (var item in viewModel.DependentsListForCheckinInfo)
			{
				if (item.Id.Equals(response.Id))
				{
					item.IsSelect = true;
					if (!btnSubmit.IsVisible)
						btnSubmit.IsVisible = true;
					item.FrameBorderColor = Color.FromHex("#0F9D58");
				}
				else
				{
					item.IsSelect = false;
					item.FrameBorderColor = Color.FromHex("#2A2A31");
				}
			}
		}
	}
}