using Xamarin.Forms;
using Qloudid.ViewModels;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views.Pickup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectHomeOrPickUpPage : ContentPage
	{
		SelectHomeOrPickUpPageViewModel viewModel;
		public SelectHomeOrPickUpPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SelectHomeOrPickUpPageViewModel(this.Navigation);
		}

		private async void OnHomeOrPickUpItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.SelectHomeOrPickUp homeOrPickUp = e.Item as Models.SelectHomeOrPickUp;
			listHomeOrPickUp.SelectedItem = null;
			switch (homeOrPickUp.Id)
			{
				case 0: //Go to Home Delivery
					Helper.Helper.IsPickupAddress = false;
					await Navigation.PushAsync(new AddressesListPage());
					//viewModel.SelectedHomeAddressCommand.Execute(null);
					break;
				case 1: //Go to Pick Up
					Helper.Helper.IsPickupAddress = true;
					await Navigation.PushAsync(new PickUpAddressListPage());
					break;
			}
			Helper.Helper.QloudidPayButtonText = "Qloud ID Pay";
			viewModel.UpdatePickupDeliveryCommand.Execute(null);
		}
	}
}