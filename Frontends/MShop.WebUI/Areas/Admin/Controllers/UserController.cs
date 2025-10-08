using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.Interfaces;
using System.Threading.Tasks;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<IActionResult> Index()
		{
			var values= await _userService.GetAllUsers();
			return View(values);
		}
	}
}
