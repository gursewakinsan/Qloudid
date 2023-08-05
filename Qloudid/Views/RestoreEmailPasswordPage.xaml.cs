using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Qloudid.ViewModels;
using Qloudid.Controls;
using System.Collections.Generic;

namespace Qloudid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestoreEmailPasswordPage : ContentPage
	{
		RestoreEmailPasswordPageViewModel viewModel;
		List<Label> steps;
		public RestoreEmailPasswordPage()
		{
			InitializeComponent();
			steps = new List<Label>();
			steps.Add(step1);
			steps.Add(step2);
			steps.Add(step3);
			steps.Add(step4);
			steps.Add(step5);
			steps.Add(step6);
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new RestoreEmailPasswordPageViewModel(this.Navigation);
		}

		private void Editor_TextChanged(object sender, TextChangedEventArgs e)
		{
			var oldText = e.OldTextValue;
			var newText = e.NewTextValue;

			CustomOtpEntry editor = sender as CustomOtpEntry;

			string editorStr = editor.Text;
			if (editorStr.Length > 6)
			{
				editor.Text = editorStr.Substring(0, 6);
			}

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
					/*frame1.BorderColor = Color.FromHex("#6263ED");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");*/

					frame1.BackgroundColor = Color.Transparent;
					frame2.BackgroundColor = Color.Transparent;
					frame3.BackgroundColor = Color.Transparent;
					frame4.BackgroundColor = Color.Transparent;
					frame5.BackgroundColor = Color.Transparent;
					frame6.BackgroundColor = Color.Transparent;

					step1.Text = "|";
					step1.TextColor = Color.FromHex("#EF793F");

					break;
				case 1:
					frame1.BackgroundColor = Color.FromHex("#242A37");
					frame2.BackgroundColor = Color.Transparent;
					frame3.BackgroundColor = Color.Transparent;
					frame4.BackgroundColor = Color.Transparent;
					frame5.BackgroundColor = Color.Transparent;
					frame6.BackgroundColor = Color.Transparent;

					step1.TextColor = Color.White;
					step2.Text = "|";
					step2.TextColor = Color.FromHex("#EF793F");

					/*frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#6263ED");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");*/
					break;
				case 2:
					frame1.BackgroundColor = Color.FromHex("#242A37");
					frame2.BackgroundColor = Color.FromHex("#242A37");
					frame3.BackgroundColor = Color.Transparent;
					frame4.BackgroundColor = Color.Transparent;
					frame5.BackgroundColor = Color.Transparent;
					frame6.BackgroundColor = Color.Transparent;

					step1.TextColor = Color.White;
					step2.TextColor = Color.White;
					step3.Text = "|";
					step3.TextColor = Color.FromHex("#EF793F");

					/*frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#6263ED");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");*/
					break;
				case 3:
					frame1.BackgroundColor = Color.FromHex("#242A37");
					frame2.BackgroundColor = Color.FromHex("#242A37");
					frame3.BackgroundColor = Color.FromHex("#242A37");
					frame4.BackgroundColor = Color.Transparent;
					frame5.BackgroundColor = Color.Transparent;
					frame6.BackgroundColor = Color.Transparent;

					step1.TextColor = Color.White;
					step2.TextColor = Color.White;
					step3.TextColor = Color.White;
					step4.Text = "|";
					step4.TextColor = Color.FromHex("#EF793F");

					/*frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#6263ED");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");*/
					break;
				case 4:
					frame1.BackgroundColor = Color.FromHex("#242A37");
					frame2.BackgroundColor = Color.FromHex("#242A37");
					frame3.BackgroundColor = Color.FromHex("#242A37");
					frame4.BackgroundColor = Color.FromHex("#242A37");
					frame5.BackgroundColor = Color.Transparent;
					frame6.BackgroundColor = Color.Transparent;

					step1.TextColor = Color.White;
					step2.TextColor = Color.White;
					step3.TextColor = Color.White;
					step4.TextColor = Color.White;
					step5.Text = "|";
					step5.TextColor = Color.FromHex("#EF793F");

					/*frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#6263ED");
					frame6.BorderColor = Color.FromHex("#797A7D");*/
					break;
				case 5:
					frame1.BackgroundColor = Color.FromHex("#242A37");
					frame2.BackgroundColor = Color.FromHex("#242A37");
					frame3.BackgroundColor = Color.FromHex("#242A37");
					frame4.BackgroundColor = Color.FromHex("#242A37");
					frame5.BackgroundColor = Color.FromHex("#242A37");
					frame6.BackgroundColor = Color.Transparent;

					step1.TextColor = Color.White;
					step2.TextColor = Color.White;
					step3.TextColor = Color.White;
					step4.TextColor = Color.White;
					step5.TextColor = Color.White;
					step6.Text = "|";
					step6.TextColor = Color.FromHex("#EF793F");

					/*frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#6263ED");*/
					break;
				default:
					frame1.BackgroundColor = Color.FromHex("#242A37");
					frame2.BackgroundColor = Color.FromHex("#242A37");
					frame3.BackgroundColor = Color.FromHex("#242A37");
					frame4.BackgroundColor = Color.FromHex("#242A37");
					frame5.BackgroundColor = Color.FromHex("#242A37");
					frame6.BackgroundColor = Color.FromHex("#242A37");

					step1.TextColor = Color.White;
					step2.TextColor = Color.White;
					step3.TextColor = Color.White;
					step4.TextColor = Color.White;
					step5.TextColor = Color.White;
					step6.TextColor = Color.White;

					/*frame1.BorderColor = Color.FromHex("#797A7D");
					frame2.BorderColor = Color.FromHex("#797A7D");
					frame3.BorderColor = Color.FromHex("#797A7D");
					frame4.BorderColor = Color.FromHex("#797A7D");
					frame5.BorderColor = Color.FromHex("#797A7D");
					frame6.BorderColor = Color.FromHex("#797A7D");*/
					break;
			}
		}
	}
}