using System.Net;
using Qloudid.Interfaces;
using System.Threading.Tasks;
using Qloudid.Helper;

namespace Qloudid.Service
{
	public class LoginService : ILoginService
	{
		public Task<int> LoginAsync(string request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Get<int> (HttpWebRequest.Create(string.Format(EndPointsList.LoginUrl, request)));
				return res;
			});
		}

		public Task<Models.User> CheckPasswordAsync(string tokenKey, SetPassword password)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.User>(HttpWebRequest.Create(string.Format(EndPointsList.CheckPasswordUrl, tokenKey)), string.Empty, password.ToJson());
				return res;
			});
		}

		public Task<Models.CheckValidQrResponse> CheckValidQrAsync(string qrCode)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Get<Models.CheckValidQrResponse>(HttpWebRequest.Create(string.Format(EndPointsList.CheckQrValidityUrl, qrCode)));
				return res;
			});
		}

		public Task<Models.VerifyUserConsentResponse> VerifyUserConsentAsync(Models.VerifyUserConsentRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.VerifyUserConsentResponse>(HttpWebRequest.Create(EndPointsList.VerifyUserConsentUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<string> ClearLoginAsync(string qrCode)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Get<string>(HttpWebRequest.Create(string.Format(EndPointsList.ClearLoginUrl, qrCode)));
				return res;
			});
		}

		public Task<Models.PurchaseDetailResponse> GetPurchaseDetailAsync(Models.PurchaseDetailRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.PurchaseDetailResponse>(HttpWebRequest.Create(EndPointsList.GetPurchaseDetailUrl), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.UserDetailResponse> GetUserDetailAsync(Models.UserDetailRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.UserDetailResponse>(HttpWebRequest.Create(EndPointsList.UserDetailsUrl), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
