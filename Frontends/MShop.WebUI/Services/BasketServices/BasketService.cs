using Frontends.DTO.BASKET;
using Humanizer.Inflections;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
			if (values.BasketItems != null)
			{
				if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
				{
					values.BasketItems.Add(basketItemDto);
					await SaveBasket(values);
				}
				else
				{
					values.BasketItems.Add(basketItemDto);
					await SaveBasket(values);
				}

			}
			else
			{
				var Item = new BasketTotalDto()
				{
					BasketItems = new List<BasketItemDto>()
					{
						 new BasketItemDto()
						{
							Quantity = basketItemDto.Quantity,
							   ProductName = basketItemDto.ProductName,
							ProductImageUrl = basketItemDto.ProductImageUrl,
							   Price = basketItemDto.Price,
							ProductId= basketItemDto.ProductId,
						}
				   },
					DiscountCode = "null",
					DiscountRate = 1,
					UserId = "null",
				};
				await SaveBasket(Item);
			}
			
		}

		public async Task DeleteBasket()
		{
			await _httpClient.DeleteAsync("basket");
		}

		public async Task<BasketTotalDto> GetBasket()
		{

			var response = await _httpClient.GetAsync("http://localhost:7074/api/Baskets/GetBasketDetail");
			var values = await response.Content.ReadFromJsonAsync<BasketTotalDto>();
			return values;
		}

		public async Task<bool> RemoveBasketItem(string id)
		{
			var values = await GetBasket();
			var deleteItem = values.BasketItems.FirstOrDefault(x => x.ProductId == id);
			var result = values.BasketItems.Remove(deleteItem);
			await SaveBasket(values);
			return true;
		}

		public async Task SaveBasket(BasketTotalDto basketTotalDto)
		{
			await _httpClient.PostAsJsonAsync<BasketTotalDto>("Baskets", basketTotalDto);

		}
	}
}
