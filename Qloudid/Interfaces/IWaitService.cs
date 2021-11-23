using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface IWaitService
	{
		Task<int> AddGuestInfoAsync(Models.SubmitWaitListResturantDetail request);
	}
}
