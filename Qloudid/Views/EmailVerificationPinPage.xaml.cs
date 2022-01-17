using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using Qloudid.Controls;
using System.Collections.Generic;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmailVerificationPinPage : ContentPage
	{
		EmailVerificationPinPageViewModel viewModel;
		List<Label> steps;
		public EmailVerificationPinPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new EmailVerificationPinPageViewModel(this.Navigation);
			steps = new List<Label>();
			steps.Add(step1);
			steps.Add(step2);
			steps.Add(step3);
			steps.Add(step4);
			steps.Add(step5);
			steps.Add(step6);
		}

		private void Editor_TextChanged(object sender, TextChangedEventArgs e)
		{
			var oldText = e.OldTextValue;
			var newText = e.NewTextValue;

			CustomOtpEntry editor = sender as CustomOtpEntry;

			string editorStr = editor.Text;
			//if string.length lager than max length
			if (editorStr.Length > 6)
			{
				editor.Text = editorStr.Substring(0, 6);
			}

			//dismiss keyboard
			if (editorStr.Length >= 6)
			{
				editor.Unfocus();
			}

			for (int i = 0; i < steps.Count; i++)
			{
				Label lb = steps[i];

				if (i < editorStr.Length)
				{
					lb.Text = editorStr.Substring(i, 1);
				}
				else
				{
					lb.Text = "";
				}
				OnFocused(editorStr.Length);
			}
		}

		void OnFocused(int num)
		{
			switch (num)
			{
				case 0:
					frame1.BorderColor = Color.FromHex("#6263ED");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");
					break;
				case 1:
					frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#6263ED");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");
					break;
				case 2:
					frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#6263ED");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");
					break;
				case 3:
					frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#6263ED");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");
					break;
				case 4:
					frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#6263ED");
					frame6.BorderColor = Color.FromHex("#797A7D");
					break;
				case 5:
					frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#6263ED");
					break;
				default:
					frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");
					break;
			}
		}
	}
}