using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.StatisticServices;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class StatisticController : Controller
	{
		public async Task<IActionResult> Index()
		{
			

			return View();
		}
	}
}
