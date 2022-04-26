using System;
using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class AddNewDependentPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddNewDependentPageViewModel(INavigation navigation)
		{
			DobYearList = new List<string>();
			Navigation = navigation;
			int currentYear = DateTime.Today.Year;
			for (int i = 0; i < 50; i++)
			{
				DobYearList.Add($"{currentYear}");
				currentYear = currentYear - 1;
			}

			DobMonthList = new List<string>();
			for (int i = 1; i < 13; i++)
				DobMonthList.Add($"{i}");

			DobDayList = new List<string>();
			for (int i = 1; i < 31; i++)
				DobDayList.Add($"{i}");
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

		#region Is Social Security Number Command.
		private ICommand isSocialSecurityNumberCommand;
		public ICommand IsSocialSecurityNumberCommand
		{
			get => isSocialSecurityNumberCommand ?? (isSocialSecurityNumberCommand = new Command(() => ExecuteIsSocialSecurityNumberCommand()));
		}
		private void ExecuteIsSocialSecurityNumberCommand()
		{
			IsSocialSecurityNumber = !IsSocialSecurityNumber;
		}
		#endregion

		#region Is Child Share Same Address Command.
		private ICommand isChildShareSameAddressCommand;
		public ICommand IsChildShareSameAddressCommand
		{
			get => isChildShareSameAddressCommand ?? (isChildShareSameAddressCommand = new Command(() => ExecuteIsChildShareSameAddressCommand()));
		}
		private void ExecuteIsChildShareSameAddressCommand()
		{
			IsChildShareSameAddress = !IsChildShareSameAddress;
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

		public List<string> DobYearList { get; set; }
		public string SelectedDobYear { get; set; }

		public List<string> DobMonthList { get; set; }
		public string SelectedDobMonth { get; set; }

		public List<string> DobDayList { get; set; }
		public string SelectedDobDay { get; set; }

		private bool isSocialSecurityNumber = true;
		public bool IsSocialSecurityNumber
		{
			get => isSocialSecurityNumber;
			set
			{
				isSocialSecurityNumber = value;
				OnPropertyChanged("IsSocialSecurityNumber");
			}
		}

		private bool isChildShareSameAddress = true;
		public bool IsChildShareSameAddress
		{
			get => isChildShareSameAddress;
			set
			{
				isChildShareSameAddress = value;
				OnPropertyChanged("IsChildShareSameAddress");
			}
		}
		#endregion
	}
}