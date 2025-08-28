using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
