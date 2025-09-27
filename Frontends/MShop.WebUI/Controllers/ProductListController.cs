using Frontends.DTO.CATALOG.CommentDTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MShop.WebUI.Controllers
{
	public class ProductListController : Controller
	{
		private readonly ICommentService _commentService;

		public ProductListController(ICommentService commentService)
		{
			_commentService = commentService;
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
		    await _commentService.CreateCommentAsync(createCommentDto);
			
			return View("Index","ProductList");
		}

		public async Task<IActionResult> ProductListWithCategoryId(string id) 
		{

			ViewBag.Id = id;
			return View();

		}

	}
}
