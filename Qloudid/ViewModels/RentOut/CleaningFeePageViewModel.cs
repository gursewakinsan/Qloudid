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
			if (Address.CleeningFeeApplicable)
			{
				CleaningFeeYesBg = Color.FromHex("#0C8CE8");
				CleaningFeeNoBg = Color.Transparent;
			}
			else
			{
				CleaningFeeYesBg = Color.Transparent;
				CleaningFeeNoBg = Color.FromHex("#0C8CE8"); 
			}
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
			IDashboardService service = new DashboardService();
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
		#endregion
	}
}
