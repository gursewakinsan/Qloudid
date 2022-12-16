using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class SecurityDepositPageViewModel : BaseViewModel
    {
		#region Constructor.
		public SecurityDepositPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
			if (Address.SecurityFeeApplicable)
			{
				SecurityDepositYesBg = Color.FromHex("#0C8CE8");
				SecurityDepositNoBg = Color.Transparent;
			}
			else
			{
				SecurityDepositYesBg = Color.Transparent;
				SecurityDepositNoBg = Color.FromHex("#0C8CE8");
			}
		}
		#endregion

		#region Security Deposit Command.
		private ICommand securityDepositCommand;
		public ICommand SecurityDepositCommand
		{
			get => securityDepositCommand ?? (securityDepositCommand = new Command<string>((selectedFee) => ExecuteSecurityDepositCommand(selectedFee)));
		}
		private void ExecuteSecurityDepositCommand(string selectedFee)
		{
			switch (selectedFee)
			{
				case "Yes":
					SecurityDepositYesBg = Color.FromHex("#0C8CE8");
					SecurityDepositNoBg = Color.Transparent;
					break;
				case "No":
					SecurityDepositYesBg = Color.Transparent;
					SecurityDepositNoBg = Color.FromHex("#0C8CE8");
					break;
			}
			Address.SecurityFeeApplicable = !Address.SecurityFeeApplicable;
		}
		#endregion

		#region Submit Security Deposit Command.
		private ICommand submitSecurityDepositCommand;
		public ICommand SubmitSecurityDepositCommand
		{
			get => submitSecurityDepositCommand ?? (submitSecurityDepositCommand = new Command(async () => await ExecuteSubmitSecurityDepositCommand()));
		}
		private async Task ExecuteSubmitSecurityDepositCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			await service.UpdateSecurityAsync(new Models.UpdateSecurityRequest()
			{
				ApartmentId = Address.Id,
				UpdateInfo = Address.SecurityFeeApplicable ? 1 : 0,
				SecurityFee = Address.SecurityFee
			});
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
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

		private Color securityDepositNoBg;
		public Color SecurityDepositNoBg
		{
			get => securityDepositNoBg;
			set
			{
				securityDepositNoBg = value;
				OnPropertyChanged("SecurityDepositNoBg");
			}
		}

		private Color securityDepositYesBg;
		public Color SecurityDepositYesBg
		{
			get => securityDepositYesBg;
			set
			{
				securityDepositYesBg = value;
				OnPropertyChanged("SecurityDepositYesBg");
			}
		}
		#endregion
	}
}
