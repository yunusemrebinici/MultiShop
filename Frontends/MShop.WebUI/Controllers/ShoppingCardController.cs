using Frontends.DTO.BASKET;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.BasketServices;

namespace MShop.WebUI.Controllers
{
	public class ShoppingCardController : Controller
	{
		private readonly IBasketService _basketService;

		public ShoppingCardController(IBasketService basketService)
		{
			_basketService = basketService;
		}

		public IActionResult Index()
		{
			return View();
		}

		
		public async Task <IActionResult>RemoveBasket(string id)
		{
			await _basketService.DeleteBasket(id);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> AddBasket(BasketTotalDto basketTotalDto)
		{
			await _basketService.SaveBasket(basketTotalDto);
			return RedirectToAction("Index");
		}
	}
}
