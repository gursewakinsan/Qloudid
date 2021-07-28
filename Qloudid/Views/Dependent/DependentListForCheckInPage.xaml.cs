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
				dependent.IsChecked = !dependent.IsChecked;
				if (viewModel.SelectedDependents == null)
					viewModel.SelectedDependents = new System.Collections.Generic.List<int>();
				if (dependent.IsChecked)
					viewModel.SelectedDependents.Add(dependent.Id);
				else
					viewModel.SelectedDependents.Remove(dependent.Id);
			}
		}
	}
}