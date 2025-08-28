using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Areas.Admin.VievComponents.AdminLayoutViewComponents
{
	public class _AdminLayoutHeadComponentPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
