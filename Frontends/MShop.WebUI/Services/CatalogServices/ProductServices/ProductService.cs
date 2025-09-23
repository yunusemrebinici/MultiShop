using Frontends.DTO.CATALOG.ProductDTOS;

namespace MShop.WebUI.Services.CatalogServices.ProductServices
{
	public class ProductService : IProductService
	{
		private readonly HttpClient _httpClient;

		public ProductService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateProductAsync(CreateProductDto ProductDto)
		{
			await _httpClient.PostAsJsonAsync<CreateProductDto>("Products", ProductDto);
		}

		public async Task DeleteProductAsync(string id)
		{
			await _httpClient.DeleteAsync($"Products/{id}");
		}

		public async Task<List<ResultProductWithCategoryNameDto>> GetAllProductWithCategoryNameAsync()
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryNameDto>>("Products/GetProductsWithCategoryName");
			return values;
		}

		public async Task<ResultProductDto> GetByIdProductAsync(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<ResultProductDto>($"Products/{id}");

			return values;
		}

		public async Task<List<GetProductsByCategoryDto>> GetProductsByCategory(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<List<GetProductsByCategoryDto>>($"Products{id}");
			return values;
		}

		public async Task<List<ResultProductDto>> GettAllProductAsync()
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultProductDto>>("Products");
			return values;
		}

		public async Task UpdateProductAsync(UpdateProductDto ProductDto)
		{
			await _httpClient.PutAsJsonAsync<UpdateProductDto>("Products", ProductDto);
		}
	}
}
