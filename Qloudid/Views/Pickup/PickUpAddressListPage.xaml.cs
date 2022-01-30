using Xamarin.Forms;
using Qloudid.ViewModels;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views.Pickup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickUpAddressListPage : ContentPage
	{
		PickUpAddressListPageViewModel viewModel;
		public PickUpAddressListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new PickUpAddressListPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			btnText.Text = Helper.Helper.QloudidPayButtonText;
		}

		private async void OnPickupAddressItemTapped(object sender, ItemTappedEventArgs e)
		{
			Helper.Helper.IsPickupAddress = true;
			Helper.Helper.SelectedPickupAddress = e.Item as Models.PickupAddressDetailResponse;
			listPickupAddress.SelectedItem = null;
			viewModel.UpdatePickupAddressCommand.Execute(null);
			if (Helper.Helper.IsEditDeliveryAddressFromInvoicing)
			{
				Helper.Helper.IsEditDeliveryAddressFromInvoicing = false;
				Application.Current.MainPage = new NavigationPage(new ReadOnlyInvoicingAddressPage());
			}
			else if (Helper.Helper.IsEditAddressFromYourSignature)
			{
				Helper.Helper.IsEditAddressFromYourSignature = false;
				Application.Current.MainPage = new NavigationPage(new YourSignaturePage());
			}
			else
				await Navigation.PushAsync(new ReadOnlyDeliveryAddressPage());
		}

		private void btnText_Clicked(object sender, System.EventArgs e)
		{
			Helper.Helper.QloudidPayButtonText = "Qloud ID Pay";
			if (btnText.Text.Equals("Delivery Address"))
				Application.Current.MainPage = new NavigationPage(new AddressesListPage());
		}
	}
}