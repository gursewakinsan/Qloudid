using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.VerifyPassword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerifyHabitantPasswordPage : ContentPage
    {
        VerifyHabitantPasswordPageViewModel viewModel;
        public VerifyHabitantPasswordPage(string id)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new VerifyHabitantPasswordPageViewModel(this.Navigation);
            viewModel.HabitantId = id;
        }

        private void OnCloseButtonClicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new DashboardPage());
        }
    }
}