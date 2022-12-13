using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
    public interface IRentOutService
    {
        Task<List<Models.TimeInfoResponse>> TimeInfoAsync();
    }
}
