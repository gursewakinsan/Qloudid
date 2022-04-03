using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Qloudid.ViewModels
{
	public class InvitedVisitorsMeetingCompanyListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public InvitedVisitorsMeetingCompanyListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Sumbit Selected Employee Command.
		private ICommand sumbitSelectedEmployeeCommand;
		public ICommand SumbitSelectedEmployeeCommand
		{
			get => sumbitSelectedEmployeeCommand ?? (sumbitSelectedEmployeeCommand = new Command(async () => await ExecuteSumbitSelectedEmployeeCommand()));
		}
		private async Task ExecuteSumbitSelectedEmployeeCommand()
		{
			await Navigation.PushAsync(new Views.Visitors.VerifyInvitedVisitorsMeetingPasswordPage());
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.Company> companyList;
		public ObservableCollection<Models.Company> CompanyList
		{
			get { return companyList; }
			set
			{
				companyList = value;
				OnPropertyChanged("CompanyList");
			}
		}

		private bool isVisibleSubmit;
		public bool IsVisibleSubmit
		{
			get => isVisibleSubmit;
			set
			{
				isVisibleSubmit = value;
				OnPropertyChanged("IsVisibleSubmit");
			}
		}
		#endregion
	}
}
