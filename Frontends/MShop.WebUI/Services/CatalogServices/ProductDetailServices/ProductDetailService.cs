using Frontends.DTO.CATALOG.ProductDetailDTOS;

namespace MShop.WebUI.Services.CatalogServices.ProductDetailServices
{
	public class ProductDetailService : IProductDetailService
	{
		private readonly HttpClient _httpClient;

		public ProductDetailService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateProductDetailAsync(CreateProductDetailDto ProductDetailDto)
		{
			await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("ProductDetails", ProductDetailDto);
		}

		public async Task DeleteProductDetailAsync(string id)
		{
			await _httpClient.DeleteAsync($"ProductDetails/{id}");
		}

		public async Task<ResultProductDetailDto> GetByIdProductDetailAsync(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<ResultProductDetailDto>($"ProductDetails/{id}");
			return values;
		}

		public async Task<GetProductDetailDescriptionDto> GetProductDetailDescription(string id)
		{
			var values= await _httpClient.GetFromJsonAsync<GetProductDetailDescriptionDto>($"ProductDetails/GetProductDetailDescription/{id}");
			return values;
		}

		public async Task<GetProductDetailInformationDto> GetProductDetailInformation(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<GetProductDetailInformationDto>($"ProductDetails/GetProductDetailInformation/{id}");
			return values;
		}

		public async Task<GetProductDetailWithProductNameDto> GetProductDetailWithProductName(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<GetProductDetailWithProductNameDto>($"ProductDetails/GetProductDetailWithProductName/{id}");
			return values;
		}

		public async Task<List<ResultProductDetailDto>> GettAllProductDetailAsync()
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultProductDetailDto>>("ProductDetails");
			return values;
		}

		public async Task UpdateProductDetailAsync(UpdateProductDetailDto ProductDetailDto)
		{
			await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("ProductDetails", ProductDetailDto);
		}
	}
}
