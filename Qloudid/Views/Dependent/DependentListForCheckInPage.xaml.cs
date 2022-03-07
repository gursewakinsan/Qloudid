using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Dependent
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DependentListForCheckInPage : ContentPage
	{
		DependentListForCheckInPageViewModel viewModel;
		public DependentListForCheckInPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new DependentListForCheckInPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetAllDependentCommand.Execute(null);
		}

		private void OnDependentItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.DependentResponse dependent = e.Item as Models.DependentResponse;
			listDependent.SelectedItem = null;
			if (dependent != null)
			{
				if (viewModel.SelectedDependents == null)
					viewModel.SelectedDependents = new System.Collections.Generic.List<int>();

				if (viewModel.SelectedDependents.Count < viewModel.GuestChildrenRemainingCount)
				{
					if (dependent.IsChecked)
					{
						dependent.IsChecked = false;
						viewModel.SelectedDependents.Remove(dependent.Id);
					}
					else
					{
						dependent.IsChecked = true;
						viewModel.SelectedDependents.Add(dependent.Id);
					}
				}
				else
				{
					if (dependent.IsChecked)
					{
						dependent.IsChecked = false;
						viewModel.SelectedDependents.Remove(dependent.Id);
					}
				}
			}
		}
	}
}