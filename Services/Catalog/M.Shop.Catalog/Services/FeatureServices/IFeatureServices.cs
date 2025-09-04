using M.Shop.Catalog.Dtos.FeatureDtos;

namespace M.Shop.Catalog.Services.FeatureServices
{
	public interface IFeatureServices
	{
		Task<List<ResultFeatureDto>> GettAllFeatureAsync();
		Task CreateFeatureAsync(CreateFeatureDto FeatureDto);
		Task UpdateFeatureAsync(UpdateFeatureDto FeatureDto);
		Task DeleteFeatureAsync(string id);
		Task<ResultFeatureDto> GetByIdFeatureAsync(string id);
	}
}
