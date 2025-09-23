using Frontends.DTO.CATALOG.ProductDTOS;

namespace MShop.WebUI.Services.CatalogServices.ProductServices
{
	public interface IProductService
	{

		Task<List<ResultProductDto>> GettAllProductAsync();
		Task CreateProductAsync(CreateProductDto ProductDto);
		Task UpdateProductAsync(UpdateProductDto ProductDto);
		Task DeleteProductAsync(string id);
		Task<ResultProductDto> GetByIdProductAsync(string id);
		Task<List<ResultProductWithCategoryNameDto>> GetAllProductWithCategoryNameAsync();
		Task<List<GetProductsByCategoryDto>> GetProductsByCategory(string id);
	}
}
