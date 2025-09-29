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
			var userId = UserClaimsPrincipal.Claims.FirstOrDefault().Value;
			var values = await _basketService.GetBasket(userId);
			List<BasketTotalDto> list = new List<BasketTotalDto>() {

		new BasketTotalDto()
		{
			UserId = values.UserId,
			BasketItems=values.BasketItems,
			DiscountRate=values.DiscountRate,
			DiscountCode=values.DiscountCode,
			
		}

			};

			return View(list);
		}
	}
}
