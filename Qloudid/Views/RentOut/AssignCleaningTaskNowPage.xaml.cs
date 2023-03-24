using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssignCleaningTaskNowPage : ContentPage
    {
        AssignCleaningTaskNowPageViewModel viewModel;
        public AssignCleaningTaskNowPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AssignCleaningTaskNowPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ApartmentCheckedOutCleeningHistoryCommand.Execute(null);
        }

        async void OnCleeningHistoryItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            listCleeningHistory.SelectedItem = null;
            if (e.ItemIndex == 0)
            {
                Models.ApartmentCheckedOutCleeningHistoryResponse response = e.Item as Models.ApartmentCheckedOutCleeningHistoryResponse;
                await Navigation.PushAsync(new CleanByPage(new Models.ApartmentCheckedinInfoResponse()
                {
                    Id = response.Id
                }));
            }
        }
    }
}
