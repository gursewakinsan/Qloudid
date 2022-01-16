using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using System;
using System.Diagnostics;
using System.IO;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestPage : ContentPage
	{
		TestPageViewModel viewModel;
		public TestPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new TestPageViewModel(this.Navigation);
			step1.Focus();
			step2.IsEnabled = false;
			step3.IsEnabled = false;
			step4.IsEnabled = false;
			step5.IsEnabled = false;
			step6.IsEnabled = false;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			img.Source = ImageSource.FromUri(new Uri("https://www.qloudid.com/html/usercontent/images/dstricts/emailPic.png"));
		}

		private void step1_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length == 1)
			{
				if (string.IsNullOrEmpty(step2.Text))
				{
					step2.IsEnabled = true;
					step2.Focus();
				}
			}
		}
		private void step2_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length == 1)
			{
				if (string.IsNullOrEmpty(step3.Text))
				{
					step3.Focus();
					step3.IsEnabled = true;
				}
			}

			if (e.NewTextValue.Length == 0)
			{
				step2.OnBackspace += EntryBackspaceEventHandler2;
			}
		}
		private void step3_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length == 1)
			{
				step4.Focus();
				step4.IsEnabled = true;
			}

			if (e.NewTextValue.Length == 0)
			{
				step3.OnBackspace += EntryBackspaceEventHandler3;
			}
		}
		private void step4_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length == 1)
			{
				step5.Focus();
				step5.IsEnabled = true;
			}

			if (e.NewTextValue.Length == 0)
			{
				step4.OnBackspace += EntryBackspaceEventHandler4;
			}
		}
		private void step5_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length == 1)
			{
				step6.Focus();
				step6.IsEnabled = true;
			}

			if (e.NewTextValue.Length == 0)
			{
				step5.OnBackspace += EntryBackspaceEventHandler5;
			}
		}
		private void step6_TextChanged(object sender, TextChangedEventArgs e)
		{
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