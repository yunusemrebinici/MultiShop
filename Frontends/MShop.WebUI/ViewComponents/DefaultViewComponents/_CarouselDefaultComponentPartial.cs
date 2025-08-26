using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _CarouselDefaultComponentPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
