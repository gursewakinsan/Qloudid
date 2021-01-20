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
	}
}
