using Frontends.DTO.ORDER.Ordering;

namespace MShop.WebUI.Services.OrderServices.Ordering
{
	public interface IOrderingService
	{
		Task CreateOrdering(CreateOrderingDto createOrderingDto);
		Task <int> GetLastOrderingByUserId(string userId);
	}
}
