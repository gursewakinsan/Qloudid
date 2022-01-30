using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
	public class PickUpAddressListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public PickUpAddressListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			CopyPickupAddress = Helper.Helper.PickupAddressList;
			ListOfPickupAddressDetail = new ObservableCollection<Models.PickupAddressDetailResponse>(Helper.Helper.PickupAddressList);
			//BindData();
		}
		#endregion

		#region Bind Data.
		void BindData()
		{
			var list = new List<Models.PickupAddressDetailInfo>();
			int index = 0;
			Models.PickupAddressDetailInfo listPickup = new Models.PickupAddressDetailInfo();
			foreach (var item in Helper.Helper.PickupAddressList)
			{
				item.FirstLetterNameBg = Helper.Helper.ColorList[index];
				index = index + 1;
				listPickup.Add(item);
			}
			listPickup.Heading = "Pick Up Address";
			list.Add(listPickup);

			//ListOfPickupAddressDetail = list;
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
			Helper.Helper.IsPickupAddress = false;
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
				await Navigation.PushAsync(new Views.ReadOnlyDeliveryAddressPage());
			UpdatePickupDeliveryCommand.Execute(null);
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

		#region Update Pickup Address Command.
		private ICommand updatePickupAddressCommand;
		public ICommand UpdatePickupAddressCommand
		{
			get => updatePickupAddressCommand ?? (updatePickupAddressCommand = new Command(async () => await ExecuteUpdatePickupAddressCommand()));
		}
		private async Task ExecuteUpdatePickupAddressCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IPickupService service = new PickupService();
			await service.UpdatePickupAddressAsync(new Models.UpdatePickupAddressRequest()
			{
				Certificate = Helper.Helper.QrCertificateKey,
				PickupAddressId = Helper.Helper.SelectedPickupAddress.Id
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Search Command.
		private ICommand searchCommand;
		public ICommand SearchCommand
		{
			get => searchCommand ?? (searchCommand = new Command(async () => await ExecuteSearchCommand()));
		}
		private async Task ExecuteSearchCommand()
		{
			if (!string.IsNullOrWhiteSpace(SearchText))
			{
				string text = SearchText.ToLower();
				if (CopyPickupAddress?.Count > 0)
				{
					List<Models.PickupAddressDetailResponse> addresses = null;
					addresses = CopyPickupAddress.Where(x => x.AddressForSearch.ToLower().Contains(text)).ToList();
					ListOfPickupAddressDetail = new ObservableCollection<Models.PickupAddressDetailResponse>(addresses);
				}
			}
			else
			{
				ListOfPickupAddressDetail = new ObservableCollection<Models.PickupAddressDetailResponse>(Helper.Helper.PickupAddressList);
			}
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public List<Models.PickupAddressDetailResponse> CopyPickupAddress { get; set; }

		private ObservableCollection<Models.PickupAddressDetailResponse> listOfPickupAddressDetail;
		public ObservableCollection<Models.PickupAddressDetailResponse> ListOfPickupAddressDetail
		{
			get { return listOfPickupAddressDetail; }
			set
			{
				listOfPickupAddressDetail = value;
				OnPropertyChanged("ListOfPickupAddressDetail");
			}
		}

		private string searchText;
		public string SearchText
		{
			get { return searchText; }
			set
			{
				searchText = value;
				OnPropertyChanged("SearchText");
			}
		}
		#endregion
	}
}
