using Frontends.DTO.CATALOG.SpecialOfferDTOS;

namespace MShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
	public interface ISpecialOfferService
	{
		Task<List<ResultSpecialOfferDto>> GettAllSpecialOfferAsync();
		Task CreateSpecialOfferAsync(CreateSpecialOfferDto SpecialOfferDto);
		Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto SpecialOfferDto);
		Task DeleteSpecialOfferAsync(string id);
		Task<ResultSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
	}
}
