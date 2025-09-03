using M.Shop.Catalog.Dtos.SpecialOfferDtos;

namespace M.Shop.Catalog.Services.SpecialOfferServices
{
	public interface ISpecialOfferServices
	{
		Task<List<ResultSpecialOfferDto>> GettAllSpecialOfferAsync();
		Task CreateSpecialOfferAsync(CreateSpecialOfferDto SpecialOfferDto);
		Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto SpecialOfferDto);
		Task DeleteSpecialOfferAsync(string id);
		Task<ResultSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
	}
}
