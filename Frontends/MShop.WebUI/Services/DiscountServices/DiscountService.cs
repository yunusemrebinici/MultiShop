using Frontends.DTO.DİSCOUNT;

namespace MShop.WebUI.Services.DiscountServices
{
	public class DiscountService : IDiscountService
	{
		private readonly HttpClient _httpClient;

		public DiscountService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateCouponAsync(CreateCouponDto couponDto)
		{
			await _httpClient.PostAsJsonAsync<CreateCouponDto>("Discounts", couponDto);
		}

		public async Task DeleteCouponAsync(int id)
		{
			await _httpClient.DeleteAsync($"Discounts/{id}");
		}

		public async Task<int> GetCouponRate(string couponCode)
		{
			int rate = await _httpClient.GetFromJsonAsync<int>($"Discounts/GetCouponRate/{couponCode}");
			return rate;
		}

		public async Task<List<ResultCouponDto>> GettAllCouponAsync()
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultCouponDto>>("Discounts");
			return values;
		}

		public async Task<ResultCouponDto> GettCouponByIdAsync(int id)
		{
			var values = await _httpClient.GetFromJsonAsync<ResultCouponDto>($"Discounts/{id}");
			return values;
		}

		public async Task UpdateCouponAsync(UpdateCouponDto couponDto)
		{
			await _httpClient.PutAsJsonAsync<UpdateCouponDto>("Discounts", couponDto);
		}
	}
}
