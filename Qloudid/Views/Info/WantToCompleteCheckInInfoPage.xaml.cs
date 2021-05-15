﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views.Info
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WantToCompleteCheckInInfoPage : ContentPage
	{
		WantToCompleteCheckInInfoPageViewModel viewModel;
		public WantToCompleteCheckInInfoPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WantToCompleteCheckInInfoPageViewModel(this.Navigation);
		}
	}
}