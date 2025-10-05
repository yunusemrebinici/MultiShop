using Frontends.DTO.ORDER.Ordering;
using MShop.WebUI.Services.BasketServices;

namespace MShop.WebUI.Services.OrderServices.Ordering
{
	public class OrderingService : IOrderingService
	{
		private readonly HttpClient _httpClient;
		

		public OrderingService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			
		}

		public async Task CreateOrdering(CreateOrderingDto createOrderingDto)
		{
			
			await _httpClient.PostAsJsonAsync<CreateOrderingDto>("Orderings", createOrderingDto);

		}

		public async Task<int> GetLastOrderingByUserId(string userId)
		{
			var response = await _httpClient.GetFromJsonAsync<List<ResultOrderingDto>>("Orderings");
			int LastOrdering = response.Where(x => x.UserId == userId).Select(o => o.OrderingId).FirstOrDefault();
			return LastOrdering;
		}
	}
}
