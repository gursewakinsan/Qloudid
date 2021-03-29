using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
	public interface IEmployerService
	{
		Task<int> EmployerRequestCountAsync(Models.EmployerRequest request);
		Task<List<Models.EmployerResponse>> EmployerRequestReceivedAsync(Models.EmployerRequest request);
		Task<int> ApproveEmployerRequestAsync(Models.ApproveEmployerRequest request);
		Task<int> RejectEmployerRequestAsync(Models.RejectEmployerRequest request);
	}
}
