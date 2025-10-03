using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
