using Frontends.DTO.BASKET;

namespace MShop.WebUI.Services.BasketServices
{
	public interface IBasketService
	{
		Task<BasketTotalDto> GetBasket();

		Task SaveBasket(BasketItemDto basketItemDto);

		Task DeleteBasket(string userId);
	}
}
