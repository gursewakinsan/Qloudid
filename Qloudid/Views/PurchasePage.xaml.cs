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
			listCompany.SelectedItem = null;
			foreach (var companies in viewModel.ListOfCompany)
			{
				foreach (var item in companies)
				{
					if (item.id.Equals(company.id))
						company.IsChecked = !company.IsChecked;
					else
						item.IsChecked = false;
				}
				var companyChecked = companies.FirstOrDefault(x => x.IsChecked);
				if (companyChecked != null)
					viewModel.IsSubmit = true;
				else
					viewModel.IsSubmit = false;
			}
		}
	}
}