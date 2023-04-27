using Qloudid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Qloudid.Views.TestPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage2 : ContentPage
    {
        public TestPage2()
        {
            InitializeComponent();
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindableLayout.SetItemsSource(layout, new int[4]);
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TestPage3());
        }
    }
}