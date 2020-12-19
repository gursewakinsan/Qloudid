using System;
using CoreGraphics;
using Qloudid.Interfaces;
using Qloudid.iOS.Services;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(PhotoOverlay_iOS))]
namespace Qloudid.iOS.Services
{
    public class PhotoOverlay_iOS : IPhotoOverlay
    {

        public PhotoOverlay_iOS()
        {
        }

        public object GetImageOverlay()
        {


            /* var layout = new UIView(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height));
             layout.BackgroundColor = UIColor.FromRGBA(20, 20, 20, (nfloat)0.8);


             var label = new UILabel();
             label.TextColor = UIColor.White;
             label.Text = "This is test";
             label.MinimumFontSize = 50;
             label.TextAlignment = UITextAlignment.Center;
             layout.Add(label);


             return layout;*/

            /*UIView uIView = new UIView();
            uIView.BackgroundColor = UIColor.Yellow;
            var imageView = new UIImageView(UIImage.FromBundle("iconForOnCamera.png"));
            imageView.ContentMode = UIViewContentMode.Top;//.ScaleAspectFit;
            imageView.BackgroundColor = UIColor.Green;
            
            var screen = UIScreen.MainScreen.Bounds;
            imageView.Frame = new CGRect(screen.X, screen.Y, screen.Width+200, screen.Height - 500);
            uIView.Frame = screen;
            uIView.Add(imageView);

            return uIView;*/


            /*var screen = UIScreen.MainScreen.Bounds;
            UIView view = new UIView(new CGRect(screen.X, screen.Y-50, screen.Width, screen.Height - 100));
            view.BackgroundColor = UIColor.Red;
            view.ContentMode = UIViewContentMode.Center;
            return view;*/

            var imageView = new UIImageView(UIImage.FromBundle("iconcameraframewithtext1png.png"));
            imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            //imageView.BackgroundColor = UIColor.Green;

            var screen = UIScreen.MainScreen.Bounds;
            imageView.Frame = screen; //new CGRect(screen.X, screen.Y, screen.Width - 50, screen.Height - 50);
            return imageView;
            //uIView.Frame = screen;
        }

    }
}
