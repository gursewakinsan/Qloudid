using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
    public interface IMyCountriesService
    {
        Task<int> CheckMobileNumberAsync(Models.CheckMobileNumberRequest request);
        Task<int> VerifyOtpDetailAsync(Models.VerifyOtpDetailRequest request);
    }
}
