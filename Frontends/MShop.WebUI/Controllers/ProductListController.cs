using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Controllers
{
	public class ProductListController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
