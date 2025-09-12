using Frontends.DTO.LOGİN;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public LoginController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult>Index(UserLoginDto userLoginDto)
		{
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(userLoginDto);
			StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5001/api/Logins", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Default");
			}
			return View();
		}
	}
}
