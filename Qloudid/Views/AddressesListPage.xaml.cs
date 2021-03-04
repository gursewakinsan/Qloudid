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
			if (!Helper.Helper.IsAddMoreAddresses)
				viewModel.GetAllAddressCommand.Execute(null);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private void OnAddressesItemTapped(object sender, ItemTappedEventArgs e)
		{
			Helper.Helper.DeliveryAddress = e.Item as Models.AddressesResponse;
			//listAddresses.SelectedItem = null;
			viewModel.EditAddressCommand.Execute(null);
		}

		private void AddressesListSelectedIndexChanged(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				Models.AddressesResponse address = picker.SelectedItem as Models.AddressesResponse;
				if (address != null)
				{
					viewModel.SelectedAddressId = address.Id;
					viewModel.GetDeliveryAddressDetailCommand.Execute(null);
				}
			}
		}
	}
}