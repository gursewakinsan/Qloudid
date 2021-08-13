using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface ILoginService
	{
		Task<int> LoginAsync(string request);
		Task<Models.User> CheckPasswordAsync(string tokenKey, SetPassword password);
		Task<Models.CheckValidQrResponse> CheckValidQrAsync(string qrCode);
		Task<Models.VerifyUserConsentResponse> VerifyUserConsentAsync(Models.VerifyUserConsentRequest request);
		Task<string> ClearLoginAsync(string qrCode);
		Task<Models.PurchaseDetailResponse> GetPurchaseDetailAsync(Models.PurchaseDetailRequest request);
		Task<Models.UserDetailResponse> GetUserDetailAsync(Models.UserDetailRequest request);
	}
}
