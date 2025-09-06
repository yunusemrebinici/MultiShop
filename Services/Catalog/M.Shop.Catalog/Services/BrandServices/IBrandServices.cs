using M.Shop.Catalog.Dtos.BrandDtos;

namespace M.Shop.Catalog.Services.BrandServices
{
	public interface IBrandServices
	{
		Task<List<ResultBrandDto>> GettAllBrandAsync();
		Task CreateBrandAsync(CreateBrandDto BrandProductDto);
		Task UpdateBrandAsync(UpdateBrandDto BrandProductDto);
		Task DeleteBrandAsync(string id);
		Task<ResultBrandDto> GetByIdBrandAsync(string id);
	}
}
