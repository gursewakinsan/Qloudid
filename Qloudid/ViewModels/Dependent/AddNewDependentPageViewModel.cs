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
			if (string.IsNullOrWhiteSpace(FirstName))
				await Helper.Alert.DisplayAlert("First name is required.");
			else if (string.IsNullOrWhiteSpace(LastName))
				await Helper.Alert.DisplayAlert("Last name is required.");
			else if (string.IsNullOrWhiteSpace(SelectedDobYear))
				await Helper.Alert.DisplayAlert("Date of birth year is required.");
			else if (string.IsNullOrWhiteSpace(SelectedDobMonth))
				await Helper.Alert.DisplayAlert("Date of birth month is required.");
			else if (string.IsNullOrWhiteSpace(SelectedDobDay))
				await Helper.Alert.DisplayAlert("Date of birth day is required.");
			else if (!IsSocialSecurityNumber && string.IsNullOrWhiteSpace(SocialSecurityNumber))
				await Helper.Alert.DisplayAlert("Social Security number is required.");
			else if (!IsChildShareSameAddress && string.IsNullOrWhiteSpace(Address))
				await Helper.Alert.DisplayAlert("Address is required.");
			else if (!IsChildShareSameAddress && string.IsNullOrWhiteSpace(City))
				await Helper.Alert.DisplayAlert("City is required.");
			else if (!IsChildShareSameAddress && string.IsNullOrWhiteSpace(ZipCode))
				await Helper.Alert.DisplayAlert("Zip code is required.");
			else if (!IsChildShareSameAddress && string.IsNullOrWhiteSpace(PortNumber))
				await Helper.Alert.DisplayAlert("Number is required.");
			else if (UserImageData == null)
				await Helper.Alert.DisplayAlert("User image is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				Models.AddDependentRequest request = new Models.AddDependentRequest()
				{
					UserId = Helper.Helper.UserId,
					DependentType = 1,
					FirstName = FirstName,
					LastName = LastName,
					IsSsnAvailable = Convert.ToInt32(!IsSocialSecurityNumber),
					SocialSecurityNumber = SocialSecurityNumber,
					Address = Address,
					City = City,
					ZipCode = ZipCode,
					PortNumber = PortNumber,
					IsSameAddress = Convert.ToInt32(IsChildShareSameAddress),
					BirthDay = Convert.ToInt32(SelectedDobDay),
					BirthMonth = Convert.ToInt32(SelectedDobMonth),
					BirthYear = Convert.ToInt32(SelectedDobYear),
				};
				IDependentService service = new DependentService();

				if (!IsChildShareSameAddress)
				{
					int checkSsnResponse = await service.CheckSsnAsync(new Models.CheckSsnRequest()
					{
						SocialSecurityNumber = SocialSecurityNumber,
						UserId = Helper.Helper.UserId
					});
					if (checkSsnResponse == 0)
					{
						await Helper.Alert.DisplayAlert("Dependent social security number is already exist.");
						return;
					}
				}

				Helper.Helper.DependentId = await service.AddDependentAsync(request);
				if (UserImageData != null)
				{
					string userImageInfo = Convert.ToBase64String(UserImageData);
					await service.AddDependentProfileImagesAsync(new Models.AddDependentProfileImagesRequest()
					{
						Id = Helper.Helper.DependentId,
						ImageData = userImageInfo
					});
				}
				await Navigation.PushAsync(new Views.Dependent.UploadDependentPassportPhotoPage());
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
		public string Address { get; set; }
		public string PortNumber { get; set; }
		public string ZipCode { get; set; }
		public string City { get; set; }
		public byte[] UserImageData { get; set; }
		#endregion
	}
}