using Frontends.DTO.CATALOG.FeatureProductDTOS;

namespace MShop.WebUI.Services.CatalogServices.FeatureProductServices
{
	public class FeatureProductService : IFeatureProductService
	{
		private readonly HttpClient _httpClient;

		public FeatureProductService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateFeatureProductAsync(CreateFeatureProductDto FeatureProductDto)
		{
			await _httpClient.PostAsJsonAsync<CreateFeatureProductDto>("FeatureProducts", FeatureProductDto);
		}

		public async Task DeleteFeatureProductAsync(string id)
		{
			await _httpClient.DeleteAsync($"FeatureProducts/{id}");
		}

		public async Task<ResultFeatureProductDto> GetByIdFeatureProductAsync(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<ResultFeatureProductDto>($"FeatureProducts/{id}");
			return values;
		}

		public async Task<List<ResultFeatureProductDto>> GettAllFeatureProductAsync()
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultFeatureProductDto>>("FeatureProducts");
			return values;
		}

		public async Task UpdateFeatureProductAsync(UpdateFeatureProductDto FeatureProductDto)
		{
			await _httpClient.PutAsJsonAsync<UpdateFeatureProductDto>("FeatureProducts", FeatureProductDto);
		}
	}
}
