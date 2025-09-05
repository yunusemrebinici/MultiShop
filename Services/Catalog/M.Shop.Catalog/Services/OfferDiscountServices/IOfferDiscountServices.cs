using M.Shop.Catalog.Dtos.OfferDiscountDtos;

namespace M.Shop.Catalog.Services.OfferDiscountServices
{
	public interface IOfferDiscountServices
	{
		Task<List<ResultOfferDiscountDto>> GettAllOfferDiscountAsync();
		Task CreateOfferDiscountAsync(CreateOfferDiscountDto OfferDiscountDto);
		Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto OfferDiscountDto);
		Task DeleteOfferDiscountAsync(string id);
		Task<ResultOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
	}
}
