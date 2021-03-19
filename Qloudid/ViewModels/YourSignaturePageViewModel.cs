using Qloudid.Helper;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class YourSignaturePageViewModel : BaseViewModel
	{
		#region Constructor.
		public YourSignaturePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			//BindData();
		}
		#endregion

		#region Confirm And Sign Command.
		private ICommand confirmAndSignCommand;
		public ICommand ConfirmAndSignCommand
		{
			get => confirmAndSignCommand ?? (confirmAndSignCommand = new Command(async () => await ExecuteConfirmAndSignCommand()));
		}
		private async Task ExecuteConfirmAndSignCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.ConfirmAndSignSignaturePage());
			await Task.CompletedTask;
		}
		#endregion

		#region Cancel Confirm And Sign Command.
		private ICommand cancelConfirmAndSignCommand;
		public ICommand CancelConfirmAndSignCommand
		{
			get => cancelConfirmAndSignCommand ?? (cancelConfirmAndSignCommand = new Command(async () => await ExecuteCancelConfirmAndSignCommand()));
		}
		private async Task ExecuteCancelConfirmAndSignCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Edit Delivery Address Command.
		private ICommand editDeliveryAddressCommand;
		public ICommand EditDeliveryAddressCommand
		{
			get => editDeliveryAddressCommand ?? (editDeliveryAddressCommand = new Command(async () => await ExecuteEditDeliveryAddressCommand()));
		}
		private async Task ExecuteEditDeliveryAddressCommand()
		{
			Helper.Helper.IsEditAddressFromYourSignature = true;
			Application.Current.MainPage = new NavigationPage(new Views.AddressesListPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Edit Invoicing Address Command.
		private ICommand editInvoicingAddressCommand;
		public ICommand EditInvoicingAddressCommand
		{
			get => editInvoicingAddressCommand ?? (editInvoicingAddressCommand = new Command(async () => await ExecuteEditInvoicingAddressCommand()));
		}
		private async Task ExecuteEditInvoicingAddressCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.WhoIsPayingPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Edit Card Detail Command.
		private ICommand editCardDetailCommand;
		public ICommand EditCardDetailCommand
		{
			get => editCardDetailCommand ?? (editCardDetailCommand = new Command(async () => await ExecuteEditCardDetailCommand()));
		}
		private async Task ExecuteEditCardDetailCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.FinalStepToPayPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Bind Data.
		/*void BindData()
		{
			var dAddress = Helper.Helper.DeliveryAddressDetail;
			if (dAddress != null)
				DeliveryAddress = $"{dAddress.CompanyName}, {dAddress.NameOnHouse} {dAddress.Address} {dAddress.Zipcode} {dAddress.City}, {dAddress.CountryName}";

			var iAddress = Helper.Helper.InvoiceAddressDetail;
			if (iAddress != null)
				InvoiceAddress = $"{iAddress.NameOnHouse}, {iAddress.InvoiceAddress} {iAddress.InvoiceZip} {iAddress.InvoiceCity}, {iAddress.InvoiceCountry}";

			var cc = Helper.Helper.CardDetail;
			if (cc != null)
			{
				string space = string.Empty;
				CardDetail = $"Card {space.PadLeft(20)} **** **** ****  {cc.card_number2.GetLast(4)}";
			}
		}*/
		#endregion

		#region Properties.
		public Models.DeliveryAddressDetailResponse DeliveryAddress => Helper.Helper.DeliveryAddressDetail;
		public Models.InvoiceAddressResponse InvoiceAddress => Helper.Helper.InvoiceAddressDetail;
		public Models.CardDetailResponse CardDetail => Helper.Helper.CardDetail;
		#endregion
	}
}
