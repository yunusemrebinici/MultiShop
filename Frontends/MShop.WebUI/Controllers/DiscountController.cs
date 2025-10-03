using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.BasketServices;
using MShop.WebUI.Services.DiscountServices;

namespace MShop.WebUI.Controllers
{
	public class DiscountController : Controller
	{
		private readonly IBasketService _basketService;
		private readonly IDiscountService _discountService;

		public DiscountController(IBasketService basketService, IDiscountService discountService)
		{
			_basketService = basketService;
			_discountService = discountService;
		}

		public async Task< IActionResult> Index()
		{
			
			return View();
		}

		[HttpGet]
		public async Task<PartialViewResult> _ConfirmCouponCode()
		{
			
			return PartialView();
		}

		[HttpPost]
		public async Task<IActionResult> _ConfirmCouponCode(string couponCode)
		{
			int rate = await _discountService.GetCouponRate(couponCode);

			return RedirectToAction("Index", "ShoppingCard", new {rate=rate});
		}


	}
}
