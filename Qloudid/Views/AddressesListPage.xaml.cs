using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddressesListPage : ContentPage
	{
		AddressesListPageViewModel viewModel;
		public AddressesListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AddressesListPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (!Helper.Helper.IsAddMoreAddresses)
				viewModel.GetAllAddressCommand.Execute(null);
		}

		private void OnAddressesItemTapped(object sender, ItemTappedEventArgs e)
		{
			listAddresses.SelectedItem = null;
		}
	}
}