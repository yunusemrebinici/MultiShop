using M.Shop.Catalog.Dtos.ProductDtos;

namespace M.Shop.Catalog.Services.ProductServices
{
	public interface IProductServices
	{
		Task<List<ResultProductDto>> GettAllProductAsync();
		Task CreateProductAsync(CreateProductDto ProductDto);
		Task UpdateProductAsync(UpdateProductDto ProductDto);
		Task DeleteProductAsync(string id);
		Task<ResultProductDto> GetByIdProductAsync(string id);
		Task<List<ResultProductWithCategoryNameDto>> GetAllProductWithCategoryNameAsync();
	}
}
