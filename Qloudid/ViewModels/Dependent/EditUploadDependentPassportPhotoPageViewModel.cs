using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class EditUploadDependentPassportPhotoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public EditUploadDependentPassportPhotoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Helper.Helper.SelectedIdentificatorText = "Passport";
			BindMonthAndYear();
		}
		#endregion

		#region Bind Month And Year
		private void BindMonthAndYear()
		{
			IssueMonthList = new List<string>();
			for (int issueMonth = 1; issueMonth < 13; issueMonth++)
				IssueMonthList.Add($"{issueMonth}");

			IssueYearList = new List<string>();
			int issueYear = DateTime.Today.Year;
			for (int i = 0; i < 50; i++)
			{
				IssueYearList.Add($"{issueYear}");
				issueYear = issueYear - 1;
			}

			ExpireMonthList = new List<string>();
			for (int expireMonth = 1; expireMonth < 13; expireMonth++)
				ExpireMonthList.Add($"{expireMonth}");

			ExpireYearList = new List<string>();
			int expireYear = DateTime.Today.Year;
			for (int i = 0; i < 50; i++)
			{
				ExpireYearList.Add($"{expireYear}");
				expireYear = expireYear + 1;
			}
		}
		#endregion

		#region Upload Passport Image Command.
		private ICommand uploadPassportImageCommand;
		public ICommand UploadPassportImageCommand
		{
			get => uploadPassportImageCommand ?? (uploadPassportImageCommand = new Command(async () => await ExecuteUploadPassportImageCommand()));
		}
		private async Task ExecuteUploadPassportImageCommand()
		{
			if (string.IsNullOrWhiteSpace(PassportNumber))
				await Helper.Alert.DisplayAlert("Passport number is required.");
			else if (string.IsNullOrWhiteSpace(SelectedIssueMonth))
				await Helper.Alert.DisplayAlert("Issue month is required.");
			else if (string.IsNullOrWhiteSpace(SelectedIssueYear))
				await Helper.Alert.DisplayAlert("Issue year is required.");
			else if (string.IsNullOrWhiteSpace(SelectedExpireMonth))
				await Helper.Alert.DisplayAlert("Expire month is required.");
			else if (string.IsNullOrWhiteSpace(SelectedExpireYear))
				await Helper.Alert.DisplayAlert("Expire year is required.");
			/*else if (CroppedImage1 == null || CroppedImage2 == null)
				await Helper.Alert.DisplayAlert("Please select photo's.");*/
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IDependentService service = new DependentService();
				int checkPassportResponse = await service.CheckPassportAsync(new Models.CheckPassportRequest()
				{
					Id = DependentDetail.Id,
					UserId = Helper.Helper.UserId,
					PassportNumber = PassportNumber
				});
				if (checkPassportResponse == 1)
				{
					await service.AddDependentPassportAsync(new Models.AddDependentPassportRequest()
					{
						Id = DependentDetail.Id,
						PassportNumber = PassportNumber,
						IssueMonth = Convert.ToInt32(SelectedIssueMonth),
						IssueYear = Convert.ToInt32(SelectedIssueYear),
						ExpiryMonth = Convert.ToInt32(SelectedExpireMonth),
						ExpiryYear = Convert.ToInt32(SelectedExpireYear)
					});

					if (CroppedImage1 != null)
					{
						string imageData1 = Convert.ToBase64String(CroppedImage1);
						int response1 = await service.AddDependentImagesAsync(new Models.AddDependentImagesRequest()
						{
							ImageId = 1,
							UserId = Helper.Helper.UserId,
							Id = DependentDetail.Id,
							ImageData = imageData1,
						});
						if (response1 == 0)
						{
							await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
							return;
						}
					}

					if (CroppedImage2 != null)
					{
						string imageData2 = Convert.ToBase64String(CroppedImage2);
						int response2 = await service.AddDependentImagesAsync(new Models.AddDependentImagesRequest()
						{
							ImageId = 2,
							UserId = Helper.Helper.UserId,
							Id = DependentDetail.Id,
							ImageData = imageData2,
						});
						if (response2 == 0)
						{
							await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
							return;
						}
					}
					Application.Current.MainPage = new NavigationPage(new Views.Dependent.DependentListPage());
				}
				else
					await Helper.Alert.DisplayAlert("Passport already in use.");
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Skip Upload Passport Images Command.
		private ICommand skipUploadPassportImageCommand;
		public ICommand SkipUploadPassportImageCommand
		{
			get => skipUploadPassportImageCommand ?? (skipUploadPassportImageCommand = new Command(async () => await ExecuteSkipUploadPassportImageCommand()));
		}
		private async Task ExecuteSkipUploadPassportImageCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Dependent.DependentListPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Bind Data With View Command.
		private ICommand bindDataWithViewCommand;
		public ICommand BindDataWithViewCommand
		{
			get => bindDataWithViewCommand ?? (bindDataWithViewCommand = new Command(() => ExecuteBindDataWithViewCommand()));
		}
		private void ExecuteBindDataWithViewCommand()
		{
			PassportNumber = DependentDetail.PassportNumber;
			SelectedIssueMonth = DependentDetail.IssueMonth;
			SelectedIssueYear = DependentDetail.IssueYear;
			SelectedExpireMonth = DependentDetail.ExpiryMonth;
			SelectedExpireYear = DependentDetail.ExpiryYear;
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(async () => await ExecuteBackCommand()));
		}
		private async Task ExecuteBackCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Dependent.DependentListPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public Image Image1 { get; set; }
		public Image Image2 { get; set; }

		public byte[] CroppedImage1;

		public byte[] CroppedImage2;

		private List<string> issueMonthList;
		public List<string> IssueMonthList
		{
			get => issueMonthList;
			set
			{
				issueMonthList = value;
				OnPropertyChanged("IssueMonthList");
			}
		}

		private string selectedIssueMonth;
		public string SelectedIssueMonth
		{
			get => selectedIssueMonth;
			set
			{
				selectedIssueMonth = value;
				OnPropertyChanged("SelectedIssueMonth");
			}
		}

		private List<string> issueYearList;
		public List<string> IssueYearList
		{
			get => issueYearList;
			set
			{
				issueYearList = value;
				OnPropertyChanged("IssueYearList");
			}
		}

		private string selectedIssueYear;
		public string SelectedIssueYear
		{
			get => selectedIssueYear;
			set
			{
				selectedIssueYear = value;
				OnPropertyChanged("SelectedIssueYear");
			}
		}

		private List<string> expireMonthList;
		public List<string> ExpireMonthList
		{
			get => expireMonthList;
			set
			{
				expireMonthList = value;
				OnPropertyChanged("ExpireMonthList");
			}
		}

		private string selectedExpireMonth;
		public string SelectedExpireMonth
		{
			get => selectedExpireMonth;
			set
			{
				selectedExpireMonth = value;
				OnPropertyChanged("SelectedExpireMonth");
			}
		}

		private List<string> expireYearList;
		public List<string> ExpireYearList
		{
			get => expireYearList;
			set
			{
				expireYearList = value;
				OnPropertyChanged("ExpireYearList");
			}
		}

		private string selectedExpireYear;
		public string SelectedExpireYear
		{
			get => selectedExpireYear;
			set
			{
				selectedExpireYear = value;
				OnPropertyChanged("SelectedExpireYear");
			}
		}

		private string passportNumber;
		public string PassportNumber
		{
			get => passportNumber;
			set
			{
				passportNumber = value;
				OnPropertyChanged("PassportNumber");
			}
		}

		public Models.DependentDetailResponse DependentDetail => Helper.Helper.DependentDetail;
		#endregion
	}
}