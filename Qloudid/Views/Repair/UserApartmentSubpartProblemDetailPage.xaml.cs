using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using Syncfusion.SfCalendar.XForms;

namespace Qloudid.Views.Repair
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserApartmentSubpartProblemDetailPage : ContentPage
    {
        UserApartmentSubpartProblemDetailPageViewModel viewModel;
        public UserApartmentSubpartProblemDetailPage(Models.UserApartmentProblemDetailResponse userApartment)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new UserApartmentSubpartProblemDetailPageViewModel(this.Navigation);
            viewModel.SelectedApartmentProblemDetail = userApartment;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.UserApartmentSubpartProblemDetailCommand.Execute(null);
        }

        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            OnItemTapped(control.BindingContext as Models.UserApartmentSubpartProblemDetailResponse);
        }

        private void OnLabelTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnItemTapped(control.BindingContext as Models.UserApartmentSubpartProblemDetailResponse);
        }

        async void OnItemTapped(Models.UserApartmentSubpartProblemDetailResponse response)
        {
            viewModel.SelectedApartmentProblemDetail.TicketTitle = response.SubpartTitle;
            viewModel.SelectedApartmentProblemDetail.SubpartInfo = response.SubpartInfo;
            await Navigation.PushAsync(new ReportTheProblemPage(viewModel.SelectedApartmentProblemDetail));
        }
    }
}