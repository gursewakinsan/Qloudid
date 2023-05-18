using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
    public interface IPropertyService
    {
        Task<List<Models.CompanyListSearchResponse>> CompanyListSearchAsync(Models.CompanyListSearchRequest model);
        Task<List<Models.UserPropertyResponse>> UserPropertyAsync(Models.UserPropertyRequest model);
        Task<string> AddLandloardAsync(Models.AddLandloardRequest model);
    }
}