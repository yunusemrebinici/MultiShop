using Frontends.DTO.CARGO;

namespace MShop.WebUI.Services.CargoServices.CargoCustomer
{
	public interface ICargoCustomerService
	{
		Task<ResultCargCustomerDto> TGetUserCargoDetail(string userId);

		Task CreateCargoDetail(CreateCargoCustomerDto createCargoCustomerDto);
	}
}
