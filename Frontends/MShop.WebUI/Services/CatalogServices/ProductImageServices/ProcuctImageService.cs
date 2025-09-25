using Frontends.DTO.CATALOG.ProductImageDTOS;

namespace MShop.WebUI.Services.CatalogServices.ProductImageServices
{
	public class ProcuctImageService : IProductImageService
	{
		private readonly HttpClient _httpClient;

		public ProcuctImageService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateProductImageAsync(CreateProductImageDto ProductImageDto)
		{
			await _httpClient.PostAsJsonAsync<CreateProductImageDto>("ProductImages", ProductImageDto);
		}

		public async Task DeleteProductImageAsync(string id)
		{
			await _httpClient.DeleteAsync($"ProductImages/{id}");
		}

		public async Task<ResultProductImageDto> GetByIdProductImageAsync(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<ResultProductImageDto>($"ProductImages/GetProductImageById/{id}");
			return values;
		}

		public async Task<List<ResultProductImageDto>> GettAllProductImageAsync()
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultProductImageDto>>("ProductImages");
			return values;

		}

		public async Task UpdateProductImageAsync(UpdateProductImageDto ProductImageDto)
		{
			await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("ProductImages", ProductImageDto);
		}
	}
}
