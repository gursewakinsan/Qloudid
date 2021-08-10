using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.PayForDishes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectUserProfileForPayForDishePage : ContentPage
	{
		SelectUserProfileForPayForDisheViewModel viewModel;
		public SelectUserProfileForPayForDishePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SelectUserProfileForPayForDisheViewModel(this.Navigation);
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
					{
						company.IsChecked = !company.IsChecked;
						viewModel.IsSubmit = company.IsChecked;
					}
					else
						item.IsChecked = false;
				}
			}
		}
	}
}