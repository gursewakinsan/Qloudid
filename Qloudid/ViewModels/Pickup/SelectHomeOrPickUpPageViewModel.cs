using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class SelectHomeOrPickUpPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SelectHomeOrPickUpPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			BindList();
		}
		#endregion

		#region Bind List.
		void BindList()
		{
			List<Models.SelectHomeOrPickUp> listHomeOrPickup = new List<Models.SelectHomeOrPickUp>();
			listHomeOrPickup.Add(new Models.SelectHomeOrPickUp()
			{
				Id = 0,
				HeadingAddress = "Home delivery",
				//SubHeadingAddress = "To be sent on delivery address",
				//FirstLetterNameBg = Helper.Helper.ColorList[0]
			});

			listHomeOrPickup.Add(new Models.SelectHomeOrPickUp()
			{
				Id = 1,
				HeadingAddress = "Pick up",
				//SubHeadingAddress = "To be picked personally",
				//FirstLetterNameBg = Helper.Helper.ColorList[1]
			});
			ListOfSelectHomeOrPickUpAddress = listHomeOrPickup;
		}
		#endregion

		#region Selected Home Address Command.
		private ICommand selectedHomeAddressCommand;
		public ICommand SelectedHomeAddressCommand
		{
			get => selectedHomeAddressCommand ?? (selectedHomeAddressCommand = new Command(async () => await ExecuteSelectedHomeAddressCommand()));
		}
		private async Task ExecuteSelectedHomeAddressCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			Models.EditAddressResponse address = new Models.EditAddressResponse()
			{
				Id = Helper.Helper.DeliveryAddressDetail.Id,
				DeliveredAt = Helper.Helper.UserOrCompanyAddress > 1 ? 0 : 1,
				CertificateKey = Helper.Helper.QrCertificateKey
			};
			int response = await service.UpdateCompanyAddressAsync(address);
			if (Helper.Helper.IsEditDeliveryAddressFromInvoicing)
			{
				Helper.Helper.IsEditDeliveryAddressFromInvoicing = false;
				await Navigation.PushAsync(new Views.ReadOnlyInvoicingAddressPage());
			}
			else if (Helper.Helper.IsEditAddressFromYourSignature)
			{
				Helper.Helper.IsEditAddressFromYourSignature = false;
				await Navigation.PushAsync(new Views.YourSignaturePage());
			}
			else
			{
				Helper.Helper.IsPickupAddress = false;
				await Navigation.PushAsync(new Views.ReadOnlyDeliveryAddressPage());
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Pickup Delivery Command.
		private ICommand updatePickupDeliveryCommand;
		public ICommand UpdatePickupDeliveryCommand
		{
			get => updatePickupDeliveryCommand ?? (updatePickupDeliveryCommand = new Command(async () => await ExecuteUpdatePickupDeliveryCommand()));
		}
		private async Task ExecuteUpdatePickupDeliveryCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IPickupService service = new PickupService();
			await service.UpdatePickupDeliveryAsync(new Models.UpdatePickupDeliveryRequest()
			{
				Certificate = Helper.Helper.QrCertificateKey,
				DeliveryType = Helper.Helper.IsPickupAddress ? 1 : 0
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage.Navigation.PushAsync(new Views.SignInFromOtherCompanyPage(""));
		}
		#endregion

		#region Properties.
		private List<Models.SelectHomeOrPickUp> listOfSelectHomeOrPickUpAddress;
		public List<Models.SelectHomeOrPickUp> ListOfSelectHomeOrPickUpAddress
		{
			get { return listOfSelectHomeOrPickUpAddress; }
			set
			{
				listOfSelectHomeOrPickUpAddress = value;
				OnPropertyChanged("ListOfSelectHomeOrPickUpAddress");
			}
		}
		#endregion
	}
}