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

		public Task<int> CheckValidQrAsync(string qrCode)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Get<int>(HttpWebRequest.Create(string.Format(EndPointsList.CheckQrValidityUrl, qrCode)));
				return res;
			});
		}
	}
}
