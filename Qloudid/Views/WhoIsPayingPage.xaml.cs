using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WhoIsPayingPage : ContentPage
	{
		WhoIsPayingPageViewModel viewModel;
		public WhoIsPayingPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WhoIsPayingPageViewModel(this.Navigation);
			viewModel.GetInvoiceAddressCommand.Execute(null);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private void InvoiceAddressSelectedIndexChanged(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (viewModel != null)
			{
				Models.InvoiceAddressResponse invoiceAddress = picker.SelectedItem as Models.InvoiceAddressResponse;
				if (invoiceAddress != null)
				{
					viewModel.InvoiceAddressId = invoiceAddress.Id;
					viewModel.InvoiceAddressDetailCommand.Execute(null);
				}
			}
		}

		private void OnInvoiceAddressItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.InvoiceAddressResponse address = e.Item as Models.InvoiceAddressResponse;
			listInvoiceAddress.SelectedItem = null;
			viewModel.InvoiceAddressId = address.Id;
			viewModel.InvoiceAddressDetail = address;
			foreach (var invoiceAddress in viewModel.ListOfInvoiceAddress)
			{
				foreach (var item in invoiceAddress)
				{
					if (item.Id.Equals(address.Id))
					{
						address.IsSelect = !address.IsSelect;
						viewModel.IsSubmit = address.IsSelect;
					}
					else
						item.IsSelect = false;
				}
			}
		}
	}
}