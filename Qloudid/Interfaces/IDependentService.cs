using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
	public interface IDependentService
	{
		Task<List<Models.DependentResponse>> GetAllDependentAsync(Models.DependentRequest request);
	}
}
