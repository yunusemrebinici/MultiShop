using Frontends.DTO.CATALOG.FeatureProductDTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class FeatureProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FeatureProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/FeatureProducts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureProductDto>>(json);
				return View(values);
			}
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> CreateFeatureProduct()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeatureProduct(CreateFeatureProductDto createFeatureProductDto)
		{
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(createFeatureProductDto);
			StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7070/api/FeatureProducts", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateFeatureProduct(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/FeatureProducts/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFeatureProductDto>(json);
				return View(values);
			}

			return View();
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateFeatureProduct(UpdateFeatureProductDto updateFeatureProductDto)
		{
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(updateFeatureProductDto);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7070/api/FeatureProducts", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteFeatureProduct(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7070/api/FeatureProducts/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
