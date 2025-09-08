using M.Shop.Catalog.Dtos.ProductDetailDtos;

namespace M.Shop.Catalog.Services.ProductDetailServices
{
	public interface IProductDetailServices
	{
		Task<List<ResultProductDetailDto>> GettAllProductDetailAsync();
		Task CreateProductDetailAsync(CreateProductDetailDto ProductDetailDto);
		Task UpdateProductDetailAsync(UpdateProductDetailDto ProductDetailDto);
		Task DeleteProductDetailAsync(string id);
		Task<ResultProductDetailDto> GetByIdProductDetailAsync(string id);
		Task<GetProductDetailWithProductNameDto> GetProductDetailWithProductName(string id);
		Task<GetProductDetailDescriptionDto> GetProductDetailDescription(string id);
		Task<GetProductDetailInformationDto> GetProductDetailInformation(string id);
	}
}
