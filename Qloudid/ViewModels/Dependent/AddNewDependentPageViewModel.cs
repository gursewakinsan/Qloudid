using System;
using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class AddNewDependentPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddNewDependentPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Add Dependent Command.
		private ICommand addDependentCommand;
		public ICommand AddDependentCommand
		{
			get => addDependentCommand ?? (addDependentCommand = new Command(async () => await ExecuteAddDependentCommand()));
		}
		private async Task ExecuteAddDependentCommand()
		{
			if (string.IsNullOrWhiteSpace(DependentType))
				await Helper.Alert.DisplayAlert("Please select dependent type.");
			else if (string.IsNullOrWhiteSpace(FirstName))
				await Helper.Alert.DisplayAlert("First name is required.");
			else if (string.IsNullOrWhiteSpace(LastName))
				await Helper.Alert.DisplayAlert("Last name is required.");
			else if (string.IsNullOrWhiteSpace(SocialSecurityNumber))
				await Helper.Alert.DisplayAlert("Social security number is required.");
			else if (string.IsNullOrWhiteSpace(PassportNumber))
				await Helper.Alert.DisplayAlert("Passport number is required.");
			else if (SelectedIssueDate == null)
				await Helper.Alert.DisplayAlert("Issue date is required.");
			else if (SelectedExpiryDate == null)
				await Helper.Alert.DisplayAlert("Expiry date is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				int type = 0;
				if (DependentType.Equals("Child"))
					type = 1;
				else if (DependentType.Equals("Elder"))
					type = 2;
				else if (DependentType.Equals("Disabled"))
					type = 3;
				Models.AddDependentRequest request = new Models.AddDependentRequest()
				{
					UserId = Helper.Helper.UserId,
					DependentType = type,
					FirstName = FirstName,
					LastName = LastName,
					SocialSecurityNumber = SocialSecurityNumber,
					PassportNumber = PassportNumber,
					IssueDate = SelectedIssueDate,
					ExpiryDate = SelectedExpiryDate
				};
				IDependentService service = new DependentService();
				int checkSsnResponse = await service.CheckSsnAsync(request);
				if (checkSsnResponse == 1)
					await Helper.Alert.DisplayAlert("Dependent social security number is already exist.");
				else if (checkSsnResponse == 2)
					await Helper.Alert.DisplayAlert("Dependent passport number is already exist.");
				else
				{
					Helper.Helper.DependentId = await service.AddDependentAsync(request);
					await Navigation.PushAsync(new Views.Dependent.UploadDependentPassportPhotoPage());
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		public string DependentType { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string SocialSecurityNumber { get; set; }
		public string PassportNumber { get; set; }
		public DateTime BindIssueMinimumDate => DateTime.Today.AddYears(-70);
		public DateTime BindIssueMaximumDate => DateTime.Today.AddDays(-1);
		public DateTime SelectedIssueDate { get; set; }
		public DateTime BindExpiryMinimumDate => DateTime.Today;
		public DateTime BindExpiryMaximumDate => DateTime.Today.AddYears(70);
		public DateTime SelectedExpiryDate { get; set; }
		public string CountryName => Helper.Helper.CountryList.FirstOrDefault(x => x.CountryCode.Equals(Helper.Helper.CountryCode)).CountryName;
		#endregion
	}
}
