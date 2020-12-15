using System;
using System.IO;
using Android.Content;
using Android.Graphics;
using Com.Theartofdev.Edmodo.Cropper;
using Qloudid.Droid.Renderers;
using Qloudid.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CropView), typeof(CropViewRenderer))]
namespace Qloudid.Droid.Renderers
{
	public class CropViewRenderer : PageRenderer
	{
		public CropViewRenderer(Context context) : base(context)
		{
		}
		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);
			var page = Element as CropView;
			if (page != null)
			{
				var cropImageView = new CropImageView(Context);
				cropImageView.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
				Bitmap bitmp = BitmapFactory.DecodeByteArray(page.Image, 0, page.Image.Length);
				cropImageView.SetImageBitmap(bitmp);

				var imageContent = new ContentView 
				{
					Content = cropImageView.ToView(), 
					HorizontalOptions=LayoutOptions.FillAndExpand,
					VerticalOptions=LayoutOptions.CenterAndExpand
				};
				//var scrollView = new ScrollView { Content = cropImageView.ToView() };
				var stackLayout = new StackLayout { Children = { imageContent }, Spacing = 0 };

				var stackLayoutButtons = new StackLayout
				{
					Orientation = StackOrientation.Horizontal,
					HeightRequest = 50,
					Spacing = 40, Margin=new Thickness(0,0,0,20),
					VerticalOptions = LayoutOptions.EndAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				};
				var closeButton = new ImageButton 
				{
					Source = "iconClose.png",
					Padding = new Thickness(15),
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					BackgroundColor = Xamarin.Forms.Color.Transparent
				};
				closeButton.Clicked += (sender, ex) =>
				{
					page.Navigation.PopModalAsync();
				};
				stackLayoutButtons.Children.Add(closeButton);

				var rotateButton = new ImageButton
				{
					Source= "iconRotateToRight.png",
					Padding = new Thickness(12),
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					BackgroundColor = Xamarin.Forms.Color.Transparent
				};

				rotateButton.Clicked += (sender, ex) =>
				{
					cropImageView.RotateImage(90);
				};
				stackLayoutButtons.Children.Add(rotateButton);

				var finishButton = new ImageButton 
				{ 
					Source = "iconChecked.png" ,
					Padding = new Thickness(12),
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					BackgroundColor = Xamarin.Forms.Color.Transparent
				};
				finishButton.Clicked += (sender, ex) =>
				{
					Bitmap cropped = cropImageView.CroppedImage;
					using (MemoryStream memory = new MemoryStream())
					{
						cropped.Compress(Bitmap.CompressFormat.Png, 100, memory);
						App.CroppedImage = memory.ToArray();
					}
					page.DidCrop = true;
					page.Navigation.PopModalAsync();
				};

				stackLayoutButtons.Children.Add(finishButton);
				stackLayout.Children.Add(stackLayoutButtons);
				page.Content = stackLayout;
			}
		}
	}
}