using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Models;
using MShop.WebUI.Services.Interfaces;

namespace MShop.WebUI.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<IActionResult> Index()
		{
			var values= await _userService.GetUserInfo();
			UserDetailViewModel model = new UserDetailViewModel()
			{
				Name = values.Name,
				Email = values.Email,
				Id = values.Id,
				Surname = values.Surname,
				UserName = values.UserName,
			};

			return View(model);
		}
	}
}
