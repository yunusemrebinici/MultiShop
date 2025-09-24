using Frontends.DTO.CATALOG.OfferDiscountDTOS;

namespace MShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
	public interface IOfferDiscountService
	{
		Task<List<ResultOfferDiscountDto>> GettAllOfferDiscountAsync();
		Task CreateOfferDiscountAsync(CreateOfferDiscountDto OfferDiscountDto);
		Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto OfferDiscountDto);
		Task DeleteOfferDiscountAsync(string id);
		Task<ResultOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
	}
}
