using System;
using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class IdentificatorPageViewModel : BaseViewModel
	{
		#region Constructor.
		public IdentificatorPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			SelectedIdentificator = new Models.Identificator();
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
			{
				switch (IdentificatorId)
				{
					case 1:
						await Helper.Alert.DisplayAlert("ID number is required.");
						break;
					case 2:
						await Helper.Alert.DisplayAlert("Driver license number is required.");
						break;
					case 3:
						await Helper.Alert.DisplayAlert("Passport number is required.");
						break;
				}
			}
			else if (IssueMonth == 0)
				await Helper.Alert.DisplayAlert("Please select issue month.");
			else if (IssueYear == 0)
				await Helper.Alert.DisplayAlert("Please select issue year.");
			else if (ExpiryMonth == 0)
				await Helper.Alert.DisplayAlert("Please select expiry month.");
			else if (ExpiryYear == 0)
				await Helper.Alert.DisplayAlert("Please select expiry year.");
			else
			{
				DateTime issueDate = new DateTime(IssueYear, IssueMonth, DateTime.Today.Day).Date;
				if (issueDate > DateTime.Today.Date)
					await Helper.Alert.DisplayAlert("Issue month & issue year can't be greater than from current date.");
				else
				{
					DateTime expiryDate = new DateTime(ExpiryYear, ExpiryMonth, DateTime.Today.Day).Date;
					if (expiryDate < DateTime.Today.Date)
						await Helper.Alert.DisplayAlert("Expiry month & expiry year can't be less than from current date.");
					else
					{
						DependencyService.Get<IProgressBar>().Show();
						ICreateAccountService service = new CreateAccountService();
						Models.IdentificatorRequest request = new Models.IdentificatorRequest()
						{
							UserId = Helper.Helper.UserId,
							IdentificatorId = IdentificatorId,
							IdentificatorText = IdentificatorText,
							CountryId = Helper.Helper.CountryList.FirstOrDefault(x => x.CountryCode.Equals(Helper.Helper.CountryCode)).Id,
							IssueMonth = IssueMonth,
							IssueYear = IssueYear,
							ExpiryMonth = ExpiryMonth,
							ExpiryYear = ExpiryYear
						};
						int response = await service.AddIdentificatorAsync(request);
						if (response == 0)
							await Helper.Alert.DisplayAlert("This identificator already used by other user, Please use any other identificator.");
						else if (response == 1)
							await Navigation.PushAsync(new Views.IdentificatorPhotoPage());
						DependencyService.Get<IProgressBar>().Hide();
					}
				}
			}
		}
		#endregion

		#region Properties.
		public Models.Identificator SelectedIdentificator { get; set; }

		private bool isShowIdentificator = false;
		public bool IsShowIdentificator
		{
			get { return isShowIdentificator; }
			set
			{
				if (isShowIdentificator != value)
				{
					isShowIdentificator = value;
					OnPropertyChanged("IsShowIdentificator");
				}
			}
		}
		public int IdentificatorId => SelectedIdentificator.Id;
		public string IdentificatorText { get; set; }
		public string CountryName => Helper.Helper.CountryList.FirstOrDefault(x => x.CountryCode.Equals(Helper.Helper.CountryCode)).CountryName;
		public int IssueMonth { get; set; }
		public int IssueYear { get; set; }
		public int ExpiryMonth { get; set; }
		public int ExpiryYear { get; set; }
		#endregion
	}
}
