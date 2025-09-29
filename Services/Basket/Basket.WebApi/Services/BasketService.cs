using Basket.WebApi.Dtos;
using Basket.WebApi.Settings;
using System.Text.Json;

namespace Basket.WebApi.Services
{
	public class BasketService : IBasketService
	{
		private readonly RedisService _redisService;

		public BasketService(RedisService redisService)
		{
			_redisService = redisService;
		}

		public async Task DeleteBasket(string id)
		{
			var status = await _redisService.GetDb().KeyDeleteAsync(id);
		}

		public async Task<BasketTotalDto> GetBasket(string id)
		{

			var existBasket = await _redisService.GetDb().StringGetAsync(id);
			if (existBasket.IsNull==true)
			{

				return null;

			}
			else
			{
				var values = JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
				
				return values;
			}


			
		}

		public async Task SaveBasket(BasketTotalDto basketTotalDto)
		{
			await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
		}
	}
}
