using System.Linq;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class SelectUserProfileForPayForDisheViewModel : BaseViewModel
	{
		#region Constructor.
		public SelectUserProfileForPayForDisheViewModel(INavigation navigation)
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


			List<Models.Company> response = await service.GetCompanyAsync(new Models.Profile() { user_id = Helper.Helper.UserId });

			var listPersonal = new Models.CompanyInfo()
			{
				new Models.Company
				{
					id = 0,
					company_name =$"{Helper.Helper.UserInfo.first_name} {Helper.Helper.UserInfo.last_name}",
					company_email= Helper.Helper.UserInfo.email,
				},
			};
			listPersonal.Heading = "Personal";
			var list = new List<Models.CompanyInfo>();
			list.Add(listPersonal);
			if (response?.Count > 0)
			{
				Models.CompanyInfo listCompany = new Models.CompanyInfo();
				foreach (var item in response) listCompany.Add(item);
				listCompany.Heading = "Employer";
				list.Add(listCompany);
			}
			ListOfCompany = list;
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
				var company = companies.FirstOrDefault(x => x.IsChecked);
				if (company != null)
				{
					Helper.Helper.CompanyId = company.id;
					await Navigation.PushAsync(new Views.PayForDishes.CardListForPayForDishePage());
				}
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.CompanyInfo> _listOfCompany;
		public List<Models.CompanyInfo> ListOfCompany
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
		#endregion
	}
}
