using Frontends.DTO.ORDER.Ordering;

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
	}
}
