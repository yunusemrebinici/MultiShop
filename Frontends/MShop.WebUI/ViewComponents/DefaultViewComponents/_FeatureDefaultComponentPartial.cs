using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _FeatureDefaultComponentPartial:ViewComponent
	{
		public async Task<IViewComponentResult>InvokeAsync()
		{
			return View();
		}
	}
}
