using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddDeliveryAddressPage : ContentPage
	{
		AddDeliveryAddressViewModel viewModel;
		public AddDeliveryAddressPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AddDeliveryAddressViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (!Helper.Helper.IsAddMoreAddresses)
				viewModel.UserDeliveryInvoiceInfoCommand.Execute(null);
		}
	}
}