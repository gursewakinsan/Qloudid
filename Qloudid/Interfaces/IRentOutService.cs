using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
    public interface IRentOutService
    {
        Task<List<Models.TimeInfoResponse>> TimeInfoAsync();
        Task<int> UpdateArrivalAsync(Models.UpdateArrivalRequest model);
        Task<List<Models.TimeHouseRulesInfoResponse>> TimeHouseRulesInfoAsync();
        Task<int> UpdateApartmentHouseRulesAsync(Models.UpdateApartmentHouseRulesRequest model);
        Task<int> UpdateCleeningAsync(Models.UpdateCleeningRequest model);
        Task<int> UpdateSecurityAsync(Models.UpdateSecurityRequest model);
        Task<List<Models.NightlyPricingListResponse>> NightlyPricingListAsync(Models.NightlyPricingListRequest model);
        Task<int> RemovePricingGapAsync(Models.RemovePricingGapRequest model);
        Task<Models.AddPricingPeriodResponse> AddPricingPeriodAsync(Models.AddPricingPeriodRequest model);
        Task<int> AddPricingAsync(Models.AddPricingRequest model);
    }
}
