using Frontends.DTO.ORDER.OrderDetail;
using Frontends.DTO.ORDER.Ordering;
using MShop.WebUI.Services.BasketServices;
using MShop.WebUI.Services.Interfaces;
using MShop.WebUI.Services.OrderServices.Address;
using MShop.WebUI.Services.OrderServices.Ordering;

namespace MShop.WebUI.Services.OrderServices.OrderDetail
{
	public class OrderDetailService : IOrderDetailService
	{
		private readonly HttpClient _httpClient;
		private readonly IBasketService _basketService;
		private readonly IOrderingService _orderingService;
		private readonly IUserService _userService;
		private readonly IAddressService _addressService;

		public OrderDetailService(HttpClient httpClient, IBasketService basketService, IOrderingService orderingService, IUserService userService, IAddressService addressService)
		{
			_httpClient = httpClient;
			_basketService = basketService;
			_orderingService = orderingService;
			_userService = userService;
			_addressService = addressService;
		}

		public async Task CreateOrderDetail(CreateOrderDetailDto createOrderDetail)
		{
			var response = _userService.GetUserInfo();
			var userId= response.Result.Id;
			int OrderingId =   await _orderingService.GetLastOrderingByUserId(userId);
			int GetAddressIdByUser= await _addressService.GetAddressByUserId(userId);
			var getBasket = await _basketService.GetBasket();
			foreach (var basket in getBasket.BasketItems)
			{

				createOrderDetail.ProductId = basket.ProductId;
				createOrderDetail.OrderingId = OrderingId;
				createOrderDetail.AddressId = GetAddressIdByUser;
				createOrderDetail.ProductPrice=basket.Price;
				createOrderDetail.ProductName=basket.ProductName;
				createOrderDetail.ProductAmount=basket.Quantity;
				createOrderDetail.ProductTotalPrice = basket.Price;
				
				await _httpClient.PostAsJsonAsync<CreateOrderDetailDto>("OrderDetails", createOrderDetail);

			}
		}
	}
}
