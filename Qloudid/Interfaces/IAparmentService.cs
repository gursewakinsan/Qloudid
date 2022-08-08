using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
    public interface IAparmentService
    {
        Task<string> CheckinAparmentOwnerAsync(Models.CheckinAparmentOwnerRequest model);
    }
}
