using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MShopIdentityServer.Dtos;
using MShopIdentityServer.Models;
using MShopIdentityServer.Tools;
using System.Threading.Tasks;

namespace MShopIdentityServer.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;

	

		public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginDto userLogin)
		{
			var result = await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, false);
			var user = await _userManager.FindByNameAsync(userLogin.UserName);
			if (result.Succeeded)
			{
				GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
				model.UserName = userLogin.UserName;
				model.Id = user.Id;
				var token = JwtTokenGenerator.GenerateToken(model);
				return Ok(token);

			}
			return Ok("Başarısız");
		}
	}
}
