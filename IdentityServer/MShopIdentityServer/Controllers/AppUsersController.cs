using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MShopIdentityServer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MShopIdentityServer.Controllers
{
	[Authorize(LocalApi.PolicyName)]
	[Route("api/[controller]")]
	[ApiController]
	public class AppUsersController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public AppUsersController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		
		[HttpGet("GetUser")]
		public async Task<IActionResult> GetUser()
		{
			var userClaim=User.Claims.FirstOrDefault(x=>x.Type==JwtRegisteredClaimNames.Sub);
			var user = await _userManager.FindByIdAsync(userClaim.Value);
			return Ok(new
			{
				Id = user.Id,
				Name = user.Name,
				Surname= user.Surname,
				Email = user.Email,
				UserName = user.UserName,
			});
		}

		[HttpGet("UserList")]
		public IActionResult UserList() // async olmasina gerek kalmadi, cünkü Users.ToList() direkt isler
		{
			// Tüm kullanıcılari çeker ve bir liste haline getirir.
			var allUsers = _userManager.Users.ToList();

			// Anonim tip veya DTO kullanarak sadece gerekli bilgileri seçer.
			var userListDto = allUsers.Select(user => new
			{
				Id = user.Id,
				Name = user.Name,
				Surname = user.Surname,
				Email = user.Email,
				UserName = user.UserName,
			}).ToList();

			// Kullanıcı listesini döndürür.
			return Ok(userListDto);
		}
	}
}
