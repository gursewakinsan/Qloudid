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
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetInvoiceAddressCommand.Execute(null);
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
	}
}