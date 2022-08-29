using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
    public class AddVisitingCountryPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AddVisitingCountryPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Submit Command.
		private ICommand submitCommand;
		public ICommand SubmitCommand
		{
			get => submitCommand ?? (submitCommand = new Command(async () => await ExecuteSubmitCommand()));
		}
		private async Task ExecuteSubmitCommand()
		{
			if (string.IsNullOrWhiteSpace(PassportNumber))
				await Helper.Alert.DisplayAlert("Passport number is required.");
			else if (SelectedIssueDate == null)
				await Helper.Alert.DisplayAlert("Issue date is required.");
			else if (SelectedExpiryDate == null)
				await Helper.Alert.DisplayAlert("Expiry date is required.");
			else if (UserImageData1 == null || UserImageData2 == null)
				await Helper.Alert.DisplayAlert("Please select photo's.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IMyCountriesService service = new MyCountriesService();
				int checkPassportInfoResponse = await service.CheckPassportInfoAsync(new Models.CheckPassportInfoRequest()
				{
					CountryId=67,
					IdNumber = PassportNumber
				});
				if (checkPassportInfoResponse == 0)
				{
					int id = await service.AddVisitingCountryAsync(new Models.AddVisitingCountryRequest()
					{
						CountryId=67,
						PNumber=Helper.Helper.UserMobileNumber,
						IdNumber = PassportNumber,
						IdentificatorType =3,
						UserId = Helper.Helper.UserId,
						IssueDate = $"{SelectedIssueDate.Day}/{SelectedIssueDate.Month}/{SelectedIssueDate.Year}",
						ExpiryDate = $"{SelectedExpiryDate.Day}/{SelectedExpiryDate.Month}/{SelectedExpiryDate.Year}",
					});

					if (id > 0)
					{
						string imageData1 = Convert.ToBase64String(UserImageData1);
						await service.AddVisitingCountryIdentificatorImagesAsync(new Models.AddVisitingCountryIdentificatorImagesRequest()
						{
							Id = id,
							ImageData = imageData1,
							ImageId = 1
						});

						string imageData2 = Convert.ToBase64String(UserImageData2);
						await service.AddVisitingCountryIdentificatorImagesAsync(new Models.AddVisitingCountryIdentificatorImagesRequest()
						{
							Id = id,
							ImageData = imageData2,
							ImageId = 2
						});
					}
					Application.Current.MainPage = new NavigationPage(new Views.MyCountries.ChangeProfilePage());
				}
				else
					await Helper.Alert.DisplayAlert("Id already in use.");
			}
		}
		#endregion

		#region Properties.
		public string PassportNumber { get; set; }
		public DateTime BindIssueMinimumDate => DateTime.Today.AddYears(-70);
		public DateTime BindIssueMaximumDate => DateTime.Today.AddDays(-1);
		public DateTime SelectedIssueDate { get; set; }
		public DateTime BindExpiryMinimumDate => DateTime.Today;
		public DateTime BindExpiryMaximumDate => DateTime.Today.AddYears(70);
		public DateTime SelectedExpiryDate { get; set; }

		public byte[] UserImageData1 { get; set; }
		public byte[] UserImageData2 { get; set; }
		#endregion
	}
}
