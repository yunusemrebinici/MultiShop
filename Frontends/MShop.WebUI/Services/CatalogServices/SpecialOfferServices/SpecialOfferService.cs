using Frontends.DTO.CATALOG.SpecialOfferDTOS;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
	public class SpecialOfferService : ISpecialOfferService
	{
	
		private readonly HttpClient _httpClient;

		public SpecialOfferService(IHttpClientFactory httpClientFactory, HttpClient httpClient)
		{
			
			_httpClient = httpClient;
		}

		public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto SpecialOfferDto)
		{

			await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("SpecialOffers", SpecialOfferDto);

		}

		public async Task DeleteSpecialOfferAsync(string id)
		{
			await _httpClient.DeleteAsync($"SpecialOffers/"+id);
		}

		public async Task<ResultSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
		{
			var value = await _httpClient.GetFromJsonAsync<ResultSpecialOfferDto>($"SpecialOffers/{id}");

			return new ResultSpecialOfferDto()
			{
				SpecialOfferId = value.SpecialOfferId,
				ImageUrl = value.ImageUrl,
				SubTitle = value.SubTitle,
				Title = value.Title,
			};
		}

		public async Task<List<ResultSpecialOfferDto>> GettAllSpecialOfferAsync()
		{

			var responseMessage = await _httpClient.GetAsync("SpecialOffers");
			var result = await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();
			return result;
		}

		public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto SpecialOfferDto)
		{
		
			await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("SpecialOffers", SpecialOfferDto);
		}
	}
}
