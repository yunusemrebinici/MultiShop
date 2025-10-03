using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.OrderViewComponents
{
	public class _OrderTotalComponentPartial : ViewComponent
	{

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
