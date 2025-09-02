using M.Shop.Catalog.Dtos.FeatureSliderDtos;
using M.Shop.Catalog.Settings;

namespace M.Shop.Catalog.Services.FeatureSliderServices
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
