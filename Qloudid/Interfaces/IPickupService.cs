using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
	public interface IPickupService
	{
		Task<List<Models.PickupAddressDetailResponse>> PickupAddressDetailAsync(Models.PickupAddressDetailRequest request);
		Task<Models.UpdatePickupDeliveryResponse> UpdatePickupDeliveryAsync(Models.UpdatePickupDeliveryRequest request);
		Task<Models.UpdatePickupAddressResponse> UpdatePickupAddressAsync(Models.UpdatePickupAddressRequest request);
	}
}