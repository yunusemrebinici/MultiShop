using Frontends.DTO.ORDER.OrderDetail;
using Frontends.DTO.ORDER.Ordering;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.BasketServices;
using MShop.WebUI.Services.Interfaces;
using MShop.WebUI.Services.OrderServices.OrderDetail;
using MShop.WebUI.Services.OrderServices.Ordering;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MShop.WebUI.Controllers
{
	public class PaymentController : Controller
	{

		private readonly IUserService _userService;
		private readonly IBasketService _basketService;
		private readonly IOrderingService _orderingService;
		private readonly IOrderDetailService _orderDetailService;

		public PaymentController(IOrderingService orderingService, IUserService userService, IBasketService basketService, IOrderDetailService orderDetailService)
		{

			_orderingService = orderingService;
			_userService = userService;
			_basketService = basketService;
			_orderDetailService = orderDetailService;
		}

		public IActionResult Index()
		{
			
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateOrderingDto createOrderingDto)
		{
			var userId = await _userService.GetUserInfo();
			createOrderingDto.UserId = userId.Id;
			await _orderingService.CreateOrdering(createOrderingDto);	
			return RedirectToAction("Index","Order");
		}

		[HttpGet("ComplateOrders")]
		public async Task<IActionResult> ComplateOrders()
		{

			var values = await _basketService.GetBasket();
			var basketItem = values.BasketItems;
			return View(basketItem);
		}

		[HttpGet("ComplateOrderDetail")]
		public async Task<IActionResult> ComplateOrderDetail()
		{
			CreateOrderDetailDto createOrderDetailDto = new CreateOrderDetailDto();
			await _orderDetailService.CreateOrderDetail(createOrderDetailDto);
			//işlem gerçekleştikten sonra sepet komple silinmeli
			return RedirectToAction("Index", "Default");
		}

	}
}
