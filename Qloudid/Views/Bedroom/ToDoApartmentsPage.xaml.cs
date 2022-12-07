using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoApartmentsPage : ContentPage
    {
        ToDoApartmentsPageViewModel viewModel;
        public ToDoApartmentsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ToDoApartmentsPageViewModel(this.Navigation);
        }
    }
}