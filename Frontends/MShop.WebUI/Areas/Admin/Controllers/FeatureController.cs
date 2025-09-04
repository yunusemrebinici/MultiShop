using Frontends.DTO.CATALOG.FeatureDTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class FeatureController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FeatureController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/Features");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(json);
				return View(values);
			}
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> CreateFeature()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(createFeatureDto);
			StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7070/api/Features", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateFeature(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/Features/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(json);
				return View(values);
			}

			return View();
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(updateFeatureDto);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7070/api/Features", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteFeature(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Features/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
