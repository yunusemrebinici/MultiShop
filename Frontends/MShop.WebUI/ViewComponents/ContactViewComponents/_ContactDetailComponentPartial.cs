using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ContactViewComponents
{
	public class _ContactDetailComponentPartial:ViewComponent
	{
        public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
