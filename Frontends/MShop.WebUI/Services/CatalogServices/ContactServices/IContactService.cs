using Frontends.DTO.CATALOG.ContactDTOS;

namespace MShop.WebUI.Services.CatalogServices.ContactServices
{
	public interface IContactService
	{
		Task<List<ResultContactDto>> GettAllContactAsync();
		Task<ResultContactDto> GetContactAsync(string id);
		Task CreateContactAsync(CreateContactDto createContactDto);
		Task DeleteContactAsync(string id);
	}
}
