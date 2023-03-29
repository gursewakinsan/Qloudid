using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
    public interface IRepairService
    {
        Task<List<Models.UserApartmentTicketListResponse>> UserApartmentTicketListAsync(Models.UserApartmentTicketListRequest model);
        Task<List<Models.UserApartmentProblemDetailResponse>> UserApartmentProblemDetailAsync(Models.UserApartmentProblemDetailRequest model);
        Task<List<Models.GetTicketSubTitleInfoResponse>> GetTicketSubTitleInfoAsync(Models.GetTicketSubTitleInfoRequest model);
        Task<int> CreateUserApartmentTicketAsync(Models.CreateUserApartmentTicketRequest model);
        Task<string> AddUserApartmentTicketImageAsync(Models.AddUserApartmentTicketImageRequest model);
    }
}
