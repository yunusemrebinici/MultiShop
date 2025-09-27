using Frontends.DTO.CATALOG.ContactDTOS;

namespace MShop.WebUI.Services.CatalogServices.ContactServices
{
	public interface IContactService
	{
		Task<List<ResultContactDto>> GettAllContactAsync();
		Task<ResultContactDto> GetContactAsync(string id);
		Task CreateContactAsync(CreateContactDto ContactProductDto);
		Task DeleteContactAsync(string id);
	}
}
