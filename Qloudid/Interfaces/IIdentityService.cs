using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
    public interface IIdentityService
    {
        Task<Models.IdentificatorCountDetailResponse> IdentificatorCountDetailAsync(Models.IdentificatorCountDetailRequest model);
        Task<List<Models.IdentificatorListResponse>> IdentificatorListAsync(Models.IdentificatorListRequest model);
    }
}
