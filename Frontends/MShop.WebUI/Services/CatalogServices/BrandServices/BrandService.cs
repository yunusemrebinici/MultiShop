using Frontends.DTO.CATALOG.BrandDTOS;

namespace MShop.WebUI.Services.CatalogServices.BrandServices
{
	public class BrandService : IBrandService
	{
		private readonly HttpClient _httpClient;

		public BrandService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateBrandAsync(CreateBrandDto BrandProductDto)
		{
			await _httpClient.PostAsJsonAsync<CreateBrandDto>("Brands", BrandProductDto);
		}

		public async Task DeleteBrandAsync(string id)
		{
			await _httpClient.DeleteAsync($"Brands/{id}");
		}

		public async Task<ResultBrandDto> GetByIdBrandAsync(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<ResultBrandDto>($"Brands/{id}");
			return values;
		}

		public async Task<List<ResultBrandDto>> GettAllBrandAsync()
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultBrandDto>>("Brands");
			return values;
		}

		public async Task UpdateBrandAsync(UpdateBrandDto BrandProductDto)
		{
			await _httpClient.PutAsJsonAsync<UpdateBrandDto>("Brands",BrandProductDto);
		}
	}
}
