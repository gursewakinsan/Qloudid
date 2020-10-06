using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface ILoginService
	{
		Task<int> LoginAsync(string request);
		Task<Models.User> CheckPasswordAsync(string tokenKey, SetPassword password);
		Task<int> CheckValidQrAsync(string qrCode);
	}
}
