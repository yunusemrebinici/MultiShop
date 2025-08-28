using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ShoppingCardViewComponents
{
	public class _ShoppingCartDiscountCouponComponentPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
