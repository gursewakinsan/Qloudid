using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApartmentInfoPage : ContentPage
    {
        ApartmentInfoPageViewModel viewModel;
        public ApartmentInfoPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ApartmentInfoPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetAddressByIdCommand.Execute(null);
        }
    }
}