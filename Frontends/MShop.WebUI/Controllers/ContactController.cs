using Frontends.DTO.CATALOG.ContactDTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MShop.WebUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index()
		{
			return View();
		}


		[HttpGet]
		public async Task<PartialViewResult> CreateContact()
		{
			return PartialView();
		}

		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
		{
			createContactDto.MessageTime= DateTime.Now;
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(createContactDto);
			StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7070/api/Contacts", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View("Index","Contact");
		}
	}
}
