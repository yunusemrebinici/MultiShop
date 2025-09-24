using Frontends.DTO.CATALOG.BrandDTOS;

namespace MShop.WebUI.Services.CatalogServices.BrandServices
{
	public interface IBrandService
	{
		Task<List<ResultBrandDto>> GettAllBrandAsync();
		Task CreateBrandAsync(CreateBrandDto BrandProductDto);
		Task UpdateBrandAsync(UpdateBrandDto BrandProductDto);
		Task DeleteBrandAsync(string id);
		Task<ResultBrandDto> GetByIdBrandAsync(string id);
	}
}
