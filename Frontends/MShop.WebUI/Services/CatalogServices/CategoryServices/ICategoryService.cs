using Frontends.DTO.CATALOG.CategoryDTOS;

namespace MShop.WebUI.Services.CatalogServices.CategoryServices
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDto>> GettAllCategoryAsync();
		Task CreateCategoryAsync(CreateCategoryDto categoryDto);
		Task UpdateCategoryAsync(UpdateCategoryDto categoryDto);
		Task DeleteCategoryAsync(string id);
		Task<ResultCategoryDto> GetByIdCategoryAsync(string id);
	}
}
