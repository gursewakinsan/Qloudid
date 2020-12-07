using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
	public class CreateAccountPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CreateAccountPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			CountryList = new ObservableCollection<Models.Country>(Helper.Helper.CountryList);
		}
		#endregion

		#region Create Account Command.
		private ICommand createAccountCommand;
		public ICommand CreateAccountCommand
		{
			get => createAccountCommand ?? (createAccountCommand = new Command(async () => await ExecuteCreateAccountCommand()));
		}
		private async Task ExecuteCreateAccountCommand()
		{
			if (CountryId == 0)
				await Helper.Alert.DisplayAlert("Country is required.");
			else if (string.IsNullOrWhiteSpace(FirstName))
				await Helper.Alert.DisplayAlert("First name is required.");
			else if (string.IsNullOrWhiteSpace(LastName))
				await Helper.Alert.DisplayAlert("Last name is required.");
			else if (string.IsNullOrWhiteSpace(Email))
				await Helper.Alert.DisplayAlert("Email is required.");
			else if (!Helper.Helper.IsValid(Email))
				await Helper.Alert.DisplayAlert("Please enter valid email address.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				ICreateAccountService service = new CreateAccountService();
				Models.CreateAccount account = new Models.CreateAccount()
				{
					CountryId = CountryId,
					FirstName = FirstName,
					LastName = LastName,
					Email = Email
				};
				Models.CreateAccountResponse response = await service.CreateAccountAsync(account);
				if (response == null)
					await Helper.Alert.DisplayAlert("Somthing went wrong, Please try after some time.");
				else if (response.result == 0)
					await Helper.Alert.DisplayAlert("This email address is not valid. Please try with valid email.");
				else if (response.result == 1)
				{
					Helper.Helper.UserId = response.user_id;
					await Navigation.PushAsync(new Views.EmailVerificationPinPage());
				}
				else if (response.result == 2)
					await Navigation.PushAsync(new Views.ContinueWithExistEmailPage(Email));
				DependencyService.Get<IProgressBar>().Hide();
			}
		}

		#endregion

		#region Accept term and conditions Command.
		private ICommand acceptTermAndConditionsCommand;
		public ICommand AcceptTermAndConditionsCommand
		{
			get => acceptTermAndConditionsCommand ?? (acceptTermAndConditionsCommand = new Command( () => ExecuteAcceptTermAndConditionsCommand()));
		}
		private void ExecuteAcceptTermAndConditionsCommand()
		{
			IsAcceptTermAndConditions = !IsAcceptTermAndConditions;
		}
		#endregion

		#region Term And Conditions Command.
		private ICommand termAndConditionsCommand;
		public ICommand TermAndConditionsCommand
		{
			get => termAndConditionsCommand ?? (termAndConditionsCommand = new Command(async () => await ExecuteTermAndConditionsCommand()));
		}
		private async Task ExecuteTermAndConditionsCommand()
		{
			await this.Navigation.PushAsync(new Views.TermsAndConditionsPage());
		}
		#endregion

		#region Properties.
		public int CountryId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public ObservableCollection<Models.Country> CountryList { get; set; }
		public string CheckUnCheckIcon => IsAcceptTermAndConditions ? Helper.QloudidAppFlatIcons.CheckboxMarked : Helper.QloudidAppFlatIcons.CheckboxBlankOutline;

		private bool isAcceptTermAndConditions = true;
		public bool IsAcceptTermAndConditions
		{
			get { return isAcceptTermAndConditions; }
			set
			{
				if (isAcceptTermAndConditions != value)
				{
					isAcceptTermAndConditions = value;
					OnPropertyChanged("IsAcceptTermAndConditions");
					OnPropertyChanged("CheckUnCheckIcon");
				}
			}
		}
		#endregion
	}
}
