using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
	public interface IDependentService
	{
		Task<List<Models.DependentResponse>> GetAllDependentAsync(Models.DependentRequest request);
		Task<int> CheckSsnAsync(Models.CheckSsnRequest request);
		Task<int> CheckDependentSsnAsync(Models.CheckDependentSsnRequest request);
		Task<int> AddDependentAsync(Models.AddDependentRequest request);
		Task<int> UpdateDependentAsync(Models.UpdateDependentRequest request);
		Task<int> AddDependentProfileImagesAsync(Models.AddDependentProfileImagesRequest request);
		Task<int> AddDependentImagesAsync(Models.AddDependentImagesRequest request);
		Task<int> AddDependentPassportAsync(Models.AddDependentPassportRequest request);
		Task<int> CheckPassportAsync(Models.CheckPassportRequest request);
		Task<int> VerifyUserBookingExistsAsync(Models.CheckInDependentRequest request);
		Task<int> UpdateDependentCheckinIdsAsync(Models.UpdateDependentCheckinIdsRequest request);
		Task<List<Models.DependentResponse>> DependentsListForCheckInAsync(Models.DependentsListForCheckInRequest request);
		Task<int> GuestChildrenRemainingCountAsync(Models.GuestChildrenRemainingCountRequest request);
		Task<Models.DependentDetailResponse> DependentDetailAsync(Models.DependentDetailRequest request);
	}
}
