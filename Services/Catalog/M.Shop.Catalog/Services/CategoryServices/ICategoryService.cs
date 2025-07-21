using M.Shop.Catalog.Dtos.CategoryDtos;

namespace M.Shop.Catalog.Services.CategoryServices
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDto>> GettAllCategoryAsync();
		Task CreateCategoryAsync(CreateCategoryDto categoryDto);
		Task UpdateCategoryAsync(UpdateCategoryDto categoryDto);
		Task DeleteCategoryAsync(string id);
		Task <ResultCategoryDto>GetByIdCategoryAsync(string id);
	}
}
