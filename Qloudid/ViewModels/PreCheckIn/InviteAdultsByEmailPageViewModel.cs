using Xamarin.Forms;
using Qloudid.Service;
using Xamarin.Essentials;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class InviteAdultsByEmailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public InviteAdultsByEmailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Submit Email Address Command.
		private ICommand submitEmailAddressCommand;
		public ICommand SubmitEmailAddressCommand
		{
			get => submitEmailAddressCommand ?? (submitEmailAddressCommand = new Command(async () => await ExecuteSubmitEmailAddressCommand()));
		}
		private async Task ExecuteSubmitEmailAddressCommand()
		{
			if (string.IsNullOrWhiteSpace(EmailAddress))
				await Helper.Alert.DisplayAlert("Email is required.");
			else if (!Helper.Helper.IsValid(EmailAddress))
				await Helper.Alert.DisplayAlert("Please enter valid email address.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IHotelService service = new HotelService();
				int id = await service.EmailIinviteAdultForCheckinAsync(new Models.EmailIinviteAdultForCheckinRequest()
				{
					Email = EmailAddress,
					CheckId = Helper.Helper.HotelCheckedIn,
					UserId = Helper.Helper.UserId
				});
				if (id == 0)
					await Helper.Alert.DisplayAlert("You can't invite your self.");
				else
				{
					Models.VerifyDependent verify = new Models.VerifyDependent()
					{
						Id = id,
						VerificationInfo = 2,
						CheckId = Helper.Helper.HotelCheckedIn,
					};
					string verifyDependentChekIn = Newtonsoft.Json.JsonConvert.SerializeObject(verify);
					if (Device.RuntimePlatform == Device.iOS)
						await Launcher.OpenAsync($"QloudidUrl://DstrictsApp/VerifyDependentChekIn/{verifyDependentChekIn}");
					else
						await Launcher.OpenAsync($"https://qloudid.com/ip/DstrictsApp/VerifyDependentChekIn/{verifyDependentChekIn}");

					await Navigation.PopToRootAsync();
				}
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		public string EmailAddress { get; set; } //= "deservingchandan@gmail.com";
		#endregion
	}
}
