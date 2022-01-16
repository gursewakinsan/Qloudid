using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmailVerificationPinPage : ContentPage
	{
		EmailVerificationPinPageViewModel viewModel;
		public EmailVerificationPinPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new EmailVerificationPinPageViewModel(this.Navigation);
			step1.Focus();
			step2.IsEnabled = false;
			step3.IsEnabled = false;
			step4.IsEnabled = false;
			step5.IsEnabled = false;
			step6.IsEnabled = false;
			img.Source = ImageSource.FromUri(new Uri("https://www.qloudid.com/html/usercontent/images/dstricts/emailPic.png"));
		}

		private void step1_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length == 1)
			{
				viewModel.Password = viewModel.Password + step1.Text;
				if (string.IsNullOrEmpty(step2.Text))
				{
					step2.IsEnabled = true;
					step2.Focus();
				}
			}
			else
				viewModel.Password = viewModel.Password.Remove(viewModel.Password.Length - 1, 1);
		}
		private void step2_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length == 1)
			{
				viewModel.Password = viewModel.Password + step2.Text;
				if (string.IsNullOrEmpty(step3.Text))
				{
					step3.Focus();
					step3.IsEnabled = true;
				}
			}
			else
				viewModel.Password = viewModel.Password.Remove(viewModel.Password.Length - 1, 1);

			if (e.NewTextValue.Length == 0)
			{
				step2.OnBackspace += EntryBackspaceEventHandler2;
			}
		}
		private void step3_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length == 1)
			{
				viewModel.Password = viewModel.Password + step3.Text;
				step4.Focus();
				step4.IsEnabled = true;
			}
			else
				viewModel.Password = viewModel.Password.Remove(viewModel.Password.Length - 1, 1);

			if (e.NewTextValue.Length == 0)
			{
				step3.OnBackspace += EntryBackspaceEventHandler3;
			}
		}
		private void step4_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length == 1)
			{
				viewModel.Password = viewModel.Password + step4.Text;
				step5.Focus();
				step5.IsEnabled = true;
			}
			else
				viewModel.Password = viewModel.Password.Remove(viewModel.Password.Length - 1, 1);

			if (e.NewTextValue.Length == 0)
			{
				step4.OnBackspace += EntryBackspaceEventHandler4;
			}
		}
		private void step5_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length == 1)
			{
				viewModel.Password = viewModel.Password + step5.Text;
				step6.Focus();
				step6.IsEnabled = true;
			}
			else
				viewModel.Password = viewModel.Password.Remove(viewModel.Password.Length - 1, 1);

			if (e.NewTextValue.Length == 0)
			{
				step5.OnBackspace += EntryBackspaceEventHandler5;
			}
		}
		private void step6_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length == 1)
			{
				viewModel.Password = viewModel.Password + step6.Text;
			}
			else
				viewModel.Password = viewModel.Password.Remove(viewModel.Password.Length - 1, 1);

			if (e.NewTextValue.Length == 0)
			{
				step6.OnBackspace += EntryBackspaceEventHandler6;
			}
		}
		public void EntryBackspaceEventHandler2(object sender, EventArgs e)
		{
			step1.Focus();
			step1.Text = string.Empty;
		}
		public void EntryBackspaceEventHandler3(object sender, EventArgs e)
		{
			step2.Focus();
			step2.Text = string.Empty;
		}
		public void EntryBackspaceEventHandler4(object sender, EventArgs e)
		{
			step3.Focus();
			step3.Text = string.Empty;
		}
		public void EntryBackspaceEventHandler5(object sender, EventArgs e)
		{
			step4.Focus();
			step4.Text = string.Empty;
		}
		public void EntryBackspaceEventHandler6(object sender, EventArgs e)
		{
			step5.Focus();
			step5.Text = string.Empty;
		}
		private void step1_Focused(object sender, FocusEventArgs e)
		{
			OnFocused(1);
		}
		private void OnStepUnfocused(object sender, FocusEventArgs e)
		{
			OnFocused(0);
		}
		private void step2_Focused(object sender, FocusEventArgs e)
		{
			OnFocused(2);
		}
		private void step3_Focused(object sender, FocusEventArgs e)
		{
			OnFocused(3);
		}
		private void step4_Focused(object sender, FocusEventArgs e)
		{
			OnFocused(4);
		}
		private void step5_Focused(object sender, FocusEventArgs e)
		{
			OnFocused(5);
		}
		private void step6_Focused(object sender, FocusEventArgs e)
		{
			OnFocused(6);
		}
		void OnFocused(int num)
		{
			switch (num)
			{
				case 1:
					frame1.BorderColor = Color.FromHex("#6263ED");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");
					break;
				case 2:
					frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#6263ED");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");
					break;
				case 3:
					frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#6263ED");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");
					break;
				case 4:
					frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#6263ED");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");
					break;
				case 5:
					frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#6263ED");
					frame6.BorderColor = Color.FromHex("#797A7D");
					break;
				case 6:
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