using Frontends.DTO.CATALOG.FeatureDTOS;

namespace MShop.WebUI.Services.CatalogServices.FeatureServices
{
	public class FeatureService : IFeatureService
	{
		private readonly HttpClient _httpClient;

		public FeatureService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateFeatureAsync(CreateFeatureDto FeatureDto)
		{
			await _httpClient.PostAsJsonAsync<CreateFeatureDto>("Features", FeatureDto);
		}

		public async Task DeleteFeatureAsync(string id)
		{
			await _httpClient.DeleteAsync($"Features/{id}");
		}

		public async Task<ResultFeatureDto> GetByIdFeatureAsync(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<ResultFeatureDto>($"Features/{id}");
			return values;
		}

		public async Task<List<ResultFeatureDto>> GettAllFeatureAsync()
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultFeatureDto>>("Features");
			return values;
		}

		public async Task UpdateFeatureAsync(UpdateFeatureDto FeatureDto)
		{
			await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("Features",FeatureDto);
		}
	}
}
