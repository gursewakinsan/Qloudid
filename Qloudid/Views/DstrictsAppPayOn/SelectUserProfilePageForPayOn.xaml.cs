using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.DstrictsAppPayOn
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectUserProfilePageForPayOn : ContentPage
	{
		SelectUserProfilePageForPayOnViewModel viewModel;
		public SelectUserProfilePageForPayOn()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SelectUserProfilePageForPayOnViewModel(this.Navigation);
			viewModel.GetCompanyCommand.Execute(null);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private async void OnCompanyItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.Company company = e.Item as Models.Company;
			listCompany.SelectedItem = null;
			Helper.Helper.InvoiceAddressId = company.id;
			Helper.Helper.CompanyId = company.id;
			await Navigation.PushAsync(new CardListPageForPayOn());
			/*foreach (var companies in viewModel.ListOfCompany)
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
			}*/
		}
	}
}