using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
	public interface IDependentService
	{
		Task<List<Models.DependentResponse>> GetAllDependentAsync(Models.DependentRequest request);
		Task<int> CheckSsnAsync(Models.AddDependentRequest request);
		Task<int> AddDependentAsync(Models.AddDependentRequest request);
		Task<int> AddDependentImagesAsync(Models.AddDependentImagesRequest request);
		Task<int> VerifyUserBookingExistsAsync(Models.CheckInDependentRequest request);
		Task<int> UpdateDependentCheckinIdsAsync(Models.UpdateDependentCheckinIdsRequest request);
		Task<List<Models.DependentResponse>> DependentsListForCheckInAsync(Models.DependentsListForCheckInRequest request);
		Task<int> GuestChildrenRemainingCountAsync(Models.GuestChildrenRemainingCountRequest request);
	}
}
