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
	public class EditDependentPageViewModel : BaseViewModel
	{
		#region Constructor.
		public EditDependentPageViewModel(INavigation navigation)
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

		#region Update Dependent Command.
		private ICommand updateDependentCommand;
		public ICommand UpdateDependentCommand
		{
			get => updateDependentCommand ?? (updateDependentCommand = new Command(async () => await ExecuteUpdateDependentCommand()));
		}
		private async Task ExecuteUpdateDependentCommand()
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
			/*else if (UserImageData == null)
				await Helper.Alert.DisplayAlert("User image is required.");*/
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				Models.UpdateDependentRequest request = new Models.UpdateDependentRequest()
				{
					Id = DependentDetail.Id,
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

				if (IsChildShareSameAddress)
				{
					int checkSsnResponse = await service.CheckDependentSsnAsync(new Models.CheckDependentSsnRequest()
					{
						Id = DependentDetail.Id,
						SocialSecurityNumber = SocialSecurityNumber,
						UserId = Helper.Helper.UserId
					});
					if (checkSsnResponse == 0)
					{
						await Helper.Alert.DisplayAlert("Dependent social security number is already exist.");
						return;
					}
				}

				await service.UpdateDependentAsync(request);
				if (UserImageData != null)
				{
					string userImageInfo = Convert.ToBase64String(UserImageData);
					await service.AddDependentProfileImagesAsync(new Models.AddDependentProfileImagesRequest()
					{
						Id = DependentDetail.Id,
						ImageData = userImageInfo
					});
				}
				await Navigation.PushAsync(new Views.Dependent.EditUploadDependentPassportPhotoPage());
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

		#region Bind Dependent Info Command.
		private ICommand bindDependentInfoCommand;
		public ICommand BindDependentInfoCommand
		{
			get => bindDependentInfoCommand ?? (bindDependentInfoCommand = new Command( () =>  ExecuteBindDependentInfoCommand()));
		}
		private void ExecuteBindDependentInfoCommand()
		{
			FirstName = DependentDetail.FirstName;
			LastName = DependentDetail.LastName;
			SelectedDobYear = DependentDetail.BirthYear.ToString();
			SelectedDobMonth = DependentDetail.BirthMonth.ToString();
			SelectedDobDay = DependentDetail.BirthDay.ToString();
			IsSocialSecurityNumber = !DependentDetail.IsSsnAvailable;
			SocialSecurityNumber = DependentDetail.Ssn;
			IsChildShareSameAddress = DependentDetail.IsAddressSame;
			Address = DependentDetail.ChildAddress;
			PortNumber = DependentDetail.ChildPortNumber;
			ZipCode = DependentDetail.ChildZip;
			City = DependentDetail.ChildCity;
		}
		#endregion

		#region Properties.
		private string firstName;
		public string FirstName
		{
			get => firstName;
			set
			{
				firstName = value;
				OnPropertyChanged("FirstName");
			}
		}

		private string lastName;
		public string LastName
		{
			get => lastName;
			set
			{
				lastName = value;
				OnPropertyChanged("LastName");
			}
		}

		private string socialSecurityNumber;
		public string SocialSecurityNumber
		{
			get => socialSecurityNumber;
			set
			{
				socialSecurityNumber = value;
				OnPropertyChanged("SocialSecurityNumber");
			}
		}

		public string passportNumber;
		public string PassportNumber
		{
			get => passportNumber;
			set
			{
				passportNumber = value;
				OnPropertyChanged("PassportNumber");
			}
		}
		public DateTime BindIssueMinimumDate => DateTime.Today.AddYears(-70);
		public DateTime BindIssueMaximumDate => DateTime.Today.AddDays(-1);
		public DateTime SelectedIssueDate { get; set; }
		public DateTime BindExpiryMinimumDate => DateTime.Today;
		public DateTime BindExpiryMaximumDate => DateTime.Today.AddYears(70);
		public DateTime SelectedExpiryDate { get; set; }
		public string CountryName => Helper.Helper.CountryList.FirstOrDefault(x => x.CountryCode.Equals(Helper.Helper.CountryCode)).CountryName;

		private List<string> dobYearList;
		public List<string> DobYearList
		{
			get => dobYearList;
			set
			{
				dobYearList = value;
				OnPropertyChanged("DobYearList");
			}
		}

		private string selectedDobYear;
		public string SelectedDobYear 
		{
			get => selectedDobYear;
			set
			{
				selectedDobYear = value;
				OnPropertyChanged("SelectedDobYear");
			}
		}

		private List<string> dobMonthList;
		public List<string> DobMonthList
		{
			get => dobMonthList;
			set
			{
				dobMonthList = value;
				OnPropertyChanged("DobMonthList");
			}
		}

		private string selectedDobMonth;
		public string SelectedDobMonth
		{
			get => selectedDobMonth;
			set
			{
				selectedDobMonth = value;
				OnPropertyChanged("SelectedDobMonth");
			}
		}

		private List<string> dobDayList;
		public List<string> DobDayList
		{
			get => dobDayList;
			set
			{
				dobDayList = value;
				OnPropertyChanged("DobDayList");
			}
		}

		private string selectedDobDay;
		public string SelectedDobDay
		{
			get => selectedDobDay;
			set
			{
				selectedDobDay = value;
				OnPropertyChanged("SelectedDobDay");
			}
		}

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

		private string address;
		public string Address
		{
			get => address;
			set
			{
				address = value;
				OnPropertyChanged("Address");
			}
		}

		private string portNumber;
		public string PortNumber
		{
			get => portNumber;
			set
			{
				portNumber = value;
				OnPropertyChanged("PortNumber");
			}
		}

		private string zipCode;
		public string ZipCode
		{
			get => zipCode;
			set
			{
				zipCode = value;
				OnPropertyChanged("ZipCode");
			}
		}

		private string city;
		public string City
		{
			get => city;
			set
			{
				city = value;
				OnPropertyChanged("City");
			}
		}
		public byte[] UserImageData { get; set; }
		public Models.DependentDetailResponse DependentDetail => Helper.Helper.DependentDetail;
		#endregion
	}
}