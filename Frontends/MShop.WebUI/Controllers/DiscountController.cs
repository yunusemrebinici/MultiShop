using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.BasketServices;

namespace MShop.WebUI.Controllers
{
	public class DiscountController : Controller
	{
		private readonly IBasketService _basketService;

		public DiscountController(IBasketService basketService)
		{
			_basketService = basketService;
		}

		public async Task< IActionResult> Index()
		{
			var total = await _basketService.GetBasket();
			ViewBag.Total = total.BasketItems.Sum(x => x.Price);
			ViewBag.Kdv = ViewBag.Total * 0.10;
			return View();
		}

		[HttpGet]
		public async Task<PartialViewResult> _ConfirmCouponCode()
		{
			
			return PartialView();
		}

		[HttpPost]
		public async Task<IActionResult> _ConfirmCouponCode(string Couponid)
		{
			return RedirectToAction("Index","ShoppingCard");
		}


	}
}
