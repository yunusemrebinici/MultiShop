using Frontends.DTO.LOGİN;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Controllers
{
	public class RegisterController : Controller
	{

		private readonly IHttpClientFactory _httpClientFactory;

		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Index(CreateUserDto createUser)
		{
			if (createUser.Password == createUser.ConfirmPassword)
			{
				var client = _httpClientFactory.CreateClient();
				var json = JsonConvert.SerializeObject(createUser);
				StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("http://localhost:5001/api/Registers", stringContent);
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "Login");
				}
			}
			

			return View("Index");
		}
	}
}
