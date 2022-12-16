using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class NightlyPricingPageViewModel : BaseViewModel
    {
		#region Constructor.
		public NightlyPricingPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
			ManualBg = Color.FromHex("#0C8CE8");
		}
		#endregion

		#region Selected Price Command.
		private ICommand selectedPriceCommand;
		public ICommand SelectedPriceCommand
		{
			get => selectedPriceCommand ?? (selectedPriceCommand = new Command<string>((selectedPrice) => ExecuteSelectedPriceCommand(selectedPrice)));
		}
		private void ExecuteSelectedPriceCommand(string selectedPrice)
		{
			switch (selectedPrice)
			{
				case "Manual":
					ManualBg = Color.FromHex("#0C8CE8");
					GenericBg = Color.Transparent;
					break;
				case "Generic":
					ManualBg = Color.Transparent;
					GenericBg = Color.FromHex("#0C8CE8");
					break;
			}
		}
		#endregion

		#region Properties.
		private Models.EditAddressResponse address;
		public Models.EditAddressResponse Address
		{
			get => address;
			set
			{
				address = value;
				OnPropertyChanged("Address");
			}
		}

		private bool isPageLoad = false;
		public bool IsPageLoad
		{
			get => isPageLoad;
			set
			{
				isPageLoad = value;
				OnPropertyChanged("IsPageLoad");
			}
		}

		private Color manualBg;
		public Color ManualBg
		{
			get => manualBg;
			set
			{
				manualBg = value;
				OnPropertyChanged("ManualBg");
			}
		}

		private Color genericBg;
		public Color GenericBg
		{
			get => genericBg;
			set
			{
				genericBg = value;
				OnPropertyChanged("GenericBg");
			}
		}
		#endregion
	}
}
