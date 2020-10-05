using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface ILoginService
	{
		Task<int> LoginAsync(string request);
		Task<string> CheckPasswordAsync(string tokenKey, SetPassword password);
	}
}
