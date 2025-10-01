using Frontends.DTO.BASKET;

namespace MShop.WebUI.Services.BasketServices
{
	public class BasketService : IBasketService
	{
		private readonly HttpClient _httpClient;

		public BasketService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task AddBasketItem(BasketItemDto basketItemDto)
		{
			var values = await GetBasket();
			if (values != null)
			{
				if (values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
				{
					values.BasketItems.Add(basketItemDto);
				}
				else
				{
					var Item = new BasketTotalDto();
					Item.BasketItems.Add(basketItemDto);
					
				}
			}
			await SaveBasket(values);
		}

		public async Task DeleteBasket()
		{
			await _httpClient.DeleteAsync("Baskets");
		}

		public async Task<BasketTotalDto> GetBasket()
		{
			
			var response= await _httpClient.GetAsync("Baskets");
			var values = await response.Content.ReadFromJsonAsync<BasketTotalDto>();
			return values;
		}

		public async Task<bool> RemoveBasketItem(string productId)
		{
			var values = await GetBasket();
			var deleteItem=values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
			var result = values.BasketItems.Remove(deleteItem);
			await SaveBasket(values);
			return true;
		}

		public async Task SaveBasket(BasketTotalDto basketTotalDto)
		{
			await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
			
		}
	}
}
