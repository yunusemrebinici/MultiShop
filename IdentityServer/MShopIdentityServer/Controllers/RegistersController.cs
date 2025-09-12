using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MShopIdentityServer.Dtos;
using MShopIdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MShopIdentityServer.Controllers
{
	//[Authorize(LocalApi.PolicyName)]
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class RegistersController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public RegistersController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}


		[HttpPost]
		public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
		{
			var values = new ApplicationUser()
			{
				UserName = userRegisterDto.UserName,
				Email = userRegisterDto.Email,
				Surname = userRegisterDto.Surname,
				Name = userRegisterDto.Name,

			};
			var result= await _userManager.CreateAsync(values,userRegisterDto.Password);
			if (result.Succeeded)
			{

				return Ok("Kullanıcı Başarı İle Eklendi");
			}
			else {

				return Ok("Hata Oluştu, tekrar deneyiniz");
			}

		}
	}
}
