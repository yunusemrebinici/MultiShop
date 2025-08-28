using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Controllers
{
	public class ShoppingCardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
