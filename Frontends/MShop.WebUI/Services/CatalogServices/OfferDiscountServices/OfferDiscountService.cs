using Frontends.DTO.CATALOG.OfferDiscountDTOS;

namespace MShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
	public class OfferDiscountService : IOfferDiscountService
	{
		private readonly HttpClient _httpClient;

		public OfferDiscountService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto OfferDiscountDto)
		{
			await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("OfferDiscounts", OfferDiscountDto);
		}

		public async Task DeleteOfferDiscountAsync(string id)
		{
			await _httpClient.DeleteAsync($"OfferDiscounts{id}");
		}

		public async Task<ResultOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<ResultOfferDiscountDto>($"OfferDiscounts/{id}");
			return values;
		}

		public async Task<List<ResultOfferDiscountDto>> GettAllOfferDiscountAsync()
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultOfferDiscountDto>>("OfferDiscounts");
			return values;
		}

		public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto OfferDiscountDto)
		{
			await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDto>("OfferDiscounts", OfferDiscountDto);
		}
	}
}
