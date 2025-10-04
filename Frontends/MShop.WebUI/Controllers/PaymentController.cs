using Frontends.DTO.ORDER.Ordering;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.Interfaces;
using MShop.WebUI.Services.OrderServices.Ordering;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MShop.WebUI.Controllers
{
	public class PaymentController : Controller
	{

		private readonly IUserService _userService;
		private readonly IOrderingService _orderingService;

		public PaymentController(IOrderingService orderingService, IUserService userService)
		{
			
			_orderingService = orderingService;
			_userService = userService;
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


	}
}
