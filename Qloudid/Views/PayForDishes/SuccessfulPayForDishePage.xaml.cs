using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views.PayForDishes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SuccessfulPayForDishePage : ContentPage
	{
		public SuccessfulPayForDishePage()
		{
			InitializeComponent();
		}

		private void OnContinueButtonClicked(object sender, EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new DashboardPage());
		}
	}
}