using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Property
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLandlordPage : ContentPage
    {
        AddLandlordPageViewModel viewModel;
        public AddLandlordPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AddLandlordPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.UserPropertyCommand.Execute(null);
        }
    }
}