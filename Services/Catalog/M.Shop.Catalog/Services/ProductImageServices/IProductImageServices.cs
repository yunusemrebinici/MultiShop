using M.Shop.Catalog.Dtos.ProductImageDtos;

namespace M.Shop.Catalog.Services.ProductImageServices
{
	public interface IProductImageServices
	{
		Task<List<ResultProductImageDto>> GettAllProductImageAsync();
		Task CreateProductImageAsync(CreateProductImageDto ProductImageDto);
		Task UpdateProductImageAsync(UpdateProductImageDto ProductImageDto);
		Task DeleteProductImageAsync(string id);
		Task<ResultProductImageDto> GetByIdProductImageAsync(string id);
	}
}
