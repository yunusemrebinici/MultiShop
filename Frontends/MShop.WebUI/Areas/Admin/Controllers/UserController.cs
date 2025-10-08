using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CargoServices.CargoCustomer;
using MShop.WebUI.Services.Interfaces;
using System.Threading.Tasks;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		private readonly ICargoCustomerService _cargoCustomerService;

		public UserController(IUserService userService, ICargoCustomerService cargoCustomerService)
		{
			_userService = userService;
			_cargoCustomerService = cargoCustomerService;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _userService.GetAllUsers();
			return View(values);
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetUserAddress(string userId)
		{
			var values= await _cargoCustomerService.TGetUserCargoDetail(userId);
			return View(values);
		}
	}
}
