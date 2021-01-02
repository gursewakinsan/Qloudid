namespace Qloudid.Interfaces
{
	public interface IImageResizerService
	{
		System.Threading.Tasks.Task<byte[]> ResizeImage(byte[] imageData, float width, float height);
	}
}
