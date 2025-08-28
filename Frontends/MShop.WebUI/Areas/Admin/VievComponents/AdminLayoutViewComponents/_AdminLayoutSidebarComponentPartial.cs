using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Areas.Admin.VievComponents.AdminLayoutViewComponents
{
	public class _AdminLayoutSidebarComponentPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
