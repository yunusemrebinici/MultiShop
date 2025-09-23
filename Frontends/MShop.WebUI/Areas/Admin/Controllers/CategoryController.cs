using Frontends.DTO.CATALOG.CategoryDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class CategoryController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ICategoryService _categoryService;

		public CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
		{
			_httpClientFactory = httpClientFactory;
			_categoryService = categoryService;
		}

		public async Task<IActionResult> Index()
		{
			var values= await _categoryService.GettAllCategoryAsync();
			return View(values);
		}


		[HttpGet]
		public async Task<IActionResult> CreateCategory()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			await _categoryService.CreateCategoryAsync(createCategoryDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateCategory(string id )
		{
			var values = await _categoryService.GetByIdCategoryAsync(id);
			UpdateCategoryDto update = new UpdateCategoryDto()
			{
				CategoryID = values.CategoryID,
				CategoryName = values.CategoryName,
				ImageUrl = values.ImageUrl
			};
			return View(update);
		}

		[HttpPost("{id}")]
		public async Task<IActionResult>UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			await _categoryService.UpdateCategoryAsync(updateCategoryDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult>DeleteCategory(string id)
		{
			await _categoryService.DeleteCategoryAsync(id);
			return  RedirectToAction("Index");
		}
	}
}
