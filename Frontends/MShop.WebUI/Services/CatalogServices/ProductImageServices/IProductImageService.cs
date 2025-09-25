using Frontends.DTO.CATALOG.ProductImageDTOS;

namespace MShop.WebUI.Services.CatalogServices.ProductImageServices
{
	public interface IProductImageService
	{
		Task<List<ResultProductImageDto>> GettAllProductImageAsync();
		Task CreateProductImageAsync(CreateProductImageDto ProductImageDto);
		Task UpdateProductImageAsync(UpdateProductImageDto ProductImageDto);
		Task DeleteProductImageAsync(string id);
		Task<ResultProductImageDto> GetByIdProductImageAsync(string id);
	}
}
