using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.RentOut
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProcessToCheckOutPage : ContentPage
    {
        ProcessToCheckOutPageViewModel viewModel;
        public ProcessToCheckOutPage(Models.ApartmentCheckedinInfoResponse apartment)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ProcessToCheckOutPageViewModel(this.Navigation);
            viewModel.SelectedApartmentCheckedInInfo = apartment;
            dPicker.Date = Convert.ToDateTime(apartment.CheckinDate);
        }
    }
}
