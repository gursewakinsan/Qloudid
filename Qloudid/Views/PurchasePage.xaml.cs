using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PurchasePage : ContentPage
	{
		PurchasePageViewModel viewModel;
		public PurchasePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new PurchasePageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetCompanyCommand.Execute(null);
		}

		private void OnCompanyItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.Company company = e.Item as Models.Company;
			foreach (var item in viewModel.CompanyList)
			{
				if(item.id.Equals(company.id))
					company.IsSelected = !company.IsSelected;
				else
					item.IsSelected = false;
			}
			listCompany.SelectedItem = null;
		}
	}
}