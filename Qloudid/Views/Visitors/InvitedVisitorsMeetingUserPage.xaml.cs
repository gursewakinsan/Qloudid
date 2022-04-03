using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System.Collections.Generic;

namespace Qloudid.Views.Visitors
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InvitedVisitorsMeetingUserPage : ContentPage
	{
		InvitedVisitorsMeetingUserPageViewModel viewModel;
		public InvitedVisitorsMeetingUserPage(List<Models.Company> companies)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new InvitedVisitorsMeetingUserPageViewModel(this.Navigation);
			viewModel.CompanyList = companies;
			if (companies.Count > 1)
				viewModel.BusinessCardArrow = Helper.QloudidAppFlatIcons.ChevronRightBox;
			else
				viewModel.BusinessCardArrow = Helper.QloudidAppFlatIcons.CheckboxMarked;
		}
	}
}