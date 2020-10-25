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
			if (response == null)
			{
				CompanyList = new ObservableCollection<Models.Company>();
				CompanyList.Add(new Models.Company() { id = 0, company_name = "Personal profile" });
			}
			else
			{
				response.Insert(0, new Models.Company() { id = 0, company_name = "Personal profile" });
				CompanyList = new ObservableCollection<Models.Company>(response);
			}
			OnPropertyChanged("CompanyList");
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
			var company = CompanyList.FirstOrDefault(x => x.IsSelected);
			if (company != null)
			{
				DependencyService.Get<IProgressBar>().Show();
				IPurchaseService service = new PurchaseService();
				int response = await service.SubmitPurchaseDetailAsync(new Models.PurchaseDetail() { user_id = Helper.Helper.UserInfo.user_id, company_id = company.id });
				if (response == 1)
					Application.Current.MainPage = new NavigationPage(new Views.PurchaseSuccessfulPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
			else
				await Helper.Alert.DisplayAlert("Please select company for purchase submit.");
		}
		#endregion

		#region Properties.
		public ObservableCollection<Models.Company> CompanyList { get; set; }
		#endregion
	}
}
