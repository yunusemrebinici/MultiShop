using Frontends.DTO.CATALOG.CategoryDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class CategoryController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
			if (responseMessage.IsSuccessStatusCode) 
			{
			      var json= await responseMessage.Content.ReadAsStringAsync();
				  var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(json);
			      return View(values);
			}
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> CreateCategory()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();
			var json=JsonConvert.SerializeObject(createCategoryDto);
			StringContent stringContent = new StringContent(json,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:7070/api/Categories", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateCategory(string id )
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories/"+id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(json);
				return View(values);
			}

			return View();
		}

		[HttpPost("{id}")]
		public async Task<IActionResult>UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			var client= _httpClientFactory.CreateClient();
			var json= JsonConvert.SerializeObject(updateCategoryDto);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7070/api/Categories", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult>DeleteCategory(string id)
		{
			var client= _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Categories/"+id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
