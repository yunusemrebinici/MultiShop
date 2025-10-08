using Frontends.DTO.CARGO;

namespace MShop.WebUI.Services.CargoServices.CargoCustomer
{
	public class CargoCustomerService : ICargoCustomerService
	{
		private readonly HttpClient _httpClient;

		public CargoCustomerService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateCargoDetail(CreateCargoCustomerDto createCargoCustomerDto)
		{
			await _httpClient.PostAsJsonAsync<CreateCargoCustomerDto>("CargoCustomers", createCargoCustomerDto);
		}

		public async Task<ResultCargCustomerDto> TGetUserCargoDetail(string userId)
		{
			return await _httpClient.GetFromJsonAsync<ResultCargCustomerDto>($"CargoCustomers/{userId}");
		}
	}
}
