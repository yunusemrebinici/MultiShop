using Frontends.DTO.CATALOG.CommentDTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MShop.WebUI.Controllers
{
	public class ProductListController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductListController(IHttpClientFactory httpClientFactory)
		{
			
			_httpClientFactory = httpClientFactory;
		}

		public async Task <IActionResult> Index()
		{
			return View();
		}

		public async Task<IActionResult> ProductDetail(string id)
		{
			ViewBag.ProductId=id;
			

			return View();
		}

		[HttpGet]
		public async Task<PartialViewResult> AddComment(string id)
		{

			
			ViewBag.ProductId = id;

			return PartialView();
		}


		[HttpPost]
		public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
		{

			createCommentDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
			createCommentDto.Status = false;
			createCommentDto.ImageUrl = null;
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(createCommentDto);
			StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7075/api/Comments", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index","ProductList");
			}
			
			return View("Index","ProductList");
		}

		public async Task<IActionResult> ProductListWithCategoryId(string id) 
		{

			ViewBag.Id = id;
			return View();

		}

	}
}
