using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface IDashboardService
	{
		Task<int> UpdateLoginIpAsync(string qrCode, Models.UpdateLoginIP ip);
		Task<int> VerifyPasswordAsync(string qrCode, SetPassword password);
		Task<int> ClearIpsAsync(string qrCode);
		Task<int> UpdateLoginStatusAsync(string qrCode);
		Task<int> ClearCertificateAsync(Models.ClearCertificateRequest request);
		Task<List<Models.AddressesResponse>> GetAddressesAsync(Models.AddressesRequest request);
		Task<Models.EditAddressResponse> GetAddressByIdAsync(Models.EditAddressRequest request);
		Task<int> UpdateUserAddressAsync(Models.EditAddressResponse request);
		Task<Models.EditAddressResponse> GetCompanyAddressByIdAsync(Models.EditAddressRequest request);
		Task<int> UpdateCompanyAddressAsync(Models.EditAddressResponse request);
		Task<Models.DeliveryAddressDetailResponse> DeliveryAddressDetailAsync(Models.DeliveryAddressDetailRequest request);
		Task<List<Models.InvoiceAddressResponse>> GetInvoiceAddressAsync(Models.InvoiceAddressRequest request);
		Task<Models.DeliveryAddressesResponse> GetDeliveryAddressesAsync(Models.DeliveryAddressesRequest request);
		Task<Models.CertificateExpiryInfoResponse> GetCertificateExpiryInfoAsync(Models.CertificateExpiryInfoRequest request);
		Task<int> GetUserStatusCompanyRequirementAsync(Models.GetUserStatusCompanyRequirementRequest request);
		Task<List<Models.ReceivedRequestDetailTenantsResponse>> ReceivedRequestDetailTenantsAsync(Models.ReceivedRequestDetailTenantsRequest request);
		Task<int> ApproveTenantRequestAsync(Models.ApproveTenantRequest request);
		Task<int> RejectTenantRequestAsync(Models.RejectTenantRequest request);
	}
}
