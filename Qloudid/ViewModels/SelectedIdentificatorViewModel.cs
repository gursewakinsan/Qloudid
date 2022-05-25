using System;
using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class SelectedIdentificatorViewModel : BaseViewModel
	{
		#region Constructor.
		public SelectedIdentificatorViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Save Identify Info Command.
		private ICommand saveIdentifyInfoCommand;
		public ICommand SaveIdentifyInfoCommand
		{
			get => saveIdentifyInfoCommand ?? (saveIdentifyInfoCommand = new Command(async () => await ExecuteSaveIdentifyInfoCommand()));
		}
		private async Task ExecuteSaveIdentifyInfoCommand()
		{
			if (string.IsNullOrWhiteSpace(IdentificatorText))
				await Helper.Alert.DisplayAlert("Identificator text is required.");
			else if (SelectedIssueDate == null)
				await Helper.Alert.DisplayAlert("Issue date is required.");
			else if (SelectedExpiryDate == null)
				await Helper.Alert.DisplayAlert("Expiry date is required.");
			else if (CroppedImage1 == null || CroppedImage2 == null)
				await Helper.Alert.DisplayAlert("Please select photo's.");
			else
			{
				switch (IdentificatorTitle)
				{
					case "ID":
						IdentificatorId = 1;
						Helper.Helper.SelectedIdentificatorId = 1;
						break;
					case "Driver license":
						IdentificatorId = 2;
						Helper.Helper.SelectedIdentificatorId = 2;
						break;
					case "Passport":
						IdentificatorId = 3;
						Helper.Helper.SelectedIdentificatorId = 3;
						break;
				}
				DependencyService.Get<IProgressBar>().Show();
				ICreateAccountService service = new CreateAccountService();
				Models.IdentificatorRequest request = new Models.IdentificatorRequest()
				{
					UserId = Helper.Helper.UserId,
					certi = Helper.Helper.QrCertificateKey,
					IdentificatorId = IdentificatorId,
					IdentificatorText = IdentificatorText,
					CountryId = Helper.Helper.CountryList.FirstOrDefault(x => x.CountryCode.Equals(Helper.Helper.CountryCode)).Id,
					IssueDate = $"{SelectedIssueDate.Day}/{SelectedIssueDate.Month}/{SelectedIssueDate.Year}",
					ExpiryDate = $"{SelectedExpiryDate.Day}/{SelectedExpiryDate.Month}/{SelectedExpiryDate.Year}",
				};
				int response = await service.AddIdentificatorAsync(request);
				if (response == 0)
					await Helper.Alert.DisplayAlert("This identificator already used by other user, Please use any other identificator.");
				else if (response == 1)
				{
					string imageData1 = Convert.ToBase64String(CroppedImage1);
					string imageData2 = Convert.ToBase64String(CroppedImage2);

					Models.AddIdentificatorImagesRequest request1 = new Models.AddIdentificatorImagesRequest()
					{
						imageId = 1,
						UserId = Helper.Helper.UserId,
						IdentificatorId = Helper.Helper.SelectedIdentificatorId,
						ImageData = imageData1,
					};
					int response1 = await service.UploadAddIdentificatorImagesAsync(request1);
					if (response1 == 0)
						await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
					else if (response1 == 1)
					{
						Models.AddIdentificatorImagesRequest request2 = new Models.AddIdentificatorImagesRequest()
						{
							imageId = 2,
							UserId = Helper.Helper.UserId,
							IdentificatorId = Helper.Helper.SelectedIdentificatorId,
							ImageData = imageData2,
						};
						int response2 = await service.UploadAddIdentificatorImagesAsync(request2);
						if (response2 == 0)
							await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
						else if (response2 == 1)
						{
							//Helper.Helper.IsAddMoreCard = false;
							if (Helper.Helper.IsPreCheckIn)
							{
								IPreCheckInService preCheckInService = new PreCheckInService();
								var updatePreCheckinStatusResponse = await preCheckInService.UpdatePreCheckinStatusAsync(new Models.UpdatePreCheckinStatusRequest()
								{
									Id = Helper.Helper.PreCheckinStatusInfo.Id
								});
								//Helper.Helper.IsPreCheckIn = false;
								if (updatePreCheckinStatusResponse.TotalLeft == 0)
									Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
								else
									Application.Current.MainPage = new NavigationPage(new Views.PreCheckIn.AdultsAndChildrenInfoPage(updatePreCheckinStatusResponse.GuestChildrenLeft, updatePreCheckinStatusResponse.GuestAdultLeft));
							}
							else
								Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
						}
					}
					//await Navigation.PushAsync(new Views.IdentificatorPhotoPage());
					DependencyService.Get<IProgressBar>().Hide();
				}
			}
		}
		#endregion

		#region Skip Identify Info Command.
		private ICommand skipIdentifyInfoCommand;
		public ICommand SkipButtonControlCommand
		{
			get => skipIdentifyInfoCommand ?? (skipIdentifyInfoCommand = new Command(async () => await ExecuteSkipIdentifyInfoCommand()));
		}
		private async Task ExecuteSkipIdentifyInfoCommand()
		{
			//Helper.Helper.IsAddMoreCard = false;
			Application.Current.MainPage = new NavigationPage(new Views.GenerateCertificatePage());
			await Task.CompletedTask;
		}
		#endregion

		#region Back Button Control Command.
		private ICommand backButtonControlCommand;
		public ICommand BackButtonControlCommand
		{
			get => backButtonControlCommand ?? (backButtonControlCommand = new Command(async () => await ExecuteBackButtonControlCommand()));
		}
		private async Task ExecuteBackButtonControlCommand()
		{
			await Navigation.PopAsync();
		}
		#endregion

		#region Properties.
		public int IdentificatorId { get; set; }
		public string IdentificatorText { get; set; }
		public string IdentificatorTitle => Helper.Helper.SelectedIdentificatorText;
		public string IdentificatorPlaceholder => $"Add {Helper.Helper.SelectedIdentificatorText} number";
		public DateTime BindIssueMinimumDate => DateTime.Today.AddYears(-70);
		public DateTime BindIssueMaximumDate => DateTime.Today.AddDays(-1);
		public DateTime SelectedIssueDate { get; set; }
		public DateTime BindExpiryMinimumDate => DateTime.Today;
		public DateTime BindExpiryMaximumDate => DateTime.Today.AddYears(70);
		public DateTime SelectedExpiryDate { get; set; }

		public byte[] CroppedImage1;

		public byte[] CroppedImage2;
		#endregion
	}
}
