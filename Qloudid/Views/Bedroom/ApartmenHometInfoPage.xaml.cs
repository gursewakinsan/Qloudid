using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApartmenHometInfoPage : ContentPage
    {
        ApartmenHometInfoPageViewModel viewModel;
        public ApartmenHometInfoPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ApartmenHometInfoPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetAddressByIdCommand.Execute(null);
        }
    }
}
