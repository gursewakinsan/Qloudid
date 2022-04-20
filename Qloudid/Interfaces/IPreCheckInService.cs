using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface IPreCheckInService
	{
		Task<Models.GetPreCheckinStatusResponse> GetPreCheckinStatusAsync(Models.GetPreCheckinStatusRequest request);
		Task<Models.GetUserActiveStatusResponse> GetUserActiveStatusAsync(Models.GetUserActiveStatusRequest request);
		Task<int> UpdatePreCheckinStatusAsync(Models.UpdatePreCheckinStatusRequest request);
	}
}