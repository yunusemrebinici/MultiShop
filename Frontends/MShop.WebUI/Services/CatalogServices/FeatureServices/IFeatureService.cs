using Frontends.DTO.CATALOG.FeatureDTOS;

namespace MShop.WebUI.Services.CatalogServices.FeatureServices
{
	public interface IFeatureService
	{
		Task<List<ResultFeatureDto>> GettAllFeatureAsync();
		Task CreateFeatureAsync(CreateFeatureDto FeatureDto);
		Task UpdateFeatureAsync(UpdateFeatureDto FeatureDto);
		Task DeleteFeatureAsync(string id);
		Task<ResultFeatureDto> GetByIdFeatureAsync(string id);
	}
}
