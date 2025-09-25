using Frontends.DTO.CATALOG.FeatureProductDTOS;

namespace MShop.WebUI.Services.CatalogServices.FeatureProductServices
{
	public interface IFeatureProductService
	{
		Task<List<ResultFeatureProductDto>> GettAllFeatureProductAsync();
		Task CreateFeatureProductAsync(CreateFeatureProductDto FeatureProductDto);
		Task UpdateFeatureProductAsync(UpdateFeatureProductDto FeatureProductDto);
		Task DeleteFeatureProductAsync(string id);
		Task<ResultFeatureProductDto> GetByIdFeatureProductAsync(string id);
	}
}
