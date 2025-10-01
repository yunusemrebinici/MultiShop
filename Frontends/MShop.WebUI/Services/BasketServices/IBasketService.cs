using Frontends.DTO.BASKET;

namespace MShop.WebUI.Services.BasketServices
{
	public interface IBasketService
	{
		Task<BasketTotalDto> GetBasket();

		Task SaveBasket(BasketTotalDto basketTotalDto);

		Task DeleteBasket();

		Task AddBasketItem(BasketItemDto basketItemDto);

		Task<bool> RemoveBasketItem(string productId);
	}
}
