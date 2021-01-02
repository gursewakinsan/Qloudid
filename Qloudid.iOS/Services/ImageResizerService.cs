using UIKit;
using System;
using CoreGraphics;
using System.Drawing;
using Xamarin.Forms;
using Qloudid.Interfaces;
using System.Threading.Tasks;

[assembly: Dependency(typeof(Qloudid.iOS.Services.ImageResizerService))]
namespace Qloudid.iOS.Services
{
	public class ImageResizerService : IImageResizerService
	{
		public async Task<byte[]> ResizeImage(byte[] imageData, float width, float height)
		{
			return ResizeImageIOS(imageData, width, height);
		}

		public static byte[] ResizeImageIOS(byte[] imageData, float width, float height)
		{
			UIImage originalImage = ImageFromByteArray(imageData);
			UIImageOrientation orientation = originalImage.Orientation;

			//create a 24bit RGB image
			using (CGBitmapContext context = new CGBitmapContext(IntPtr.Zero,
												 (int)width, (int)height, 8,
												 4 * (int)width, CGColorSpace.CreateDeviceRGB(),
												 CGImageAlphaInfo.PremultipliedFirst))
			{

				RectangleF imageRect = new RectangleF(0, 0, width, height);

				// draw the image
				context.DrawImage(imageRect, originalImage.CGImage);

				UIKit.UIImage resizedImage = UIKit.UIImage.FromImage(context.ToImage(), 0, orientation);

				// save the image as a jpeg
				return resizedImage.AsJPEG().ToArray();
			}
		}

		public static UIKit.UIImage ImageFromByteArray(byte[] data)
		{
			if (data == null)
			{
				return null;
			}

			UIKit.UIImage image;
			try
			{
				image = new UIKit.UIImage(Foundation.NSData.FromArray(data));
			}
			catch (Exception e)
			{
				Console.WriteLine("Image load failed: " + e.Message);
				return null;
			}
			return image;
		}
	}
}