﻿using Microsoft.AspNetCore.Authorization;
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
	}
}
