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
        Task<string> AddBedToBedroomAsync(Models.AddBedToBedroomRequest model);
        Task<string> DeleteBedroomBedInfoAsync(Models.DeleteBedroomBedInfoRequest model);
        Task<List<Models.BedType>> BedroomBedDetailAsync(Models.BedroomBedDetailRequest model);
        Task<List<Models.BedTypeDetail>> BedTypeDetailAsync();
        Task<string> UpdateBedTypeInfoAsync(Models.UpdateBedTypeInfoRequest model);
        Task<int> UpdateApartmentWifiAsync(Models.UpdateApartmentWifiRequest model);
        Task<Models.OtherRoomInfoResponse> OtherRoomInfoAsync(Models.OtherRoomInfoRequest model);
        Task<int> UpdateOtherRoomInfoAsync(Models.UpdateOtherRoomInfoRequest model);
        Task<List<Models.PropertyTypeResponse>> PropertyTypeAsync();
        Task<List<Models.FloorsInfoResponse>> FloorsInfoAsync(Models.FloorsInfoRequest model);
        Task<int> UpdatePropertyCompositionAsync(Models.UpdatePropertyCompositionRequest model);
        Task<string> UpdatePropertyStartAsync(Models.UpdatePropertyStartRequest model);
        Task<List<Models.HomeRepairCategoryInfoResponse>> HomeRepairCategoryInfoAsync(Models.HomeRepairCategoryInfoRequest model);
        Task<List<Models.AmenitiesSubcategoryDetailResponse>> AmenitiesSubcategoryDetailAsync(Models.AmenitiesSubcategoryDetailRequest model);

        //Bathroom
        Task<List<Models.BathroomDetailResponse>> BathroomDetailAsync(Models.BathroomDetailRequest model);
        Task<string> AddBathroomAsync(Models.AddBathroomRequest model);
        Task<string> DeleteBathroomAsync(Models.DeleteBathroomRequest model);
        Task<string> UpdateBathroomAsync(Models.UpdateBathroomRequest model);
        Task<string> UpdateAccessibilityAsync(Models.UpdateAccessibilityRequest model);
        Task<string> UpdateOverbathAsync(Models.UpdateOverbathRequest model);
        Task<string> UpdateOwnerInfoAsync(Models.UpdateOwnerInfoRequest model);
    }
}
