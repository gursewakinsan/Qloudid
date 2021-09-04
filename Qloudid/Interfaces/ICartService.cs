using System.Threading.Tasks;

namespace Qloudid.Interfaces
{
	public interface ICartService
	{
		Task<int> PayCartItemUsingAppAsync(Models.PayCartItemRequest request);
	}
}
