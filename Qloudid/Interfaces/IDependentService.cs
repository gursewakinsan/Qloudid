using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qloudid.Interfaces
{
	public interface IDependentService
	{
		Task<List<Models.DependentResponse>> GetAllDependentAsync(Models.DependentRequest request);
		Task<int> CheckSsnAsync(Models.AddDependentRequest request);
		Task<int> AddDependentAsync(Models.AddDependentRequest request);
		Task<int> AddDependentImagesAsync(Models.AddDependentImagesRequest request);
	}
}
