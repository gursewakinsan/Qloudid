using UIKit;
using System;
using Foundation;
using Xamarin.Forms;
using Qloudid.Views;
using System.Diagnostics;
using Qloudid.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using Xam.Plugins.ImageCropper.iOS;
using System.Drawing;

[assembly: ExportRenderer(typeof(CropView), typeof(CropViewRenderer))]
namespace Qloudid.iOS.Renderers
{
	public class CropViewRenderer : PageRenderer
	{
		CropViewDelegate selector;
		byte[] Image;
		bool IsShown;
		public bool DidCrop;
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var page = base.Element as CropView;
			Image = page.Image;
			DidCrop = page.DidCrop;
		}

		/*protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			var page = e.NewElement as CropView;
			var view = NativeView;

			var label = new UILabel(new RectangleF(20, 40, 40, 40));
			label.AdjustsFontSizeToFitWidth = true;
			label.TextColor = UIColor.White;
			if (page != null)
			{
				label.Text = "this is test"; 
			}

			view.Add(label);
		}
		*/

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			try
			{
				if (!IsShown)
				{
					IsShown = true;
					UIImage image = new UIImage(NSData.FromArray(Image));
					Image = null;
					selector = new CropViewDelegate(this);

					TOCropViewController picker = new TOCropViewController(TOCropViewCroppingStyle.Default, image);
					// Demo for Circular Cropped Image
					//TOCropViewController picker = new TOCropViewController(TOCropViewCroppingStyle.Circular, image);
					//picker.AspectRatioLockEnabled = false;

					picker.ChildViewControllerForStatusBarHidden();

					picker.AspectRatioPickerButtonHidden = true;
					picker.RotateButtonsHidden = true;
					picker.RotateClockwiseButtonHidden = true;
					picker.AspectRatioLockEnabled = true;
					picker.ResetAspectRatioEnabled = false;




					//picker.AspectRatioPreset = TOCropViewControllerAspectRatioPreset.Original;

					picker.Delegate = selector;
					//picker.DidRotate(UIInterfaceOrientation.LandscapeRight);
					//picker.ImageCropFrame = new CoreGraphics.CGRect(picker.ImageCropFrame.X, picker.ImageCropFrame.Y, picker.ImageCropFrame.Width, picker.ImageCropFrame.Height - 400);

					//picker.Title = "this is test";
					//picker.CropView.
					//var size = picker.CropView.Bounds;
					//picker.ImageCropFrame = new CoreGraphics.CGRect(size.X, size.Y, size.Width, size.Height - 200);
					//picker.CropView.LargeContentTitle = "sljakskljslaJSLAJSLA";
					//Title = "hakhdsdl";

					/*UILabel label = new UILabel();
					label.Frame = new CoreGraphics.CGRect(0, 0, 150, 150);
					label.Text = "helloooo";
					label.TextColor = UIColor.Yellow;
					UIView view = new UIView();
					view.BackgroundColor = UIColor.Orange;
					view.ContentMode = UIViewContentMode.Bottom;
					view.Add(label);*/
					//picker.Add(view);

					//UINavigationController nav = new UINavigationController(picker);
					//nav.Title = "djflkdjlfkdlkf";
					//nav.colo
					//nav.ModalPresentationStyle = UIModalPresentationStyle.Popover;//.BlurOverFullScreen;//.Automatic;//.PageSheet; // Whichever you prefer
					//nav.NavigationBar.Frame = new CoreGraphics.CGRect(100, 100, 100, 100);
					//nav.NavigationBar.BackgroundColor = UIColor.Red;
					//nav.NavigationBar.BarTintColor = UIColor.Yellow;
					picker.ModalPresentationStyle = UIModalPresentationStyle.Popover;
					//picker.PreferredStatusBarStyle();


					//picker.View = view;

					//picker.Toolbar = new TOCropToolbar();
					PresentViewController(picker, true, null);
					//UILabel label = picker.TitleLabel;
					var size = picker.CropView.Bounds;

					//Heading.
					UILabel labelHeading = new UILabel();
					labelHeading.Frame = new CoreGraphics.CGRect(size.X, size.Height - 210, size.Width, 75);
					labelHeading.Text = "Crop Image";
					labelHeading.Font = UIFont.SystemFontOfSize(30);
					labelHeading.TextAlignment = UITextAlignment.Center;
					labelHeading.TextColor = UIColor.White;

					//Sub Heading.
					string text = Helper.Helper.SelectedIdentificatorText;
					if (text == "ID") text = "ID Card";
					//text = "ID Card";
					UILabel labelSubHeading = new UILabel();
					labelSubHeading.Frame = new CoreGraphics.CGRect(size.X, size.Height - 200, size.Width, 170);
					labelSubHeading.Text = $"Use the marker to mark the area around your card. So that we only see your {text}.";
					labelSubHeading.Font = UIFont.SystemFontOfSize(20);
					labelSubHeading.TextAlignment = UITextAlignment.Center;
					labelSubHeading.TextColor = UIColor.White;
					labelSubHeading.Lines = 3;
					labelSubHeading.LineBreakMode = UILineBreakMode.WordWrap;


					UIView view = new UIView();
					view.Frame = new CoreGraphics.CGRect(size.X, size.Y, size.Width, 150);
					view.ContentMode = UIViewContentMode.Bottom;
					view.Add(labelHeading);
					view.Add(labelSubHeading);

					//picker.Title = "this is demo";

					picker.Add(view);
					//PresentViewController(picker, true, null);
					//picker.CropView.AddSubview(view);
					picker.CustomAspectRatio = new CoreGraphics.CGSize(600, 400);
					picker.ModalPresentationStyle = UIModalPresentationStyle.Custom;

				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			try
			{
				var page = base.Element as CropView;
				page.DidCrop = selector.DidCrop;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
	}

	public class CropViewDelegate : TOCropViewControllerDelegate
	{
		readonly UIViewController parent;
		public bool DidCrop;
		public CropViewDelegate(UIViewController parent)
		{
			parent.Title = "hello all iam title";

			this.parent = parent;
		}

		public override void DidCropToImage(TOCropViewController cropViewController, UIImage image, CoreGraphics.CGRect cropRect, nint angle)
		{
			DidCrop = true;
			try
			{
				if (image != null)
					App.CroppedImage = image.AsPNG().ToArray();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			finally
			{
				if (image != null)
				{
					image.Dispose();
					image = null;
				}
			}
			parent.DismissViewController(true, () => { App.Current.MainPage.Navigation.PopModalAsync(); });
		}

		public override void DidFinishCancelled(TOCropViewController cropViewController, bool cancelled)
		{
			parent.DismissViewController(true, () => { App.Current.MainPage.Navigation.PopModalAsync(); });
		}
	}
}