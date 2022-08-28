﻿using System.Threading.Tasks;
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

        //Bathroom
        Task<List<Models.BathroomDetailResponse>> BathroomDetailAsync(Models.BathroomDetailRequest model);
        Task<string> AddBathroomAsync(Models.AddBathroomRequest model);
        Task<string> DeleteBathroomAsync(Models.DeleteBathroomRequest model);
        Task<string> UpdateBathroomAsync(Models.UpdateBathroomRequest model);
        Task<string> UpdateAccessibilityAsync(Models.UpdateAccessibilityRequest model);
        Task<string> UpdateOverbathAsync(Models.UpdateOverbathRequest model);
    }
}