using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface IQueueService
	{
		Task<int> AddPersonToDesiredQueueAsync(Models.AddPersonToDesiredQueueRequest request);
	}
}
