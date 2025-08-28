using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ShoppingCardViewComponents
{
	public class _ShoppingCardListComponentPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
