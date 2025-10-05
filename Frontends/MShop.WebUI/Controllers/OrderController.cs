using Frontends.DTO.ORDER.Adderess;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.Interfaces;
using MShop.WebUI.Services.OrderServices.Address;
using MShop.WebUI.Services.OrderServices.Ordering;

namespace MShop.WebUI.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderingService _orderingService;
		private readonly IUserService _userService;
		private readonly IAddressService _addressService;

		public OrderController(IOrderingService orderingService, IUserService userService, IAddressService addressService)
		{
			_orderingService = orderingService;
			_userService = userService;
			_addressService = addressService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateAddressDto createAddressDto)
		{
			var userId = _userService.GetUserInfo();
			createAddressDto.UserId=userId.Result.Id;
			await _addressService.CreateAddress(createAddressDto);
			return RedirectToAction("ComplateOrders","Payment");
		}
	}
}
