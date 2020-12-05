using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface ICreateAccountService
	{
		Task<Models.CreateAccountResponse> CreateAccountAsync(Models.CreateAccount model);
		Task<Models.VerifyEmailOtpPinResponse> VerifyEmailOtpPinAsync(Models.VerifyEmailOtpPinRequest model);
		Task<string> VerifyUserMobileAsync(Models.VerifyUserMobileRequest model);
	}
}
