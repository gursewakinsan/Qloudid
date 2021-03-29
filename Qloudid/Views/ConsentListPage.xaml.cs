using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsentListPage : ContentPage
	{
		ConsentListPageViewModel viewModel;
		public ConsentListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new ConsentListPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			viewModel.EmployerRequestReceivedCommand.Execute(null);
			base.OnAppearing();
		}

		private void OnConsentItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.EmployerResponse employer = e.Item as Models.EmployerResponse;
			listConsent.SelectedItem = null;
			viewModel.EmployerDetails = employer;
			viewModel.EmployerDetailsCommand.Execute(null);
		}
	}
}