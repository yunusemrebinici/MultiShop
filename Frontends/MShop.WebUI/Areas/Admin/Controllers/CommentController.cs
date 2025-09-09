using Frontends.DTO.CATALOG.CommentDTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class CommentController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CommentController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7075/api/Comments");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(json);
				return View(values);
			}
			return View();
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateComment(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7075/api/Comments/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateCommentDto>(json);
				return View(values);
			}

			return View();
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
		{
			updateCommentDto.Date.ToString("dd-MMM-yyy");
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(updateCommentDto);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7075/api/Comments", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteComment(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7075/api/Comments/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> ActiveCommentStatus(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7075/api/Comments/ActiveComment/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> PassiveCommentStatus(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7075/api/Comments/PassiveComment/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
