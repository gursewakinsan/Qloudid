using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface IAccountRestoreService
	{
		Task<Models.RestoreAccountResponse> RestoreAccountAsync(Models.RestoreAccountRequest model);
		Task<Models.VerifyRestoreOtpPinResponse> VerifyRestoreOtpPinAsync(Models.VerifyRestoreOtpPinRequest model);
	}
}
