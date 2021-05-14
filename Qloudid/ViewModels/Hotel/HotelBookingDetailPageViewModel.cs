using System;
using System.Timers;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Qloudid.ViewModels
{
	public class HotelBookingDetailPageViewModel : BaseViewModel
	{
		#region Local Variable.
		Timer timer;
		int count = 0;
		#endregion

		#region Constructor.
		public HotelBookingDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			timer = new Timer();
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			timer.Interval = 60000;
			timer.Enabled = true;
		}
		#endregion

		#region On Timed Event.
		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			DisplayTotalMinutes = $"{count = count + 1} ";
			timer.Start();
		}
		#endregion

		#region Verify User Consent Command.
		private ICommand verifyUserConsentCommand;
		public ICommand VerifyUserConsentCommand
		{
			get => verifyUserConsentCommand ?? (verifyUserConsentCommand = new Command(async () => await ExecuteVerifyUserConsentCommand()));
		}
		private async Task ExecuteVerifyUserConsentCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ILoginService service = new LoginService();
			Models.VerifyUserConsentRequest request = new Models.VerifyUserConsentRequest()
			{
				certificate = Helper.Helper.QrCertificateKey,
				clientId = Helper.Helper.VerifyUserConsentClientId
			};
			var verifyUserConsent = await service.VerifyUserConsentAsync(request);
			if (verifyUserConsent == null)
			{
				await Helper.Alert.DisplayAlert("Something went wrong, Please try after some time.");
				Application.Current.MainPage = new NavigationPage(new Views.RestorePage());
			}
			else if (verifyUserConsent.result == 0)
				Application.Current.MainPage = new NavigationPage(new Views.InvalidCertificatePage());
			else
			{
				DisplayName = $"{verifyUserConsent.first_name}";
				GetHotelBookingDetailCommand.Execute(null);
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Get Hotel Booking Detail Command.
		private ICommand getHotelBookingDetailCommand;
		public ICommand GetHotelBookingDetailCommand
		{
			get => getHotelBookingDetailCommand ?? (getHotelBookingDetailCommand = new Command(async () => await ExecuteGetHotelBookingDetailCommand()));
		}
		private async Task ExecuteGetHotelBookingDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			BookingDetail = await service.GetBookingDetailAsync(new Models.BookingDetailRequest()
			{
				Id = Helper.Helper.HotelBookingId
			});
			Helper.Helper.HotelBookingDetail = BookingDetail;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Clear Login Command.
		private ICommand clearLoginCommand;
		public ICommand ClearLoginCommand
		{
			get => clearLoginCommand ?? (clearLoginCommand = new Command(async () => await ExecuteClearLoginCommand()));
		}
		private async Task ExecuteClearLoginCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ILoginService service = new LoginService();
			await service.ClearLoginAsync(Helper.Helper.QrCertificateKey);
			Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Continue Command.
		private ICommand continueCommand;
		public ICommand ContinueCommand
		{
			get => continueCommand ?? (continueCommand = new Command(async () => await ExecuteContinueCommand()));
		}
		private async Task ExecuteContinueCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.SignInFromWebPage(true));
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		private Models.BookingDetailResponse bookingDetail;
		public Models.BookingDetailResponse BookingDetail
		{
			get => bookingDetail;
			set
			{
				bookingDetail = value;
				OnPropertyChanged("BookingDetail");
			}
		}

		private string displayTotalMinutes = "Less then ";
		public string DisplayTotalMinutes
		{
			get => displayTotalMinutes;
			set
			{
				displayTotalMinutes = value;
				OnPropertyChanged("DisplayTotalMinutes");
			}
		}

		public string displayName;
		public string DisplayName
		{
			get => displayName;
			set
			{
				displayName = value;
				OnPropertyChanged("DisplayName");
			}
		}

		public string CurrentDate => DateTime.Now.ToString("yyyy-MM-dd");
		#endregion
	}
}
