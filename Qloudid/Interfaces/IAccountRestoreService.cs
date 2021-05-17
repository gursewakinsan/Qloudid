using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
	public interface IAccountRestoreService
	{
		Task<Models.RestoreAccountResponse> RestoreAccountAsync(Models.RestoreAccountRequest model);
		Task<Models.VerifyRestoreOtpPinResponse> VerifyRestoreOtpPinAsync(Models.VerifyRestoreOtpPinRequest model);
		Task<int> UpdatePayRequiredAsync(Models.UpdatePayRequiredRequest model);
		Task<int> UpdateCheckRequiredAsync(Models.UpdateCheckRequiredRequest model);
		Task<List<Models.IdentificatorDetailResponse>> IdentificatorDetailAsync(Models.IdentificatorDetailRequest model);
	}
}
