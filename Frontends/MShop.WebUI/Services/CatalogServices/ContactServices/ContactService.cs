using Frontends.DTO.CATALOG.ContactDTOS;

namespace MShop.WebUI.Services.CatalogServices.ContactServices
{
	public class ContactService : IContactService
	{
		private readonly HttpClient _httpClient;

		public ContactService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateContactAsync(CreateContactDto ContactDto)
		{
			await _httpClient.PostAsJsonAsync<CreateContactDto>("Contacts", ContactDto);
		}

		public async Task DeleteContactAsync(string id)
		{
			await _httpClient.DeleteAsync($"Contacts/{id}");
		}

		public async Task<ResultContactDto> GetContactAsync(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<ResultContactDto>("Contacts");
			return values;
		}

		public async Task<List<ResultContactDto>> GettAllContactAsync()
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultContactDto>>("Contacts");
			return values;
		}
	}
}
