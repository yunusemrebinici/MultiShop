using Basket.WebApi.Dtos;

namespace Basket.WebApi.Services
{
	public interface IBasketService
	{
		Task<BasketTotalDto> GetBasket(string id);

		Task SaveBasket(BasketTotalDto basketTotalDto);

		Task DeleteBasket(string userId);

	}
}
