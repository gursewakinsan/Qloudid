using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class CleaningFeePageViewModel : BaseViewModel
    {
		#region Constructor.
		public CleaningFeePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
			ChargeYesOrNoSelectedIndex = Address.CleeningFeeApplicable ? 1 : 0;
			CleeningByWhom = Address.CleeningByWhom;
			/*if (Address.CleeningFeeApplicable)
			{
				CleaningFeeYesBg = Color.FromHex("#0C8CE8");
				CleaningFeeNoBg = Color.Transparent;
			}
			else
			{
				CleaningFeeYesBg = Color.Transparent;
				CleaningFeeNoBg = Color.FromHex("#0C8CE8"); 
			}*/
		}
		#endregion

		#region Cleaning Fee Command.
		private ICommand cleaningFeeCommand;
		public ICommand CleaningFeeCommand
		{
			get => cleaningFeeCommand ?? (cleaningFeeCommand = new Command<string>((selectedFee) => ExecuteCleaningFeeCommand(selectedFee)));
		}
		private void ExecuteCleaningFeeCommand(string selectedFee)
		{
			switch (selectedFee)
            {
				case "Yes":
					CleaningFeeYesBg = Color.FromHex("#0C8CE8");
					CleaningFeeNoBg = Color.Transparent;
					break;
				case "No":
					CleaningFeeYesBg = Color.Transparent;
					CleaningFeeNoBg = Color.FromHex("#0C8CE8");
					break;
            }
			Address.CleeningFeeApplicable = !Address.CleeningFeeApplicable;
		}
		#endregion

		#region Submit Cleaning Fee Command.
		private ICommand submitCleaningFeeCommand;
		public ICommand SubmitCleaningFeeCommand
		{
			get => submitCleaningFeeCommand ?? (submitCleaningFeeCommand = new Command(async () => await ExecuteSubmitCleaningFeeCommand()));
		}
		private async Task ExecuteSubmitCleaningFeeCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IRentOutService service = new RentOutService();
			await service.UpdateCleeningAsync(new Models.UpdateCleeningRequest()
			{
				ApartmentId = Address.Id,
				UpdateInfo = ChargeYesOrNoSelectedIndex,
				CleeningFee = Address.CleeningFee,
				CleeningByWhom = CleeningByWhom
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

		private Color cleaningFeeNoBg;
		public Color CleaningFeeNoBg
		{
			get => cleaningFeeNoBg;
			set
			{
				cleaningFeeNoBg = value;
				OnPropertyChanged("CleaningFeeNoBg");
			}
		}

		private Color cleaningFeeYesBg;
		public Color CleaningFeeYesBg
		{
			get => cleaningFeeYesBg;
			set
			{
				cleaningFeeYesBg = value;
				OnPropertyChanged("CleaningFeeYesBg");
			}
		}

		private int chargeYesOrNoSelectedIndex;
		public int ChargeYesOrNoSelectedIndex
		{
			get => chargeYesOrNoSelectedIndex;
			set
			{
				chargeYesOrNoSelectedIndex = value;
				if (value == 0)
				{
					Address.CleeningFee = 0;
					IsCleeningFeeReadOnly = true;
				}
				else
					IsCleeningFeeReadOnly = false;
				OnPropertyChanged("ChargeYesOrNoSelectedIndex");
			}
		}

		private bool isCleeningFeeReadOnly;
		public bool IsCleeningFeeReadOnly
		{
			get => isCleeningFeeReadOnly;
			set
			{
				isCleeningFeeReadOnly = value;
				OnPropertyChanged("IsCleeningFeeReadOnly");
			}
		}

		private int cleeningByWhom;
		public int CleeningByWhom
		{
			get => cleeningByWhom;
			set
			{
				cleeningByWhom = value;
				OnPropertyChanged("CleeningByWhom");
			}
		}
		#endregion
	}
}