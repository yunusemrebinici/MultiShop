using Frontends.DTO.BASKET;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.BasketServices;

namespace MShop.WebUI.ViewComponents.ShoppingCardViewComponents
{
	public class _ShoppingCardListComponentPartial : ViewComponent
	{
		private readonly IBasketService _basketService;

		public _ShoppingCardListComponentPartial(IBasketService basketService)
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
