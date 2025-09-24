using Frontends.DTO.CATALOG.FeatureSliderDTOS;

namespace MShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
	public interface IFeatureSliderService
	{
		Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync();
		Task<ResultFeatureSliderDto> GetFeatureSliderByIdAsync(string id);
		Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
		Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
		Task DeleteFeatureSliderAsync(string id);
	}
}
