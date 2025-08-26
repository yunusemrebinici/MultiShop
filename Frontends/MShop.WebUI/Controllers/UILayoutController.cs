using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Controllers
{
	public class UILayoutController : Controller
	{
		public IActionResult _UILayout()
		{
			return View();
		}
	}
}
