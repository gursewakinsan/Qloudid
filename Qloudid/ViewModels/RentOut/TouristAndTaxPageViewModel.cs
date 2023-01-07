using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class TouristAndTaxPageViewModel : BaseViewModel
    {
		#region Constructor.
		public TouristAndTaxPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
			SelectedTaxAmount = Address.TouristTax;
			if (Address.TouristTaxApplicable)
			{
				TouristTaxYesBg = Color.FromHex("#0C8CE8");
				TouristTaxNoBg = Color.Transparent;
			}
			else
			{
				TouristTaxYesBg = Color.Transparent;
				TouristTaxNoBg = Color.FromHex("#0C8CE8");
			}
		}
		#endregion

		#region Update Tourist Tax Command.
		private ICommand updateTouristTaxCommand;
		public ICommand UpdateTouristTaxCommand
		{
			get => updateTouristTaxCommand ?? (updateTouristTaxCommand = new Command(async () => await ExecuteUpdateTouristTaxCommand()));
		}
		private async Task ExecuteUpdateTouristTaxCommand()
		{
			if (Address.TouristTaxApplicable && SelectedTaxAmount.Equals("0"))
				await Helper.Alert.DisplayAlert("Tax amount cannot be zero.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IRentOutService service = new RentOutService();
				await service.UpdateTouristTaxAsync(new Models.UpdateTouristTaxRequest()
				{
					ApartmentId = Address.Id,
					TouristTax = Address.TouristTaxApplicable ? SelectedTaxAmount : "0",
					TouristTaxApplicable = Address.TouristTaxApplicable ? 1 : 0
				});
				await Navigation.PopAsync();
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Tourist Tax Command.
		private ICommand touristTaxCommand;
		public ICommand TouristTaxCommand
		{
			get => touristTaxCommand ?? (touristTaxCommand = new Command<string>((tax) => ExecuteTouristTaxCommand(tax)));
		}
		private void ExecuteTouristTaxCommand(string tax)
		{
			switch (tax)
			{
				case "Yes":
					TouristTaxYesBg = Color.FromHex("#0C8CE8");
					TouristTaxNoBg = Color.Transparent;
					break;
				case "No":
					TouristTaxYesBg = Color.Transparent;
					TouristTaxNoBg = Color.FromHex("#0C8CE8");
					break;
			}
			Address.TouristTaxApplicable = !Address.TouristTaxApplicable;
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

		private Color touristTaxNoBg;
		public Color TouristTaxNoBg
		{
			get => touristTaxNoBg;
			set
			{
				touristTaxNoBg = value;
				OnPropertyChanged("TouristTaxNoBg");
			}
		}

		private Color touristTaxYesBg;
		public Color TouristTaxYesBg
		{
			get => touristTaxYesBg;
			set
			{
				touristTaxYesBg = value;
				OnPropertyChanged("TouristTaxYesBg");
			}
		}

		private string selectedTaxAmount;
		public string SelectedTaxAmount
		{
			get => selectedTaxAmount;
			set
			{
				selectedTaxAmount = value;
				OnPropertyChanged("SelectedTaxAmount");
			}
		}
		#endregion
	}
}
