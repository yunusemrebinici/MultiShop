using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _TopbarUILayoutComponentPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
