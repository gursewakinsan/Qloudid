using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
    public interface IRepairService
    {
        Task<List<Models.UserApartmentTicketListResponse>> UserApartmentTicketListAsync(Models.UserApartmentTicketListRequest model);
    }
}
