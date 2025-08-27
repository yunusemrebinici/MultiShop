using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ProductListViewComponents
{
	public class _ProductListComponentPartial:ViewComponent
	{
		public async Task <IViewComponentResult>InvokeAsync()
		{
			return View();
		}
	}
}
