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
				viewModel.GetDeliveryAddressCommand.Execute(null);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			//btnText.Text = Helper.Helper.QloudidPayButtonText;
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

		private void OnDeliveryAddressItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.UserAddress address = e.Item as Models.UserAddress;
			viewModel.SelectedAddressId = address.Id;
			Helper.Helper.UserOrCompanyAddress = address.User_address;
			listDeliveryAddress.SelectedItem = null;
			/*foreach (var deliveryAddress in viewModel.ListOfDeliveryAddress)
			{
				foreach (var item in deliveryAddress)
				{
					if (item.Id.Equals(address.Id))
					{
						address.IsSelect = !address.IsSelect;
						viewModel.IsSubmit = address.IsSelect;
					}
					else
						item.IsSelect = false;
				}
			}*/
			Helper.Helper.IsPickupAddress = false;
			viewModel.GetDeliveryAddressDetailCommand.Execute(null);
		}

		private void btnText_Clicked(object sender, System.EventArgs e)
		{
			Helper.Helper.QloudidPayButtonText = "Qloud ID Pay";
			//if (btnText.Text.Equals("Pickup Address"))
				//Application.Current.MainPage = new NavigationPage(new Pickup.PickUpAddressListPage());
		}
	}
}