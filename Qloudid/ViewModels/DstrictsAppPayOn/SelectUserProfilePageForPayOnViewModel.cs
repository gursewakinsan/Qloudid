using System;
using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
	public class SelectUserProfilePageForPayOnViewModel : BaseViewModel
	{
		#region Constructor.
		public SelectUserProfilePageForPayOnViewModel(INavigation navigation)
		{
			Navigation = navigation;
			if (Helper.Helper.UserInfo == null)
				Helper.Helper.UserInfo = new Models.User();
		}
		#endregion

		#region Get Company List Command.
		private ICommand getCompanyCommand;
		public ICommand GetCompanyCommand
		{
			get => getCompanyCommand ?? (getCompanyCommand = new Command(async () => await ExecuteGetCompanyCommand()));
		}
		private async Task ExecuteGetCompanyCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IPurchaseService service = new PurchaseService();

			if (Helper.Helper.UserInfo == null)
			{
				Models.User user = new Models.User();
				user.first_name = $"{Application.Current.Properties["FirstName"]}";
				user.last_name = $"{Application.Current.Properties["LastName"]}";
				user.user_id = Convert.ToInt32(Application.Current.Properties["UserId"]);
				user.email = $"{Application.Current.Properties["Email"]}";
				Helper.Helper.QrCertificateKey = $"{Application.Current.Properties["QrCode"]}";

				if (string.IsNullOrWhiteSpace(user.first_name))
					user.first_name = "first_name";
				if (string.IsNullOrWhiteSpace(user.last_name))
					user.last_name = "last_name-";

				Helper.Helper.UserInfo = user;

				Helper.Helper.UserId = user.user_id;
				Helper.Helper.UserEmail = user.email;
			}

			if (Helper.Helper.UserInfo == null)
			{
				Helper.Helper.UserInfo = new Models.User();
				ILoginService loginService = new LoginService();

				if (string.IsNullOrWhiteSpace(Helper.Helper.QrCertificateKey))
				{
					if (Application.Current.Properties.ContainsKey("QrCode"))
						Helper.Helper.QrCertificateKey = $"{Application.Current.Properties["QrCode"]}";
					else
						Helper.Helper.QrCertificateKey = string.Empty;
				}

				Models.UserDetailResponse userDetail = await loginService.GetUserDetailAsync(new Models.UserDetailRequest()
				{
					Certificate = Helper.Helper.QrCertificateKey
				});
				if (userDetail != null)
				{
					Models.User user = new Models.User()
					{
						first_name = userDetail.first_name,
						last_name = userDetail.last_name,
						email = userDetail.email,
						user_id = userDetail.user_id,
						UserImage = userDetail.UserImage,
						certificate_key = userDetail.certificate_key
					};

					Helper.Helper.UserId = userDetail.user_id;
					Helper.Helper.UserEmail = userDetail.email;
					Helper.Helper.UserInfo = user;
				}
			}

			if (string.IsNullOrWhiteSpace(Helper.Helper.UserInfo.first_name) || string.IsNullOrWhiteSpace(Helper.Helper.UserInfo.last_name) || string.IsNullOrWhiteSpace(Helper.Helper.UserInfo.email))
			{
				Models.User user = new Models.User();
				user.first_name = $"{Application.Current.Properties["FirstName"]}";
				user.last_name = $"{Application.Current.Properties["LastName"]}";
				user.user_id = Convert.ToInt32(Application.Current.Properties["UserId"]);
				user.email = $"{Application.Current.Properties["Email"]}";
				Helper.Helper.QrCertificateKey = $"{Application.Current.Properties["QrCode"]}";

				if (string.IsNullOrWhiteSpace(user.first_name))
					user.first_name = "first_name";
				if (string.IsNullOrWhiteSpace(user.last_name))
					user.last_name = "last_name-";

				Helper.Helper.UserInfo = user;

				Helper.Helper.UserId = user.user_id;
				Helper.Helper.UserEmail = user.email;
			}


			List<Models.Company> response = await service.GetCompanyAsync(new Models.Profile() { user_id = Helper.Helper.UserId });

			/*var listPersonal = new Models.CompanyInfo()
			{
				new Models.Company
				{
					id = 0,
					company_name =$"{Helper.Helper.UserInfo.first_name} {Helper.Helper.UserInfo.last_name}",
					company_email= Helper.Helper.UserInfo.email,
				},
			};
			listPersonal.Heading = "Personal";*/
			var list = new List<Models.Company>();
			list.Add(new Models.Company()
			{
				id = 0,
				company_name = $"{Helper.Helper.UserInfo.first_name} {Helper.Helper.UserInfo.last_name}",
				company_email = Helper.Helper.UserInfo.email,
				IsPersonal = true,
				IsBusiness = false
			});

			//list.Add(listPersonal);
			if (response?.Count > 0)
			{
				//Models.CompanyInfo listCompany = new Models.CompanyInfo();
				foreach (var item in response)
				{
					item.IsPersonal = false;
					item.IsBusiness = false;
					list.Add(item);
				}
				//listCompany.Add(item);
				//listCompany.Heading = "Employer";

			}
			CopyCompanyList = list;
			ListOfCompany = new ObservableCollection<Models.Company>(list);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Submit Selected Company Command.
		private ICommand submitSelectedCompanyCommand;
		public ICommand SubmitSelectedCompanyCommand
		{
			get => submitSelectedCompanyCommand ?? (submitSelectedCompanyCommand = new Command(async () => await ExecuteSubmitSelectedCompanyCommand()));
		}
		private async Task ExecuteSubmitSelectedCompanyCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			foreach (var companies in ListOfCompany)
			{
				/*var company = companies.FirstOrDefault(x => x.IsChecked);
				if (company != null)
				{
					Helper.Helper.CompanyId = company.id;
					await Navigation.PushAsync(new Views.DstrictsAppPayOn.CardListPageForPayOn());
				}*/
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Show Personal Addresses Command.
		private ICommand showPersonalAddressesCommand;
		public ICommand ShowPersonalAddressesCommand
		{
			get => showPersonalAddressesCommand ?? (showPersonalAddressesCommand = new Command(async () => await ExecuteShowPersonalAddressesCommand()));
		}
		private async Task ExecuteShowPersonalAddressesCommand()
		{
			IsPersonalOrBusiness = true;
			BtnPersonalBg = "#6263ED";
			BtnBusinessBg = "#2A2A31";
			foreach (var personalAddresses in CopyCompanyList)
			{
				personalAddresses.IsBusiness = false;
				if (personalAddresses.id == 0)
					personalAddresses.IsPersonal = true;
				else
					personalAddresses.IsPersonal = false;
			}
			ListOfCompany = new ObservableCollection<Models.Company>(CopyCompanyList);
			await Task.CompletedTask;
		}
		#endregion

		#region Show Business Addresses Command.
		private ICommand showBusinessAddressesCommand;
		public ICommand ShowBusinessAddressesCommand
		{
			get => showBusinessAddressesCommand ?? (showBusinessAddressesCommand = new Command(async () => await ExecuteShowBusinessAddressesCommand()));
		}
		private async Task ExecuteShowBusinessAddressesCommand()
		{
			IsPersonalOrBusiness = false;
			BtnPersonalBg = "#2A2A31";
			BtnBusinessBg = "#6263ED";
			foreach (var personalAddresses in CopyCompanyList)
			{
				personalAddresses.IsPersonal = false;
				if (personalAddresses.id == 1)
					personalAddresses.IsBusiness = true;
				else
					personalAddresses.IsBusiness = false;
			}
			ListOfCompany = new ObservableCollection<Models.Company>(CopyCompanyList);
			await Task.CompletedTask;
		}
		#endregion

		#region Search Command.
		private ICommand searchCommand;
		public ICommand SearchCommand
		{
			get => searchCommand ?? (searchCommand = new Command(async () => await ExecuteSearchCommand()));
		}
		private async Task ExecuteSearchCommand()
		{
			if (!string.IsNullOrWhiteSpace(SearchText))
			{
				string text = SearchText.ToLower();
				if (CopyCompanyList?.Count > 0)
				{
					List<Models.Company> addresses = null;
					if (IsPersonalOrBusiness)
						addresses = CopyCompanyList.Where(x => x.AddressForSearch.ToLower().Contains(text) && x.IsPersonal == true).ToList();
					else
						addresses = CopyCompanyList.Where(x => x.AddressForSearch.ToLower().Contains(text) && x.IsBusiness == true).ToList();
					ListOfCompany = new ObservableCollection<Models.Company>(addresses);
				}
			}
			else
			{
				if (IsPersonalOrBusiness)
					ShowPersonalAddressesCommand.Execute(null);
				else
					ShowBusinessAddressesCommand.Execute(null);
			}
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public List<Models.Company> CopyCompanyList { get; set; }

		private ObservableCollection<Models.Company> _listOfCompany;
		public ObservableCollection<Models.Company> ListOfCompany
		{
			get { return _listOfCompany; }
			set
			{
				_listOfCompany = value;
				OnPropertyChanged("ListOfCompany");
			}
		}

		private bool isSubmit;
		public bool IsSubmit
		{
			get { return isSubmit; }
			set
			{
				isSubmit = value;
				OnPropertyChanged("IsSubmit");
			}
		}

		private string btnPersonalBg = "#6263ED";
		public string BtnPersonalBg
		{
			get { return btnPersonalBg; }
			set
			{
				btnPersonalBg = value;
				OnPropertyChanged("BtnPersonalBg");
			}
		}

		private string btnBusinessBg = "#2A2A31";
		public string BtnBusinessBg
		{
			get { return btnBusinessBg; }
			set
			{
				btnBusinessBg = value;
				OnPropertyChanged("BtnBusinessBg");
			}
		}

		private string searchText;
		public string SearchText
		{
			get { return searchText; }
			set
			{
				searchText = value;
				OnPropertyChanged("SearchText");
			}
		}

		public bool IsPersonalOrBusiness { get; set; } = true;
		#endregion
	}
}