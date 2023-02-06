using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Bedroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileEnterPropertyDetailsPage : ContentPage
    {
        ProfileEnterPropertyDetailsPageViewModel viewModel;
        public ProfileEnterPropertyDetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ProfileEnterPropertyDetailsPageViewModel(this.Navigation);
        }
    }
}
