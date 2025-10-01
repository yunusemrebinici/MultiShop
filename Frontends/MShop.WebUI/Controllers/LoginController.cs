using Frontends.DTO.LOGİN;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Models;
using MShop.WebUI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;


namespace MShop.WebUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IIdentityService _identityService;

		public LoginController(IHttpClientFactory httpClientFactory, IIdentityService identityService)
		{
			_httpClientFactory = httpClientFactory;
			_identityService = identityService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}

		//[HttpPost]
		//public async Task<IActionResult> Index(UserLoginDto userLoginDto)
		//{
		//	var client = _httpClientFactory.CreateClient();
		//	var content = new StringContent(JsonSerializer.Serialize(userLoginDto), Encoding.UTF8, "application/json");
		//	var response = await client.PostAsync("http://localhost:5001/api/Logins", content);
		//	if (response.IsSuccessStatusCode)
		//	{
		//		var jsonData = await response.Content.ReadAsStringAsync();
		//		JwtResponseModel tokenModel = null;

		//		try
		//		{
		//			 tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
		//			{
		//				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
						
		//			});
					
		//		}
		//		catch (Exception)
		//		{

		//			return View();
		//		}
				

		//		if (tokenModel !=null)
		//		{
		//			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
		//			var token = handler.ReadJwtToken(tokenModel.Token);
		//			var claims = token.Claims.ToList();
		//			if (claims != null)
		//			{
		//				claims.Add(new Claim("multishoptoken",tokenModel.Token));
		//				var claimsIdentity=new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
		//				var authProps = new AuthenticationProperties
		//				{
		//					ExpiresUtc = tokenModel.ExpireDate,
		//					IsPersistent = true,
		//				};
		//				await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
		//				return RedirectToAction("Index", "Default");
		//			}
		//		}
		//	}
		//	return View();
		//}

		[HttpGet]
		public async Task<IActionResult> SignIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult>SignIn(SignUpDto signUp)
		{
	        var response=  await _identityService.SignIn(signUp);
			if (response==true)
			{
				return RedirectToAction("Index", "Default");
			}
			else
			{
				return View();
			}
		}
	}
}
