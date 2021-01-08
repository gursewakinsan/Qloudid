using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;

namespace Qloudid.Service
{
	public class AccountRestoreService : IAccountRestoreService
	{
		public Task<Models.RestoreAccountResponse> RestoreAccountAsync(Models.RestoreAccountRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.RestoreAccountResponse>(HttpWebRequest.Create(EndPointsList.RestoreAccountUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.VerifyRestoreOtpPinResponse> VerifyRestoreOtpPinAsync(Models.VerifyRestoreOtpPinRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				//var res = RestClient.Post<Models.VerifyRestoreOtpPinResponse>(HttpWebRequest.Create(EndPointsList.VerifyRestoreOtpPinUrl), string.Empty, model.ToJson());
				var res = RestClient.Post<Models.VerifyRestoreOtpPinResponse>(HttpWebRequest.Create(EndPointsList.VerifyRestoreOtpPinWithMobileUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}
