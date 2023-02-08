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
            viewModel.ApartmentCheckedinInfoCommand.Execute(null);
        }

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

        async void CheckedInListTapped(Models.ApartmentCheckedinInfoResponse apartment)
        {
            await Navigation.PushAsync(new ProcessToCheckOutPage(apartment));
        }

        
    }
}
