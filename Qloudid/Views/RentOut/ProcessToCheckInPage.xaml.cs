using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProcessToCheckInPage : ContentPage
    {
        ProcessToCheckInPageViewModel viewModel;
        public ProcessToCheckInPage(Models.ApartmentCheckedinInfoResponse apartment)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ProcessToCheckInPageViewModel(this.Navigation);
            viewModel.SelectedApartmentCheckedInInfo = apartment;
            dPicker.Date = Convert.ToDateTime(apartment.CheckinDate);
        }
    }
}
