using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
	public class InvitedVisitorsMeetingUserPageViewModel : BaseViewModel
	{
		#region Constructor.
		public InvitedVisitorsMeetingUserPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Sumbit Selected Invited Visitors Command.
		private ICommand sumbitSelectedInvitedVisitorsCommand;
		public ICommand SumbitSelectedInvitedVisitorsCommand
		{
			get => sumbitSelectedInvitedVisitorsCommand ?? (sumbitSelectedInvitedVisitorsCommand = new Command(async () => await ExecuteSumbitSelectedInvitedVisitorsCommand()));
		}
		private async Task ExecuteSumbitSelectedInvitedVisitorsCommand()
		{
			if (IsPersonal)
			{
				Helper.Helper.VisitorProfileId = Helper.Helper.UserId;
				await Navigation.PushAsync(new Views.Visitors.VerifyInvitedVisitorsMeetingPasswordPage());
			}
			else
			{
				if (CompanyList.Count > 1)
				{
					foreach (var emp in CompanyList)
					{
						emp.IsSelectedEmployee = false;
						emp.EmployeeCardBorderColor = Color.FromHex("#363541");
						emp.EmployeeNameTextOpacity = 0.4;
					}
					await Navigation.PushAsync(new Views.Visitors.InvitedVisitorsMeetingCompanyListPage(CompanyList));
				}
				else
				{
					Helper.Helper.VisitorProfileId = CompanyList[0].id;
					await Navigation.PushAsync(new Views.Visitors.VerifyInvitedVisitorsMeetingPasswordPage());
				}
			}
		}
		#endregion

		#region Selected Type Of Meeting Command.
		private ICommand selectedTypeOfMeetingCommand;
		public ICommand SelectedTypeOfMeetingCommand
		{
			get => selectedTypeOfMeetingCommand ?? (selectedTypeOfMeetingCommand = new Command<string>((meetingType) => ExecuteSelectedTypeOfMeetingCommand(meetingType)));
		}
		private void ExecuteSelectedTypeOfMeetingCommand(string meetingType)
		{
			switch (meetingType)
			{
				case "Personal":
					if (IsBusiness)
					{
						IsBusiness = false;
						IsVisibleSubmit = false;
						BusinessCardBorderColor = Color.FromHex("#363541");
						BusinessNameTextOpacity = 0.4;
					}
					if (IsPersonal)
					{
						IsPersonal = false;
						IsVisibleSubmit = false;
						PersonalCardBorderColor = Color.FromHex("#363541");
						PersonalNameTextOpacity = 0.4;
					}
					else
					{
						IsPersonal = true;
						IsVisibleSubmit = true;
						PersonalCardBorderColor = Color.FromHex("#45C366");
						PersonalNameTextOpacity = 100;
					}
					break;
				case "Business":
					if (IsPersonal)
					{
						IsPersonal = false;
						IsVisibleSubmit = false;
						PersonalCardBorderColor = Color.FromHex("#363541");
						PersonalNameTextOpacity = 0.4;
					}
					if (IsBusiness)
					{
						IsBusiness = false;
						IsVisibleSubmit = false;
						BusinessCardBorderColor = Color.FromHex("#363541");
						BusinessNameTextOpacity = 0.4;
					}
					else
					{
						IsBusiness = true;
						IsVisibleSubmit = true;
						BusinessCardBorderColor = Color.FromHex("#45C366");
						BusinessNameTextOpacity = 100;
					}
					break;
			}
		}
		#endregion

		#region Properties.
		private List<Models.Company> companyList;
		public List<Models.Company> CompanyList
		{
			get { return companyList; }
			set
			{
				companyList = value;
				OnPropertyChanged("CompanyList");
			}
		}

		private bool isPersonal;
		public bool IsPersonal
		{
			get { return isPersonal; }
			set
			{
				isPersonal = value;
				OnPropertyChanged("IsPersonal");
			}
		}

		private bool isBusiness;
		public bool IsBusiness
		{
			get { return isBusiness; }
			set
			{
				isBusiness = value;
				OnPropertyChanged("IsBusiness");
			}
		}

		private string businessCardArrow;
		public string BusinessCardArrow
		{
			get { return businessCardArrow; }
			set
			{
				businessCardArrow = value;
				OnPropertyChanged("BusinessCardArrow");
			}
		}

		private Color personalCardBorderColor = Color.FromHex("#363541");
		public Color PersonalCardBorderColor
		{
			get => personalCardBorderColor;
			set
			{
				personalCardBorderColor = value;
				OnPropertyChanged("PersonalCardBorderColor");
			}
		}

		private double personalNameTextOpacity = 0.4;
		public double PersonalNameTextOpacity
		{
			get => personalNameTextOpacity;
			set
			{
				personalNameTextOpacity = value;
				OnPropertyChanged("PersonalNameTextOpacity");
			}
		}

		private Color businessCardBorderColor = Color.FromHex("#363541");
		public Color BusinessCardBorderColor
		{
			get => businessCardBorderColor;
			set
			{
				businessCardBorderColor = value;
				OnPropertyChanged("BusinessCardBorderColor");
			}
		}

		private double businessNameTextOpacity = 0.4;
		public double BusinessNameTextOpacity
		{
			get => businessNameTextOpacity;
			set
			{
				businessNameTextOpacity = value;
				OnPropertyChanged("BusinessNameTextOpacity");
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
