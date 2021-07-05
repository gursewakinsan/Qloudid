using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
	public interface IPickupService
	{
		Task<List<Models.PickupAddressDetailResponse>> PickupAddressDetailAsync(Models.PickupAddressDetailRequest request);
		Task<int> UpdatePickupDeliveryAsync(Models.UpdatePickupDeliveryRequest request);
		Task<int> UpdatePickupAddressAsync(Models.UpdatePickupAddressRequest request);
	}
}