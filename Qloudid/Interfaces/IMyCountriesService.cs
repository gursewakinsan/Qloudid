using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
    public interface IMyCountriesService
    {
        Task<int> CheckMobileNumberAsync(Models.CheckMobileNumberRequest request);
        Task<int> VerifyOtpDetailAsync(Models.VerifyOtpDetailRequest request);
        Task<List<Models.CurrentCountryDetailResponse>> CurrentCountryDetailAsync(Models.CurrentCountryDetailRequest request);
        Task<int> UserCountrySummaryAsync(Models.UserCountrySummaryRequest request);
        Task<int> UpdateCountryAsync(Models.UpdateCountryRequest request);
        Task<int> CheckPassportInfoAsync(Models.CheckPassportInfoRequest request);
        Task<int> AddVisitingCountryAsync(Models.AddVisitingCountryRequest request);
        Task<int> AddVisitingCountryIdentificatorImagesAsync(Models.AddVisitingCountryIdentificatorImagesRequest request);
    }
}
