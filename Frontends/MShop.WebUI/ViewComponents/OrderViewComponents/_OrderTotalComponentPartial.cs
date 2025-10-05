using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.BasketServices;

namespace MShop.WebUI.ViewComponents.OrderViewComponents
{
	public class _OrderTotalComponentPartial : ViewComponent
	{
		private readonly IBasketService _basketService;

		public _OrderTotalComponentPartial(IBasketService basketService)
		{
			_basketService = basketService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			
			var values = await _basketService.GetBasket();
			var basketItem = values.BasketItems;
			return View(basketItem);
			
		}
	}
}
