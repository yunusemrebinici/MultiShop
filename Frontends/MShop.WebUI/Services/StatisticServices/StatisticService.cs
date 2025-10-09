
namespace MShop.WebUI.Services.StatisticServices
{
	public class StatisticService : IStatisticService
	{
		private readonly HttpClient _httpClient;

		public StatisticService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<decimal> GetAvgProductPrice()
		{
			decimal value = await _httpClient.GetFromJsonAsync<decimal>("Statistics/GetAvgProductPrice"); ;
			return value;
		}

		public async Task<long> GetBrandCount()
		{
			long value = await _httpClient.GetFromJsonAsync<long>("Statistics/GetBrandCount"); ;
			return value;
		}

		public async Task<long> GetCategoryCount()
		{
			long value = await _httpClient.GetFromJsonAsync<long>("Statistics/GetCategoryCount"); ;
			return value;
		}

		public async Task<long> GetContactCount()
		{

			long value = await _httpClient.GetFromJsonAsync<long>("Statistics/GetContactCount"); ;
			return value;
		}

		public async Task<string> GetLastCreatedProductName()
		{
			string value = await _httpClient.GetStringAsync("Statistics/GetLastCreatedProductName"); ;
			return value;
		}
	}
}
