using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageCheckedInAndOutPage : ContentPage
    {
        ManageCheckedInAndOutPageViewModel viewModel;
        public ManageCheckedInAndOutPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ManageCheckedInAndOutPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.SelectedTabCommand.Execute("CheckedIn");
        }

        #region On Checked In Tapped.
        void OnButtonClicked(System.Object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            CheckedInListTapped(control.BindingContext as Models.ApartmentCheckedinInfoResponse);
        }

        void OnLabelClicked(System.Object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            CheckedInListTapped(control.BindingContext as Models.ApartmentCheckedinInfoResponse);
        }

        void OnStackLayoutClicked(System.Object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            CheckedInListTapped(control.BindingContext as Models.ApartmentCheckedinInfoResponse);
        }

        async void CheckedInListTapped(Models.ApartmentCheckedinInfoResponse apartmentCheckedIn)
        {
            await Navigation.PushAsync(new ProcessToCheckInPage(apartmentCheckedIn));
        }
        #endregion

        #region On Checked Out Tapped.
        void OnButtonCheckedOutClicked(System.Object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            CheckedOutListTapped(control.BindingContext as Models.ApartmentCheckedinInfoResponse);
        }

        void OnLabelCheckedOutClicked(System.Object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            CheckedOutListTapped(control.BindingContext as Models.ApartmentCheckedinInfoResponse);
        }

        void OnStackLayoutCheckedOutClicked(System.Object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            CheckedOutListTapped(control.BindingContext as Models.ApartmentCheckedinInfoResponse);
        }

        async void CheckedOutListTapped(Models.ApartmentCheckedinInfoResponse apartmentCheckedOut)
        {
            await Navigation.PushAsync(new ProcessToCheckOutPage(apartmentCheckedOut));
        }
        #endregion
    }
}
