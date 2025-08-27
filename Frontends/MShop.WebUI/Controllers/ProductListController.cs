using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Controllers
{
	public class ProductListController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> ProductDetail()
		{
			return View();
		}
	}
}
