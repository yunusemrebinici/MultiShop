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

		public async Task DeleteBasket(string id)
		{
			await _httpClient.DeleteAsync($"Baskets/{id}");
		}

		public async Task<BasketTotalDto> GetBasket()
		{
			
			var values= await _httpClient.GetFromJsonAsync<BasketTotalDto>("Baskets");
			return values;
		}

		public async Task SaveBasket(BasketItemDto basketItemDto)
		{
			var values = await GetBasket();
			if (values != null)
			{
				if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
				{
					values.BasketItems.Add(basketItemDto);
				}
				else
				{
					values = new BasketTotalDto();
					values.BasketItems.Add(basketItemDto);
				}
			}
			
		}
	}
}
