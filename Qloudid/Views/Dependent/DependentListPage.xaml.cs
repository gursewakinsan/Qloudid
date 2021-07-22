using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Dependent
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DependentListPage : ContentPage
	{
		DependentListPageViewModel viewModel;
		public DependentListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new DependentListPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetAllDependentCommand.Execute(null);
		}

		private void OnDependentItemTapped(object sender, ItemTappedEventArgs e)
		{
			listDependent.SelectedItem = null;
		}
	}
}