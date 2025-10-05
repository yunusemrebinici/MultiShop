using Frontends.DTO.ORDER.Adderess;
using MShop.WebUI.Services.OrderServices.Address;

namespace MShop.WebUI.Services.OrderServices.AddressService
{
	public class AddressService : IAddressService
	{
		private readonly HttpClient _httpClient;

		public AddressService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> GetAddressByUserId(string userId)
		{
			var response = await _httpClient.GetFromJsonAsync<List<ResultAddressDto>>("Addresses");
			var result= response.Where(x=>x.UserId==userId).Select(x=>x.AddressId).FirstOrDefault();
			return result;
		}

		public async Task CreateAddress(CreateAddressDto createAddressDto)
		{
			await _httpClient.PostAsJsonAsync<CreateAddressDto>("Addresses", createAddressDto);
		}
	}
}
