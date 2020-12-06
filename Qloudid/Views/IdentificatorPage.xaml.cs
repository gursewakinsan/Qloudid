using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IdentificatorPage : ContentPage
	{
		IdentificatorPageViewModel viewModel;
		public IdentificatorPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new IdentificatorPageViewModel(this.Navigation);
		}

		#region Identificator Selected Index Changed.
		private void PickerSelectedIndexChanged(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				viewModel.SelectedIdentificator = picker.SelectedItem as Models.Identificator;
				switch (viewModel.SelectedIdentificator.Id)
				{
					case 0:
						viewModel.IsShowIdentificator = false;
						break;
					case 1:
						viewModel.IsShowIdentificator = true;
						txtIdentificator.Placeholder = "ID number";
						break;
					case 2:
						viewModel.IsShowIdentificator = true;
						txtIdentificator.Placeholder = "Driver license number";
						break;
					case 3:
						viewModel.IsShowIdentificator = true;
						txtIdentificator.Placeholder = "Passport number";
						break;
				}
			}
		}
		#endregion

		#region Issue Month Selected Index Changed.
		private void PickerIssueMonthSelectedIndexChanged(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				if (picker.SelectedItem.Equals("Select"))
					viewModel.IssueMonth = 0;
				else
					viewModel.IssueMonth = Convert.ToInt32(picker.SelectedItem);
			}
		}
		#endregion

		#region Issue Year Selected Index Changed.
		private void PickerIssueYearSelectedIndexChanged(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				if (picker.SelectedItem.Equals("Select"))
					viewModel.IssueYear = 0;
				else
					viewModel.IssueYear = Convert.ToInt32(picker.SelectedItem);
			}
		}
		#endregion

		#region Expiry Month Selected Index Changed.
		private void PickerExpiryMonthSelectedIndexChanged(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				if (picker.SelectedItem.Equals("Select"))
					viewModel.ExpiryMonth = 0;
				else
					viewModel.ExpiryMonth = Convert.ToInt32(picker.SelectedItem);
			}
		}
		#endregion

		#region Expiry Year Selected Index Changed.
		private void PickerExpiryYearSelectedIndexChanged(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				if (picker.SelectedItem.Equals("Select"))
					viewModel.ExpiryYear = 0;
				else
					viewModel.ExpiryYear = Convert.ToInt32(picker.SelectedItem);
			}
		}
		#endregion
	}
}