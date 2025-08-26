using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _SpecialOfferComponentPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
