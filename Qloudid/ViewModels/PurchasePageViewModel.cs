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
	public class PurchasePageViewModel : BaseViewModel
	{
		#region Constructor.
		public PurchasePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
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
			List<Models.Company> response = await service.GetCompanyAsync(new Models.Profile() { user_id = Helper.Helper.UserInfo.user_id });
			var listPersonal = new Models.CompanyInfo()
			{
				new Models.Company { id = 0, company_name = "Personal profile",company_email="Personalprofile@pp.com" },
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
			OnPropertyChanged("ListOfCompany");
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
				IPurchaseService service = new PurchaseService();
				int response = await service.SubmitPurchaseDetailAsync(new Models.PurchaseDetail() { user_id = Helper.Helper.UserInfo.user_id, company_id = company.id });
				if (response == 1)
					Application.Current.MainPage = new NavigationPage(new Views.PurchaseSuccessfulPage());
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.CompanyInfo> _listOfCompany;
		public List<Models.CompanyInfo> ListOfCompany
		{ 
			get { return _listOfCompany; } 
			set { _listOfCompany = value; base.OnPropertyChanged(); } 
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
