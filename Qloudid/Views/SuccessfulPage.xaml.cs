﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SuccessfulPage : ContentPage
	{
		SuccessfulPageViewModel viewModel;
		public SuccessfulPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SuccessfulPageViewModel(this.Navigation);
		}
	}
}