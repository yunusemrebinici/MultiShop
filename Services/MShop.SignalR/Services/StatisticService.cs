
namespace MShop.SignalR.Services
{
	public class StatisticService : IStatisticService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public StatisticService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<decimal> GetAvgProductPrice()
		{
			var client= _httpClientFactory.CreateClient();
			var response = await client.GetFromJsonAsync<decimal>("http://localhost:7070/api/Statistics/GetAvgProductPrice");
			return response;
		}

		public async Task<long> GetBrandCount()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetFromJsonAsync<long>("http://localhost:7070/api/Statistics/GetBrandCount");
			return response;
		}

		public async Task<long> GetCategoryCount()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetFromJsonAsync<long>("http://localhost:7070/api/Statistics/GetCategoryCount");
			return response;
		}

		public async Task<long> GetContactCount()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetFromJsonAsync<long>("http://localhost:7070/api/Statistics/GetContactCount");
			return response;
		}

		public async Task<string> GetLastCreatedProductName()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetStringAsync("http://localhost:7070/api/Statistics/GetLastCreatedProductName");
			return response;
		}
	}
}
