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

		private async void OnPickupAddressItemTapped(object sender, ItemTappedEventArgs e)
		{
			Helper.Helper.IsPickupAddress = true;
			Helper.Helper.SelectedPickupAddress = e.Item as Models.PickupAddressDetailResponse;
			listPickupAddress.SelectedItem = null;
			await Navigation.PushAsync(new ReadOnlyDeliveryAddressPage());
		}
	}
}