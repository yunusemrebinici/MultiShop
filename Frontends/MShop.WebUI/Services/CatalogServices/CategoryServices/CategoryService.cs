using Frontends.DTO.CATALOG.CategoryDTOS;

namespace MShop.WebUI.Services.CatalogServices.CategoryServices
{
	public class CategoryService : ICategoryService
	{
		private readonly HttpClient _httpClient;

		public CategoryService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateCategoryAsync(CreateCategoryDto categoryDto)
		{
			await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories",categoryDto);
		}

		public async Task DeleteCategoryAsync(string id)
		{
			await _httpClient.DeleteAsync("categories"+id);
		}

		public async Task<ResultCategoryDto> GetByIdCategoryAsync(string id)
		{
			var values= await _httpClient.GetFromJsonAsync<ResultCategoryDto>("categories" + id);
			return values;
		}

		public async Task<List<ResultCategoryDto>> GettAllCategoryAsync()
		{
			var responseMessage = await _httpClient.GetAsync("categories");
			var result = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
			return result;

		}
		public async Task UpdateCategoryAsync(UpdateCategoryDto categoryDto)
		{
			await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", categoryDto);	
		}
	}
}
