using System.Net;
using Qloudid.Helper;
using Qloudid.Interfaces;
using System.Threading.Tasks;

namespace Qloudid.Service
{
	public class CreateAccountService : ICreateAccountService
	{
		public Task<Models.CreateAccountResponse> CreateAccountAsync(Models.CreateAccount model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.CreateAccountResponse>(HttpWebRequest.Create(EndPointsList.CreateNewAccountUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.VerifyEmailOtpPinResponse> VerifyEmailOtpPinAsync(Models.VerifyEmailOtpPinRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.VerifyEmailOtpPinResponse>(HttpWebRequest.Create(EndPointsList.VerifyEmailOtpPinUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.VerifyUserMobileResponse> VerifyUserMobileAsync(Models.VerifyUserMobileRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.VerifyUserMobileResponse>(HttpWebRequest.Create(EndPointsList.VerifyUserMobileUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.VerifyEmailOtpPinResponse> VerifyPhoneOtpPinAsync(Models.VerifyEmailOtpPinRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.VerifyEmailOtpPinResponse>(HttpWebRequest.Create(EndPointsList.VerifyPhoneOtpPinUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> AddIdentificatorAsync(Models.IdentificatorRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.AddIdentificatorUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<Models.GenerateCertificateResponse> GenerateCertificateAsync(Models.GenerateCertificateRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.GenerateCertificateResponse>(HttpWebRequest.Create(EndPointsList.GenerateCertificateUrl), string.Empty, model.ToJson());
				return res;
			});
		}

		public Task<int> UploadAddIdentificatorImagesAsync(Models.AddIdentificatorImagesRequest model)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(EndPointsList.UploadAddIdentificatorImagesUrl), string.Empty, model.ToJson());
				return res;
			});
		}
	}
}
