using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class EmployerDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public EmployerDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Approve Employer Request Command.
		private ICommand approveEmployerRequestCommand;
		public ICommand ApproveEmployerRequestCommand
		{
			get => approveEmployerRequestCommand ?? (approveEmployerRequestCommand = new Command(async () => await ExecuteApproveEmployerRequestCommand()));
		}
		private async Task ExecuteApproveEmployerRequestCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IEmployerService service = new EmployerService();
			await service.ApproveEmployerRequestAsync(new Models.ApproveEmployerRequest()
			{
				UserId = Helper.Helper.UserId,
				Id = EmployerDetails.Id
			});
			Helper.Helper.IsFirstTime = true;
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Reject Employer Request Command.
		private ICommand rejectEmployerRequestCommand;
		public ICommand RejectEmployerRequestCommand
		{
			get => rejectEmployerRequestCommand ?? (rejectEmployerRequestCommand = new Command(async () => await ExecuteRejectEmployerRequestCommand()));
		}
		private async Task ExecuteRejectEmployerRequestCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IEmployerService service = new EmployerService();
			await service.RejectEmployerRequestAsync(new Models.RejectEmployerRequest()
			{
				UserId = Helper.Helper.UserId,
				Id = EmployerDetails.Id
			});
			Helper.Helper.IsFirstTime = true;
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Bas Uppgifter Command.
		private ICommand basUppgifterCommand;
		public ICommand BasUppgifterCommand
		{
			get => basUppgifterCommand ?? (basUppgifterCommand = new Command( () => ExecuteBasUppgifterCommand()));
		}
		private void ExecuteBasUppgifterCommand()
		{
			IsBasUppgifter = !IsBasUppgifter;
		}
		#endregion

		#region Hem Adress Command.
		private ICommand hemAdressCommand;
		public ICommand HemAdressCommand
		{
			get => hemAdressCommand ?? (hemAdressCommand = new Command(() => ExecuteHemAdressCommand()));
		}
		private void ExecuteHemAdressCommand()
		{
			IsHemAdress = !IsHemAdress;
		}
		#endregion

		#region Telefon Nummer Command.
		private ICommand telefonNummerCommand;
		public ICommand TelefonNummerCommand
		{
			get => telefonNummerCommand ?? (telefonNummerCommand = new Command(() => ExecuteTelefonNummerCommand()));
		}
		private void ExecuteTelefonNummerCommand()
		{
			IsTelefonNummer = !IsTelefonNummer;
		}
		#endregion

		#region Arbete Command.
		private ICommand arbeteCommand;
		public ICommand ArbeteCommand
		{
			get => arbeteCommand ?? (arbeteCommand = new Command(() => ExecuteArbeteCommand()));
		}
		private void ExecuteArbeteCommand()
		{
			IsArbete = !IsArbete;
		}
		#endregion

		#region Properties.
		public Models.EmployerResponse employerDetails;
		public Models.EmployerResponse EmployerDetails
		{
			get => employerDetails;
			set
			{
				employerDetails = value;
				OnPropertyChanged("EmployerDetails");
			}
		}

		public bool isBasUppgifter = false;
		public bool IsBasUppgifter
		{
			get => isBasUppgifter;
			set
			{
				isBasUppgifter = value;
				IconBasUppgifter = value ? Helper.QloudidAppFlatIcons.ChevronUp : Helper.QloudidAppFlatIcons.ChevronDown;
				OnPropertyChanged("IsBasUppgifter");
			}
		}

		public string iconBasUppgifter = Helper.QloudidAppFlatIcons.ChevronDown;
		public string IconBasUppgifter
		{
			get => iconBasUppgifter;
			set
			{
				iconBasUppgifter = value;
				OnPropertyChanged("IconBasUppgifter");
			}
		}

		public bool isHemAdress = false;
		public bool IsHemAdress
		{
			get => isHemAdress;
			set
			{
				isHemAdress = value;
				IconHemAdress = value ? Helper.QloudidAppFlatIcons.ChevronUp : Helper.QloudidAppFlatIcons.ChevronDown;
				OnPropertyChanged("IsHemAdress");
			}
		}

		public string iconHemAdress = Helper.QloudidAppFlatIcons.ChevronDown;
		public string IconHemAdress
		{
			get => iconHemAdress;
			set
			{
				iconHemAdress = value;
				OnPropertyChanged("IconHemAdress");
			}
		}

		public bool isTelefonNummer = false;
		public bool IsTelefonNummer
		{
			get => isTelefonNummer;
			set
			{
				isTelefonNummer = value;
				IconTelefonNummer = value ? Helper.QloudidAppFlatIcons.ChevronUp : Helper.QloudidAppFlatIcons.ChevronDown;
				OnPropertyChanged("IsTelefonNummer");
			}
		}

		public string iconTelefonNummer = Helper.QloudidAppFlatIcons.ChevronDown;
		public string IconTelefonNummer
		{
			get => iconTelefonNummer;
			set
			{
				iconTelefonNummer = value;
				OnPropertyChanged("IconTelefonNummer");
			}
		}

		public bool isArbete = false;
		public bool IsArbete
		{
			get => isArbete;
			set
			{
				isArbete = value;
				IconArbete = value ? Helper.QloudidAppFlatIcons.ChevronUp : Helper.QloudidAppFlatIcons.ChevronDown;
				OnPropertyChanged("IsArbete");
			}
		}

		public string iconArbete = Helper.QloudidAppFlatIcons.ChevronDown;
		public string IconArbete
		{
			get => iconArbete;
			set
			{
				iconArbete = value;
				OnPropertyChanged("IconArbete");
			}
		}
		#endregion
	}
}
