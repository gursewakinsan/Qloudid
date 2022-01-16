using UIKit;
using System;
using Xamarin.Forms;
using Qloudid.Controls;
using Qloudid.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomOtpEntry), typeof(CustomOtpEntryRenderer))]
namespace Qloudid.iOS.Renderers
{
	public class CustomOtpEntryRenderer : EntryRenderer, IUITextFieldDelegate
	{
		IElementController ElementController => Element as IElementController;
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			if (Element == null)
				return;

			if (Control != null)
				Control.BorderStyle = UITextBorderStyle.None;

			var entry = (CustomOtpEntry)Element;
			var textField = new UIBackwardsTextField();

			textField.EditingChanged += OnEditingChanged;
			textField.OnDeleteBackward += (sender, a) =>
			{
				entry.OnBackspacePressed();
			};
			SetNativeControl(textField);
			base.OnElementChanged(e);
		}

		void OnEditingChanged(object sender, EventArgs eventArgs)
		{
			ElementController.SetValueFromRenderer(Entry.TextProperty, Control.Text);
		}
	}

	public class UIBackwardsTextField : UITextField
	{
		public delegate void DeleteBackwardEventHandler(object sender, EventArgs e);

		public event DeleteBackwardEventHandler OnDeleteBackward;
		public void OnDeleteBackwardPressed()
		{
			if (OnDeleteBackward != null)
				OnDeleteBackward(null, null);
		}

		public UIBackwardsTextField()
		{
			BorderStyle = UITextBorderStyle.RoundedRect;
			ClipsToBounds = true;
		}

		public override void DeleteBackward()
		{
			base.DeleteBackward();
			OnDeleteBackwardPressed();
		}
	}
}