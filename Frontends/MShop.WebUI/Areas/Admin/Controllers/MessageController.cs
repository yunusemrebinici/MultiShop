using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class MessageController : Controller
	{
		public IActionResult InBox()
		{
			return View();
		}
	}
}
