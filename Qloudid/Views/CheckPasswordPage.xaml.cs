﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckPasswordPage : ContentPage
	{
		CheckPasswordViewModel checkPasswordViewModel;
		public CheckPasswordPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = checkPasswordViewModel = new CheckPasswordViewModel(this.Navigation);
		}
	}
}