using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class UploadDependentPassportPhotoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public UploadDependentPassportPhotoPageViewModel(INavigation navigation)
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
			else if (CroppedImage1 == null || CroppedImage2 == null)
				await Helper.Alert.DisplayAlert("Please select photo's.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IDependentService service = new DependentService();
				int checkPassportResponse = await service.CheckPassportAsync(new Models.CheckPassportRequest()
				{
					Id = Helper.Helper.DependentId,
					UserId = Helper.Helper.UserId,
					PassportNumber = PassportNumber
				});
				if (checkPassportResponse == 1)
				{
					await service.AddDependentPassportAsync(new Models.AddDependentPassportRequest()
					{
						Id = Helper.Helper.DependentId,
						PassportNumber = PassportNumber,
						IssueMonth = Convert.ToInt32(SelectedIssueMonth),
						IssueYear = Convert.ToInt32(SelectedIssueYear),
						ExpiryMonth = Convert.ToInt32(SelectedExpireMonth),
						ExpiryYear = Convert.ToInt32(SelectedExpireYear)
					});

					string imageData1 = Convert.ToBase64String(CroppedImage1);
					string imageData2 = Convert.ToBase64String(CroppedImage2);

					int response1 = await service.AddDependentImagesAsync(new Models.AddDependentImagesRequest()
					{
						ImageId = 1,
						UserId = Helper.Helper.UserId,
						Id = Helper.Helper.DependentId,
						ImageData = imageData1,
					});
					if (response1 == 0)
						await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
					else
					{
						int response2 = await service.AddDependentImagesAsync(new Models.AddDependentImagesRequest()
						{
							ImageId = 2,
							UserId = Helper.Helper.UserId,
							Id = Helper.Helper.DependentId,
							ImageData = imageData2,
						});
						if (response2 == 0)
							await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
						else
							Application.Current.MainPage = new NavigationPage(new Views.Dependent.DependentListPage());
					}
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

		#region Properties.
		public Image Image1 { get; set; }
		public Image Image2 { get; set; }

		public byte[] CroppedImage1;

		public byte[] CroppedImage2;

		public List<string> IssueMonthList { get; set; }
		public string SelectedIssueMonth { get; set; }
		public List<string> IssueYearList { get; set; }
		public string SelectedIssueYear { get; set; }
		public List<string> ExpireMonthList { get; set; }
		public string SelectedExpireMonth { get; set; }
		public List<string> ExpireYearList { get; set; }
		public string SelectedExpireYear { get; set; }
		public string PassportNumber { get; set; }
		#endregion
	}
}
