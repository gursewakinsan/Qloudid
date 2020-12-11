using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MobileNumberPage : ContentPage
	{
		MobileNumberPageViewModel viewModel;
		public MobileNumberPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new MobileNumberPageViewModel(this.Navigation);
		}

		private void MobileNumberTextChanged(object sender, TextChangedEventArgs args)
		{
			if (!string.IsNullOrWhiteSpace(args.NewTextValue))
			{
				bool isValid = args.NewTextValue.ToCharArray().All(char.IsDigit);
				((Controls.CustomEntry)sender).Text = isValid ? args.NewTextValue : args.OldTextValue;
			}
		}
	}
}