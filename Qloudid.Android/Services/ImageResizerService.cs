using System.IO;
using Xamarin.Forms;
using Android.Graphics;
using Qloudid.Interfaces;
using System.Threading.Tasks;

[assembly: Dependency(typeof(Qloudid.Droid.Services.ImageResizerService))]
namespace Qloudid.Droid.Services
{
	public class ImageResizerService : IImageResizerService
	{
		public async Task<byte[]> ResizeImage(byte[] imageData, float width, float height)
		{
			return ResizeImageAndroid(imageData, width, height);
		}

		public static byte[] ResizeImageAndroid(byte[] imageData, float width, float height)
		{
			// Load the bitmap
			Bitmap originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
			Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, false);

			using (MemoryStream ms = new MemoryStream())
			{
				resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
				return ms.ToArray();
			}
		}
	}
}