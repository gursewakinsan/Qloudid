using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Collections.Generic;

namespace Qloudid.Views.Visitors
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InvitedVisitorsMeetingCompanyListPage : ContentPage
	{
		InvitedVisitorsMeetingCompanyListPageViewModel viewModel;
		public InvitedVisitorsMeetingCompanyListPage(List<Models.Company> companies)
		{
			InitializeComponent();
			BindingContext = viewModel = new InvitedVisitorsMeetingCompanyListPageViewModel(this.Navigation);
			viewModel.CompanyList = new System.Collections.ObjectModel.ObservableCollection<Models.Company>(companies);
		}


		#region
		private void OnLabelEmployeeItemTapped(object sender, System.EventArgs e)
		{
			Label control = sender as Label;
			Models.Company employee = control.BindingContext as Models.Company;
			SelectedEmployeeForMeeting(employee);
		}

		private void OnGridEmployeeItemTapped(object sender, System.EventArgs e)
		{
			Grid control = sender as Grid;
			Models.Company employee = control.BindingContext as Models.Company;
			SelectedEmployeeForMeeting(employee);
		}

		private void SelectedEmployeeForMeeting(Models.Company employee)
		{
			foreach (var item in viewModel.CompanyList)
			{
				if (employee.id.Equals(item.id))
				{
					if (item.IsSelectedEmployee)
					{
						item.IsSelectedEmployee = false;
						viewModel.IsVisibleSubmit = false;
						item.EmployeeCardBorderColor = Color.FromHex("#363541");
						item.EmployeeNameTextOpacity = 0.4;
					}
					else
					{
						item.IsSelectedEmployee = true;
						viewModel.IsVisibleSubmit = true;
						item.EmployeeCardBorderColor = Color.FromHex("#45C366");
						item.EmployeeNameTextOpacity = 100;
						Helper.Helper.VisitorProfileId = item.id;
					}
				}
				else
				{
					item.EmployeeCardBorderColor = Color.FromHex("#363541");
					item.EmployeeNameTextOpacity = 0.4;
				}
			}
		}
		#endregion
	}
}