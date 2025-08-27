using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class _ProductDetailImageSliderComponentPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
