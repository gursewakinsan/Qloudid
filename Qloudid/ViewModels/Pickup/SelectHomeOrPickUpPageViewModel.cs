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
			var list = new List<Models.SelectHomeOrPickUpInfo>();
			Models.SelectHomeOrPickUpInfo listHomeOrPickup = new Models.SelectHomeOrPickUpInfo();
			listHomeOrPickup.SelectHomeOrPickUpAddress.Add(new Models.SelectHomeOrPickUp()
			{
				Id = 0,
				HeadingAddress = "Home Delivery",
				SubHeadingAddress = "To be sent on delivery address",
				FirstLetterNameBg = Helper.Helper.ColorList[0]
			});

			listHomeOrPickup.SelectHomeOrPickUpAddress.Add(new Models.SelectHomeOrPickUp()
			{
				Id = 1,
				HeadingAddress = "Pick Up",
				SubHeadingAddress = "To be picked personally",
				FirstLetterNameBg = Helper.Helper.ColorList[1]
			});

			listHomeOrPickup.Heading = "Delivery Type";
			list.Add(listHomeOrPickup);

			ListOfSelectHomeOrPickUpAddress = list;
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
		}
		#endregion

		#region Properties.
		private List<Models.SelectHomeOrPickUpInfo> listOfSelectHomeOrPickUpAddress;
		public List<Models.SelectHomeOrPickUpInfo> ListOfSelectHomeOrPickUpAddress
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