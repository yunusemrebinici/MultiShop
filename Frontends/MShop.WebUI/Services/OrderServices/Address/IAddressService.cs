using Frontends.DTO.ORDER.Adderess;

namespace MShop.WebUI.Services.OrderServices.Address
{
	public interface IAddressService
	{
		Task CreateAddress(CreateAddressDto createAddressDto);
		Task<int> GetAddressByUserId(string userId);
	}
}
