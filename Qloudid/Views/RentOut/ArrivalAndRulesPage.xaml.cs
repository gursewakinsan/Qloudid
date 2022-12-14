using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArrivalAndRulesPage : ContentPage
    {
        ArrivalAndRulesPageViewModel viewModel;
        public ArrivalAndRulesPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ArrivalAndRulesPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetAddressByIdCommand.Execute(null);
        }
    }
}