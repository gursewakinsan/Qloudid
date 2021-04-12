using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HotelInvoiceAddressListPage : ContentPage
	{
		HotelInvoiceAddressListPageViewModel viewModel;
		public HotelInvoiceAddressListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new HotelInvoiceAddressListPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetInvoiceAddressCommand.Execute(null);
		}

		private void OnInvoiceAddressItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.InvoiceAddressResponse address = e.Item as Models.InvoiceAddressResponse;
			listInvoiceAddress.SelectedItem = null;
			viewModel.InvoiceAddressId = address.Id;
			viewModel.InvoiceAddressDetail = address;
			viewModel.SelectedPayingCommand.Execute(null);
		}
	}
}