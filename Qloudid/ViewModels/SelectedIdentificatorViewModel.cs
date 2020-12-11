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
			else
			{
				switch (IdentificatorTitle)
				{
					case "ID":
						IdentificatorId = 1;
						break;
					case "Driver license":
						IdentificatorId = 2;
						break;
					case "Passport":
						IdentificatorId = 3;
						break;
				}
				DependencyService.Get<IProgressBar>().Show();
				ICreateAccountService service = new CreateAccountService();
				Models.IdentificatorRequest request = new Models.IdentificatorRequest()
				{
					UserId = Helper.Helper.UserId,
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
					await Navigation.PushAsync(new Views.IdentificatorPhotoPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
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
		#endregion
	}
}
