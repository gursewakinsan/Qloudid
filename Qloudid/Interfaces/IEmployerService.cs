using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
	public interface IEmployerService
	{
		Task<int> EmployerRequestCountAsync(Models.EmployerRequest request);
		Task<List<Models.EmployerResponse>> EmployerRequestReceivedAsync(Models.EmployerRequest request);
		Task<Models.ApproveEmployerResponse> ApproveEmployerRequestAsync(Models.ApproveEmployerRequest request);
		Task<Models.RejectEmployerResponse> RejectEmployerRequestAsync(Models.RejectEmployerRequest request);
	}
}
