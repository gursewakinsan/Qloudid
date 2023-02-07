using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OwnershipUpdatedPage : ContentPage
	{
		OwnershipUpdatedPageViewModel viewModel;
		public OwnershipUpdatedPage ()
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new OwnershipUpdatedPageViewModel(this.Navigation);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			viewModel.GetAddressByIdCommand.Execute(null);
		}

        private void OnBoughtOrRentSelectedIndexChanged(object sender, System.EventArgs e)
        {
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				if (picker.SelectedIndex == 0)
				{
					viewModel.RentContractOnYou = 0;
					viewModel.AllowedToRentOut = 0;
				}
				else
				{
					viewModel.BoughtByYou = 0;
					viewModel.BoughtRentAllowed = 0;
				}
				//viewModel.OwnershipDetail = picker.SelectedIndex + 1;
			}
		}

        private void OnIsItYoursSelectedIndexChanged(object sender, System.EventArgs e)
        {
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				/*if (picker.SelectedIndex == 0)
					viewModel.BoughtByYou = 1;
				else
					viewModel.BoughtByYou = 0;*/
			}
		}

        private void OnAllowedToRentOutSelectedIndexChanged(object sender, System.EventArgs e)
        {
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				/*if (picker.SelectedIndex == 0)
					viewModel.BoughtRentAllowed = 1;
				else
					viewModel.BoughtRentAllowed = 0;*/
			}
		}

        private void OnContractOnYouSelectedIndexChanged(object sender, System.EventArgs e)
        {
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				if (picker.SelectedIndex == 0)
				{
					lbl.IsVisible = true;
					frame.IsVisible = true;
					//viewModel.RentContractOnYou = 1;
				}
				else
				{
					lbl.IsVisible = false;
					frame.IsVisible = false;
					//viewModel.RentContractOnYou = 0;
				}
			}
		}

        private void OnAreYouAllowedSelectedIndexChanged(object sender, System.EventArgs e)
        {
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				/*if (picker.SelectedIndex == 0)
					viewModel.AllowedToRentOut = 1;
				else
					viewModel.AllowedToRentOut = 0;*/
			}
		}
    }
}