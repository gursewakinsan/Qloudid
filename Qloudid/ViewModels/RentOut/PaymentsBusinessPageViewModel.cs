using System;
using Xamarin.Forms;
using Qloudid.Service;
using Qloudid.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.ViewModels
{
    public class PaymentsBusinessPageViewModel : BaseViewModel
    {
		#region Constructor.
		public PaymentsBusinessPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			Address = Helper.Helper.SelectedUserAddress;
		}
		#endregion

		#region Bind Month And Year
		private void BindMonthAndYear()
		{
			IssueMonthList = new List<string>();
			for (int issueMonth = 1; issueMonth < 13; issueMonth++)
				IssueMonthList.Add($"{issueMonth}");
			SelectedIssueMonth = IssueMonthList[0];

			IssueYearList = new List<string>();
			int issueYear = DateTime.Today.Year;
			for (int i = 0; i < 50; i++)
			{
				IssueYearList.Add($"{issueYear}");
				issueYear = issueYear - 1;
			}
			SelectedIssueYear = IssueYearList[0];
		}
		#endregion

		#region Properties.
		private Models.EditAddressResponse address;
		public Models.EditAddressResponse Address
		{
			get => address;
			set
			{
				address = value;
				OnPropertyChanged("Address");
			}
		}

		private List<string> issueMonthList;
		public List<string> IssueMonthList
		{
			get => issueMonthList;
			set
			{
				issueMonthList = value;
				OnPropertyChanged("IssueMonthList");
			}
		}

		private string selectedIssueMonth;
		public string SelectedIssueMonth
		{
			get => selectedIssueMonth;
			set
			{
				selectedIssueMonth = value;
				OnPropertyChanged("SelectedIssueMonth");
			}
		}

		private List<string> issueYearList;
		public List<string> IssueYearList
		{
			get => issueYearList;
			set
			{
				issueYearList = value;
				OnPropertyChanged("IssueYearList");
			}
		}

		private string selectedIssueYear;
		public string SelectedIssueYear
		{
			get => selectedIssueYear;
			set
			{
				selectedIssueYear = value;
				OnPropertyChanged("SelectedIssueYear");
			}
		}
		#endregion
	}
}
