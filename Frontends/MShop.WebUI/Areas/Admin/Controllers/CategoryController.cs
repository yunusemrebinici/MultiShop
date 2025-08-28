using Frontends.DTO.CATALOG.CategoryDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[controller]/[action]")]
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
	}
}
