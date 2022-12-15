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
    }
}
