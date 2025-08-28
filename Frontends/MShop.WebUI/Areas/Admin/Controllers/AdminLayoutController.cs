using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Areas.Admin.Controllers

{
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class AdminLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
