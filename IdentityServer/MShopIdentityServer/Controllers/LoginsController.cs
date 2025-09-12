using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MShopIdentityServer.Dtos;
using MShopIdentityServer.Models;
using System.Threading.Tasks;

namespace MShopIdentityServer.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;

		public LoginsController(SignInManager<ApplicationUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginDto userLogin)
		{
		   var result=	await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, false);
			if (result.Succeeded)
			{
				return Ok("Başarılı");
			}
			return Ok("Başarısız");
		}
	}
}
