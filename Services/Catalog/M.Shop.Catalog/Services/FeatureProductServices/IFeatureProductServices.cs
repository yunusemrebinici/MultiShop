using M.Shop.Catalog.Dtos.FeatureProductDtos;

namespace M.Shop.Catalog.Services.FeatureProductServices
{
	public interface IFeatureProductServices
	{
		Task<List<ResultFeatureProductDto>> GettAllFeatureProductAsync();
		Task CreateFeatureProductAsync(CreateFeatureProductDto FeatureProductDto);
		Task UpdateFeatureProductAsync(UpdateFeatureProductDto FeatureProductDto);
		Task DeleteFeatureProductAsync(string id);
		Task<ResultFeatureProductDto> GetByIdFeatureProductAsync(string id);
	}
}
