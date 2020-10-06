﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerifyPasswordPage : ContentPage
	{
		VerifyPasswordPageViewModel viewModel;
		public VerifyPasswordPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VerifyPasswordPageViewModel(this.Navigation);
		}
	}
}