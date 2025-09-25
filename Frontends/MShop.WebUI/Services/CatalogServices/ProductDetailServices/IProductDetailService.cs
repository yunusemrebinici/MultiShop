using Frontends.DTO.CATALOG.ProductDetailDTOS;

namespace MShop.WebUI.Services.CatalogServices.ProductDetailServices
{
	public interface IProductDetailService
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
