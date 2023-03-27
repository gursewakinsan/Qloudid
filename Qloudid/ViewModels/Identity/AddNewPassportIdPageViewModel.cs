using System;
using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AddNewPassportIdPageViewModel : BaseViewModel
    {
        #region Constructor.
        public AddNewPassportIdPageViewModel(INavigation navigation)
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
					case "Passport":
						IdentificatorId = 1;
						Helper.Helper.SelectedIdentificatorId = 1;
						break;
					case "National card":
						IdentificatorId = 2;
						Helper.Helper.SelectedIdentificatorId = 2;
						break;
					case "Driver license":
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
							Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
					}
					DependencyService.Get<IProgressBar>().Hide();
				}
			}
		}
		#endregion

		#region Properties.
		public DateTime BindIssueMinimumDate => DateTime.Today.AddYears(-70);
        public DateTime BindIssueMaximumDate => DateTime.Today.AddDays(-1);
        public DateTime SelectedIssueDate { get; set; }
        public DateTime BindExpiryMinimumDate => DateTime.Today;
        public DateTime BindExpiryMaximumDate => DateTime.Today.AddYears(70);
        public DateTime SelectedExpiryDate { get; set; }
        public string IdentificatorTitle => Helper.Helper.SelectedIdentificatorText;
		public string DisplayUserName => Helper.Helper.UserInfo.DisplayUserName;
		public int IdentificatorId { get; set; }
		public string IdentificatorText { get; set; }
		public byte[] CroppedImage1;
		public byte[] CroppedImage2;
		#endregion
	}
}
