using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
    public interface IBedroomService
    {
        Task<List<Models.BedroomDetailResponse>> BedroomDetailAsync(Models.BedroomDetailRequest model);
        Task<List<Models.UserDeliveryAddressesResponse>> UserDeliveryAddressesAsync(Models.UserDeliveryAddressesRequest model);
        Task<string> AddBedroomAsync(Models.AddBedroomRequest model);
        Task<string> DeleteBedroomAsync(Models.DeleteBedroomRequest model);
    }
}
