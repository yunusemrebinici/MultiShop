using Frontends.DTO.CATALOG.FeatureSliderDTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Areas.Admin.Controllers
{

	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class FeatureSliderController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FeatureSliderController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/FeatureSliders");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(json);
				return View(values);
			}
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> CreateFeatureSlider()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
		{
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(createFeatureSliderDto);
			StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7070/api/FeatureSliders", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateFeatureSlider(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/FeatureSliders/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(json);
				return View(values);
			}

			return View();
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(updateFeatureSliderDto);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7070/api/FeatureSliders", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteFeatureSlider(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7070/api/FeatureSliders/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}

