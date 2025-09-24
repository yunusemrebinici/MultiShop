using Frontends.DTO.CATALOG.FeatureSliderDTOS;

namespace MShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
	public class FeatureSliderService : IFeatureSliderService

	{
		private readonly HttpClient _httpClient;

		public FeatureSliderService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
		{
			await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("FeatureSliders", createFeatureSliderDto);
		}

		public async Task DeleteFeatureSliderAsync(string id)
		{
			await _httpClient.DeleteAsync($"FeatureSliders/{id}");
		}

		public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync()
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultFeatureSliderDto>>("FeatureSliders");
			return values;
		}

		public async Task<ResultFeatureSliderDto> GetFeatureSliderByIdAsync(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<ResultFeatureSliderDto>($"FeatureSliders/{id}");
			return values;
		}

		public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("FeatureSliders", updateFeatureSliderDto);
		}
	}
}
