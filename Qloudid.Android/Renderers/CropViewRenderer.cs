using System.IO;
using Qloudid.Views;
using Xamarin.Forms;
using Android.Content;
using Android.Graphics;
using Qloudid.Droid.Renderers;
using Com.Theartofdev.Edmodo.Cropper;
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
				#region Crop Image View. 
				var cropImageView = new CropImageView(Context);
				cropImageView.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
				Bitmap bitmp = BitmapFactory.DecodeByteArray(page.Image, 0, page.Image.Length);
				cropImageView.SetImageBitmap(bitmp);
				cropImageView.RotateImage(90);
				var imageContent = new ContentView 
				{
					HeightRequest=500,
					WidthRequest=600,
					Content = cropImageView.ToView(), 
					HorizontalOptions=LayoutOptions.FillAndExpand,
					VerticalOptions=LayoutOptions.FillAndExpand
				};
				//var scrollView = new ScrollView { Content = cropImageView.ToView() };
				var stackLayout = new StackLayout { Children = { imageContent }, Spacing = 10 };
				#endregion

				#region Title & Sub Title. 
				Label labelTitle = new Label()
				{
					Text= "Crop Image",
					FontSize=25,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					TextColor=Xamarin.Forms.Color.White
				};

				string text = Helper.Helper.SelectedIdentificatorText;
				if (text == "ID") text = "ID Card";

				Label labelSubTitle = new Label()
				{
					Text = $"Use the marker to mark the area around your card. So that we only see your {text}.",
					FontSize = 20,
					HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					TextColor = Xamarin.Forms.Color.White
				};

				var titleSubTitleLayout = new StackLayout()
				{
					Children = { labelTitle, labelSubTitle },
					Spacing = 10,
					VerticalOptions = LayoutOptions.EndAndExpand,
					Padding = new Thickness(10, 10, 10, 20)
				};
				stackLayout.Children.Add(titleSubTitleLayout);
				#endregion

				#region Bottom buttons bar. 
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
				#endregion

				page.Content = stackLayout;
			}
		}
	}
}