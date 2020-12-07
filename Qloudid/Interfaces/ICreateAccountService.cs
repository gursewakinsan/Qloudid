using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface ICreateAccountService
	{
		Task<Models.CreateAccountResponse> CreateAccountAsync(Models.CreateAccount model);
		Task<Models.VerifyEmailOtpPinResponse> VerifyEmailOtpPinAsync(Models.VerifyEmailOtpPinRequest model);
		Task<Models.VerifyUserMobileResponse> VerifyUserMobileAsync(Models.VerifyUserMobileRequest model);
		Task<Models.VerifyEmailOtpPinResponse> VerifyPhoneOtpPinAsync(Models.VerifyEmailOtpPinRequest model);
		Task<int> AddIdentificatorAsync(Models.IdentificatorRequest model);
		Task<Models.GenerateCertificateResponse> GenerateCertificateAsync(Models.GenerateCertificateRequest model);
		Task<int> UploadAddIdentificatorImagesAsync(Models.AddIdentificatorImagesRequest model);
	}
}
