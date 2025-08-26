using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _NavbarUILayoutComponentPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
