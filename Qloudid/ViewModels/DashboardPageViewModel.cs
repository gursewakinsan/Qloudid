using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
	public class DashboardPageViewModel : BaseViewModel
	{
		#region Constructor.
		public DashboardPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			UserInfo = Helper.Helper.UserInfo;
			Helper.Helper.IsManageYourReservations = false;
			if (UserInfo == null) UserInfo = new Models.User();
			if (UserInfo.UserImage == null)
				UserImage = string.Empty;
			else
				UserImage = UserInfo.UserImage;  //ImageSource.FromUri(new Uri(UserInfo.UserImage));
			BindDashboardItemList();
		}
		#endregion

		#region Login To Desktop Command.
		private ICommand loginToDesktopCommand;
		public ICommand LoginToDesktopCommand
		{
			get => loginToDesktopCommand ?? (loginToDesktopCommand = new Command<string>(async (qrCode) => await ExecuteLoginToDesktopCommand(qrCode)));
		}
		private async Task ExecuteLoginToDesktopCommand(string qrCode)
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			string[] ip = qrCode.Split('/');
			Helper.Helper.IsPreCheckIn = false;
			if (ip.Length == 5)
			{
				if (ip[2].Equals("checkin_dependent"))
				{
					Models.CheckInDependentRequest request = new Models.CheckInDependentRequest()
					{
						Ip = ip[0],
						Id = ip[1],
						ClientId = ip[4],
						Certificate = Helper.Helper.QrCertificateKey
					};
					IDependentService dependentService = new DependentService();
					int dependentResponse = await dependentService.VerifyUserBookingExistsAsync(request);
					if (dependentResponse == 0)
					{
						await Navigation.PushAsync(new Views.Dependent.WrongCheckInDependentPage());
						DependencyService.Get<IProgressBar>().Hide();
						return;
					}
					else if (dependentResponse == 1)
					{
						await Navigation.PushAsync(new Views.Dependent.EmptyDependentListPage());
						DependencyService.Get<IProgressBar>().Hide();
						return;
					}
				}
			}
			else if (ip.Length == 2)
			{
				if (ip[0].Equals("precheckin"))
				{
					IPreCheckInService preCheckInService = new PreCheckInService();
					var responsePreCheckInService = await preCheckInService.GetPreCheckinStatusAsync(new Models.GetPreCheckinStatusRequest()
					{
						Id = ip[1],
						userId = Helper.Helper.UserId
					});
					Helper.Helper.PreCheckinStatusInfo = responsePreCheckInService;
					if (responsePreCheckInService != null)
						Helper.Helper.HotelCheckedIn = responsePreCheckInService.Checkid;

					if (responsePreCheckInService?.Result == 0)
					{
						Application.Current.MainPage = new NavigationPage(new Views.PreCheckIn.UnauthorizedPreCheckInPage());
						DependencyService.Get<IProgressBar>().Hide();
						return;
					}
					else if (responsePreCheckInService?.Result == 1)
					{
						//await Navigation.PushAsync(new Views.PreCheckIn.AdultsAndChildrenInfoPage(responsePreCheckInService.GuestChildrenLeft, responsePreCheckInService.GuestAdultLeft));
						//DependencyService.Get<IProgressBar>().Hide();
						Helper.Helper.PreCheckinStatus = 1;
						Helper.Helper.IsPreCheckIn = true;
						await Navigation.PushAsync(new Views.PreCheckIn.PreCheckInPage());
						DependencyService.Get<IProgressBar>().Hide();
						return;
					}
					else if (responsePreCheckInService?.Result == 2)
					{
						Helper.Helper.PreCheckinStatus = 2;
						Helper.Helper.IsPreCheckIn = true;
						await Navigation.PushAsync(new Views.PreCheckIn.PreCheckInPage());
						DependencyService.Get<IProgressBar>().Hide();
						return;
					}
					else if (responsePreCheckInService?.Result == 3)
					{
						Application.Current.MainPage = new NavigationPage(new Views.PreCheckIn.AlreadyDonePreCheckInPage());
						DependencyService.Get<IProgressBar>().Hide();
						return;
					}
				}
			}
			int response = await service.UpdateLoginIpAsync(Helper.Helper.QrCertificateKey, new Models.UpdateLoginIP() { ip = ip[0] });
			if (response == 1)
			{
				if (ip.Length == 1)
					await Navigation.PushAsync(new Views.VerifyPasswordPage());
				else if (ip.Length == 3)
				{
					if (ip[1].Equals("signin"))
					{
						Helper.Helper.IsSignIn = true;
						await Navigation.PushAsync(new Views.VerifyPasswordPage());
					}
				}
				else
				{
					Helper.Helper.IpFromURL = ip[0];
					Helper.Helper.VerifyUserConsentClientId = ip[1];
					string textHotel = ip[2];

					if (ip.Length == 5)
						Helper.Helper.ClientIdForHotel = ip[4];

					if (textHotel.Equals("hotel"))
					{
						Helper.Helper.IsHotelBookingFromQrScan = true;
						Helper.Helper.HotelBookingId = ip[1];
						await Navigation.PushAsync(new Views.Hotel.HotelBookingDetailPage());
					}
					else if (textHotel.Equals("checkin"))
					{
						IHotelService hotelService = new HotelService();
						Models.HotelCheckInResponse hotelResponse = await hotelService.VerifyCheckinDetailAsync(new Models.HotelCheckInRequest()
						{
							Id = ip[1],
							Certificate = Helper.Helper.QrCertificateKey
						});
						if (hotelResponse != null)
						{
							if (hotelResponse.UserId.Equals(Helper.Helper.UserId))
							{
								Helper.Helper.HotelCheckinId = ip[1];
								Helper.Helper.IsHotelCheckInFromQrScan = true;
								Application.Current.MainPage = new NavigationPage(new Views.VerifyPasswordPage());
							}
							else
							{
								ILoginService serviceLogin = new LoginService();
								await serviceLogin.ClearLoginAsync(Helper.Helper.QrCertificateKey);
								Application.Current.MainPage = new NavigationPage(new Views.Hotel.HotelCheckInErrorPage());
							}
						}
					}
					else if (textHotel.Equals("login"))
						await Navigation.PushAsync(new Views.VerifyPasswordPage());
					else if (textHotel.Equals("checkin_dependent"))
					{
						Helper.Helper.IsFromScanQrDependent = true;
						await Navigation.PushAsync(new Views.Dependent.DependentListForCheckInPage());
					}
					else if (textHotel.Equals("payForDishes"))
					{
						Helper.Helper.IsScanQrPayForDishe = true;
						int payForDishesCount = System.Convert.ToInt32(ip[3]);
						if (payForDishesCount == 0)
						{
							//Means cash payment for Dishes.
							Helper.Helper.IsCashPayForDishe = true;
							await Navigation.PushAsync(new Views.PayForDishes.VerifyPayForDishesPasswordPage());
						}
						else if (payForDishesCount == 1)
						{
							//Means payment from card for Dishes.
							Helper.Helper.IsCashPayForDishe = false;
							await Navigation.PushAsync(new Views.PayForDishes.SelectUserProfileForPayForDishePage());
						}
					}
					else
					{
						int result = await service.GetUserStatusCompanyRequirementAsync(new Models.GetUserStatusCompanyRequirementRequest()
						{
							Id = ip[1],
							UserId = Helper.Helper.UserId
						});
						if (result == 0)
						{
							ShowMissingPreCheckInInfoPage();
						}
						else
							await Navigation.PushAsync(new Views.IWantToPayPage());
					}
					//await Navigation.PushAsync(new Views.SignInFromOtherCompanyPage(ip[2]));
				}
			}
			else if (response == 2)
				await Navigation.PushAsync(new Views.InvalidQrCodePage());
			else if (response == 3)
				await Navigation.PushAsync(new Views.UserUnauthorizedPage());
			else
				await Navigation.PushAsync(new Views.UserAlertPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Is Already Login Command.
		private ICommand isAlreadyLoginCommand;
		public ICommand IsAlreadyLoginCommand
		{
			get => isAlreadyLoginCommand ?? (isAlreadyLoginCommand = new Command(async () => await ExecuteIsAlreadyLoginCommand()));
		}
		private async Task ExecuteIsAlreadyLoginCommand()
		{
			if (Application.Current.Properties.ContainsKey("QrCode"))
			{
				DependencyService.Get<IProgressBar>().Show();
				Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
				ILoginService service = new LoginService();
				Models.CheckValidQrResponse response = await service.CheckValidQrAsync(Helper.Helper.QrCertificateKey);
				if (response?.result > 0)
				{
					Models.User user = new Models.User()
					{
						first_name = response.first_name,
						last_name = response.last_name,
						user_id = response.id,
						email = response.email,
						UserImage = response.image,
					};
					Helper.Helper.CountryCode = response.country_code;
					Helper.Helper.UserInfo = user;
					Helper.Helper.UserId = user.user_id;
					Helper.Helper.UserEmail = response.email;
					UserInfo = user;
					Microsoft.AppCenter.AppCenter.SetUserId(response.email);
					//EmployerRequestCountCommand.Execute(null);
					//DisplayUserName = $"{user.first_name} {user.last_name}";
					//UserImage = response.image;

					Helper.Helper.GenerateCertificateIdentificatorValue = response.identificator;
					if (response.identificator == 1 || response.identificator == 2)
						Application.Current.MainPage = new NavigationPage(new Views.Info.WantToCompletePayInfoMsgPage());
					else if (response.identificator == 0 || response.identificator == -1)
						Application.Current.MainPage = new NavigationPage(new Views.Info.WantToCompleteCheckInInfoPage());
					else
					{
						IDashboardService dashboardService = new DashboardService();
						var dashboardServiceResponse = await dashboardService.ApartmentReservationConfermationRequiredAsync(new Models.ApartmentReservationConfermationRequest()
						{
							UserId = Helper.Helper.UserId
						});
						if (dashboardServiceResponse?.Count > 0)
							DashboardItemList[0].IsBooking = true;
						else
							DashboardItemList[0].IsBooking = false;
					}
				}
				else
					await Navigation.PushAsync(new Views.InvalidCertificatePage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		//#region Login From Url Ip Command.
		//private ICommand loginFromUrlIpCommand;
		//public ICommand LoginFromUrlIpCommand
		//{
		//	get => loginFromUrlIpCommand ?? (loginFromUrlIpCommand = new Command(async () => await ExecuteLoginFromUrlIpCommand()));
		//}
		//private async Task ExecuteLoginFromUrlIpCommand()
		//{
		//	if (Application.Current.Properties.ContainsKey("QrCode"))
		//	{
		//		DependencyService.Get<IProgressBar>().Show();
		//		Helper.Helper.QrCertificateKey = Application.Current.Properties["QrCode"].ToString();
		//		ILoginService service = new LoginService();
		//		Models.CheckValidQrResponse response = await service.CheckValidQrAsync(Helper.Helper.QrCertificateKey);
		//		if (response.result > 0)
		//		{
		//			Models.User user = new Models.User();
		//			user.first_name = Application.Current.Properties["FirstName"].ToString();
		//			user.last_name = Application.Current.Properties["LastName"].ToString();
		//			user.user_id = Convert.ToInt32(Application.Current.Properties["UserId"]);
		//			user.UserImage = response.image;
		//			Helper.Helper.UserInfo = user;
		//			LoginToDesktopCommand.Execute(Helper.Helper.IpFromURL);
		//		}
		//		else
		//			await Navigation.PushAsync(new Views.InvalidCertificatePage());
		//		DependencyService.Get<IProgressBar>().Hide();
		//	}
		//}
		//#endregion

		#region Get User Image Command.
		private ICommand getUserImageCommand;
		public ICommand GetUserImageCommand
		{
			get => getUserImageCommand ?? (getUserImageCommand = new Command(async () => await ExecuteGetUserImageCommand()));
		}
		private async Task ExecuteGetUserImageCommand()
		{
			if (!string.IsNullOrWhiteSpace(Helper.Helper.QrCertificateKey))
			{
				ILoginService service = new LoginService();
				Models.CheckValidQrResponse response = await service.CheckValidQrAsync(Helper.Helper.QrCertificateKey);
				if (response.result > 0)
				{
					if (!UserImage.Equals(response.image))
					{
						UserImage = response.image; //ImageSource.FromUri(new Uri(response.image));
						UserInfo.UserImage = UserImage;
						Helper.Helper.UserInfo.UserImage = response.image;
					}
					Helper.Helper.UserId = response.id;
					Helper.Helper.UserEmail = response.email;
					Helper.Helper.CountryCode = response.country_code;
					UserInfo.first_name = response.first_name;
					UserInfo.last_name = response.last_name;
					UserInfo.user_id = response.id;
					UserInfo.email = response.email;
					Helper.Helper.UserInfo = UserInfo;
					//DisplayUserName = $"{response.first_name} {response.last_name}";
					EmployerRequestCountCommand.Execute(null);

					Helper.Helper.GenerateCertificateIdentificatorValue = response.identificator;
					/*if (response.identificator == 1 || response.identificator == 2)
						Application.Current.MainPage = new NavigationPage(new Views.Info.WantToCompletePayInfoMsgPage());
					else if (response.identificator == 0 || response.identificator == -1)
						Application.Current.MainPage = new NavigationPage(new Views.Info.WantToCompleteCheckInInfoPage());*/
				}
			}
		}
		#endregion

		#region Consent Command.
		private ICommand consentCommand;
		public ICommand ConsentCommand
		{
			get => consentCommand ?? (consentCommand = new Command(async () => await ExecuteConsentCommand()));
		}
		private async Task ExecuteConsentCommand()
		{
			if (EmployerRequestCount > 0)
			{
				if (EmployerRequestCount == 1)
					EmployerRequestReceivedCommand.Execute(null);
				else
					await Navigation.PushAsync(new Views.ConsentListPage());
			}
			await Task.CompletedTask;
		}
		#endregion

		#region Manage Card Command.
		private ICommand manageCardCommand;
		public ICommand ManageCardCommand
		{
			get => manageCardCommand ?? (manageCardCommand = new Command(async () => await ExecuteManageCardCommand()));
		}
		private async Task ExecuteManageCardCommand()
		{
			await Navigation.PushAsync(new Views.CardListPage());
		}
		#endregion

		#region Land Loard Consent Command.
		private ICommand landLoardConsentCommand;
		public ICommand LandLoardConsentCommand
		{
			get => landLoardConsentCommand ?? (landLoardConsentCommand = new Command(async () => await ExecuteLandLoardConsentCommand()));
		}
		private async Task ExecuteLandLoardConsentCommand()
		{
			await Navigation.PushAsync(new Views.Consent.LandLoardConsentPage());
		}
		#endregion

		#region Settings Command.
		private ICommand settingsCommand;
		public ICommand SettingsCommand
		{
			get => settingsCommand ?? (settingsCommand = new Command(async () => await ExecuteSettingsCommand()));
		}
		private async Task ExecuteSettingsCommand()
		{
			await Navigation.PushAsync(new Views.SettingsPage());
		}
		#endregion

		#region Booking Command.
		private ICommand bookingCommand;
		public ICommand BookingCommand
		{
			get => bookingCommand ?? (bookingCommand = new Command(async () => await ExecuteBookingCommand()));
		}
		private async Task ExecuteBookingCommand()
		{
			await Navigation.PushAsync(new Views.Booking.ManageYourReservationsPage());
		}
		#endregion

		#region Employer Request Count Command.
		private ICommand employerRequestCountCommand;
		public ICommand EmployerRequestCountCommand
		{
			get => employerRequestCountCommand ?? (employerRequestCountCommand = new Command(async () => await ExecuteEmployerRequestCountCommand()));
		}
		private async Task ExecuteEmployerRequestCountCommand()
		{
			IEmployerService service = new EmployerService();
			EmployerRequestCount = await service.EmployerRequestCountAsync(new Models.EmployerRequest()
			{ UserId = Helper.Helper.UserId });
		}
		#endregion

		#region Employer Request Received Command.
		private ICommand employerRequestReceivedCommand;
		public ICommand EmployerRequestReceivedCommand
		{
			get => employerRequestReceivedCommand ?? (employerRequestReceivedCommand = new Command(async () => await ExecuteEmployerRequestReceivedCommand()));
		}
		private async Task ExecuteEmployerRequestReceivedCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IEmployerService service = new EmployerService();
			var employerRequests = await service.EmployerRequestReceivedAsync(new Models.EmployerRequest()
			{
				UserId = Helper.Helper.UserId
			});
			await Navigation.PushAsync(new Views.EmployerDetailsPage(employerRequests[0]));
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region My Net Work Command.
		private ICommand myNetWorkCommand;
		public ICommand MyNetWorkCommand
		{
			get => myNetWorkCommand ?? (myNetWorkCommand = new Command(async () => await ExecuteMyNetWorkCommand()));
		}
		private async Task ExecuteMyNetWorkCommand()
		{
			await Navigation.PushAsync(new Views.Dependent.DependentListPage());
		}
		#endregion

		#region Bind Dash board Item List.
		void BindDashboardItemList()
		{
			if (DashboardItemList == null)
			{
				var dashboardItems = new List<DashboardItem>();
				dashboardItems.Add(new DashboardItem() { Id = 0, Heading = "Booking", IconColor = "#FF0000", HeadingIcon = Helper.QloudidAppFlatIcons.Home, SubHeading = "A booking requires your attention" , IsBooking = false });
				dashboardItems.Add(new DashboardItem() { Id = 1, Heading = "Consent", IconColor = "#FF0000", HeadingIcon = Helper.QloudidAppFlatIcons.Home, SubHeading = "Get started.", IsBooking = true });
				dashboardItems.Add(new DashboardItem() { Id = 2, Heading = "Landloard Consent", IconColor = "#FF0000", HeadingIcon = Helper.QloudidAppFlatIcons.Home, SubHeading = "Get started.", IsBooking = true });
				dashboardItems.Add(new DashboardItem() { Id = 3, Heading = "Cards", IconColor = "#00FF00", HeadingIcon = Helper.QloudidAppFlatIcons.CardBulletedOutline, SubHeading = "Mange your cards here.", IsBooking = true });
				dashboardItems.Add(new DashboardItem() { Id = 4, Heading = "Corona Care", IconColor = "#0000FF", HeadingIcon = Helper.QloudidAppFlatIcons.CoronaCare, SubHeading = "Help or ask for help in the corona crisis.", IsBooking = true });
				dashboardItems.Add(new DashboardItem() { Id = 5, Heading = "Connect", IconColor = "#FFFF00", HeadingIcon = Helper.QloudidAppFlatIcons.Connect, SubHeading = "Connect with your kin using code.", IsBooking = true });
				dashboardItems.Add(new DashboardItem() { Id = 6, Heading = "Parent", IconColor = "#00FFFF", HeadingIcon = Helper.QloudidAppFlatIcons.Parent, SubHeading = "Parent invitation.", IsBooking = true });
				dashboardItems.Add(new DashboardItem() { Id = 7, Heading = "Employer", IconColor = "#FF00FF", HeadingIcon = Helper.QloudidAppFlatIcons.Employer, SubHeading = "Employer request.", IsBooking = true });
				dashboardItems.Add(new DashboardItem() { Id = 8, Heading = "Parent", IconColor = "#800000", HeadingIcon = Helper.QloudidAppFlatIcons.Parent, SubHeading = "Parent request." , IsBooking = true });
				dashboardItems.Add(new DashboardItem() { Id = 9, Heading = "Kin", IconColor = "#808000", HeadingIcon = Helper.QloudidAppFlatIcons.Kin, SubHeading = "A kin wants to connect with you in case of emergency." , IsBooking = true });
				dashboardItems.Add(new DashboardItem() { Id = 10, Heading = "Duties", IconColor = "#008000", HeadingIcon = Helper.QloudidAppFlatIcons.Duties, SubHeading = "At companies." , IsBooking = true });
				dashboardItems.Add(new DashboardItem() { Id = 11, Heading = "Guardian", IconColor = "#800080", HeadingIcon = Helper.QloudidAppFlatIcons.Guardian, SubHeading = "Guardian request." , IsBooking = true });
				dashboardItems.Add(new DashboardItem() { Id = 12, Heading = "Employer Search", IconColor = "#008080", HeadingIcon = Helper.QloudidAppFlatIcons.EmployerSearch, SubHeading = "Connect with an employer, a landlord or a school here." , IsBooking = true });
				dashboardItems.Add(new DashboardItem() { Id = 13, Heading = "School", IconColor = "#000080", HeadingIcon = Helper.QloudidAppFlatIcons.School, SubHeading = "School search." , IsBooking = true });
				DashboardItemList = new ObservableCollection<DashboardItem>(dashboardItems);
			}
		}
		#endregion

		#region Show Missing Pre Check In Info Page.
		async void ShowMissingPreCheckInInfoPage()
		{
			DependencyService.Get<IProgressBar>().Show();
			IPreCheckInService preCheckInService = new PreCheckInService();
			/*var responsePreCheckinStatus = await preCheckInService.GetPreCheckinStatusAsync(new Models.GetPreCheckinStatusRequest()
			{
				Id = id,
				userId = Helper.Helper.UserId
			});
			Helper.Helper.PreCheckinStatusInfo = responsePreCheckinStatus;*/
			Helper.Helper.PreCheckinStatusInfo = new Models.GetPreCheckinStatusResponse()
			{
				Name = Helper.Helper.UserInfo.DisplayUserName
			};

			var responseUserActiveStatus = await preCheckInService.GetUserActiveStatusAsync(new Models.GetUserActiveStatusRequest()
			{
				UserId = Helper.Helper.UserId
			});
			Helper.Helper.PreCheckInUserActiveStatusInfo = responseUserActiveStatus;
			DependencyService.Get<IProgressBar>().Hide();
			await Navigation.PushAsync(new Views.PreCheckIn.MissingPreCheckInInfoPage());
		}
		#endregion

		#region Properties.
		private Models.User userInfo;
		public Models.User UserInfo
		{
			get => userInfo;
			set
			{
				userInfo = value;
				OnPropertyChanged("UserInfo");
			}
		}


		//public string UserImage1 => "https://www.qloudid.com/estorecss/tmp.jpg"; //Helper.Helper.UserInfo.UserImage; //$"https://www.qloudid.com/estorecss/tmp.jpg";

		private string userImage;
		public string UserImage
		{
			get => userImage;
			set
			{
				userImage = value;
				OnPropertyChanged("UserImage");
				IsUserImage = string.IsNullOrWhiteSpace(value) ? false : true;
				IsAppLogo = string.IsNullOrWhiteSpace(value) ? true : false;
			}
		}

		private string displayUserName;
		public string DisplayUserName
		{
			get => displayUserName;
			set
			{
				displayUserName = value;
				OnPropertyChanged("DisplayUserName");
			}
		}

		public string AppVersion => Xamarin.Essentials.VersionTracking.CurrentVersion;

		private bool isUserImage;
		public bool IsUserImage
		{
			get => isUserImage;
			set
			{
				isUserImage = value;
				OnPropertyChanged("IsUserImage");
			}
		}

		private bool isAppLogo;
		public bool IsAppLogo
		{
			get => isAppLogo;
			set
			{
				isAppLogo = value;
				OnPropertyChanged("IsAppLogo");
			}
		}

		private int employerRequestCount;
		public int EmployerRequestCount
		{
			get => employerRequestCount;
			set
			{
				employerRequestCount = value;
				IsEmployerRequestCount = value > 0 ? true : false;
				OnPropertyChanged("EmployerRequestCount");
			}
		}

		private bool isEmployerRequestCount = false;
		public bool IsEmployerRequestCount
		{
			get => isEmployerRequestCount;
			set
			{
				isEmployerRequestCount = value;
				OnPropertyChanged("IsEmployerRequestCount");
			}
		}

		public ObservableCollection<DashboardItem> dashboardItemList;
		public ObservableCollection<DashboardItem> DashboardItemList
		{
			get => dashboardItemList;
			set
			{
				dashboardItemList = value;
				OnPropertyChanged("DashboardItemList");
			}
		}
		#endregion
	}
}
public class DashboardItem : Qloudid.Models.BaseModel
{
	public int Id { get; set; }
	public string Heading { get; set; }
	public string SubHeading { get; set; }
	public string HeadingIcon { get; set; }
	public string IconColor { get; set; }

	private bool isBooking;
	public bool IsBooking
	{ 
		get => isBooking;
		set
		{
			isBooking = value;
			OnPropertyChanged("IsBooking");
		}
	}
}