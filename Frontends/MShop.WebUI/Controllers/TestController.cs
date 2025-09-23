using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MShop.WebUI.Controllers
{
	public class TestController : Controller
	{
		private readonly ICategoryService _categoryService;

		public TestController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task< IActionResult> Index()
		{
			var values = await _categoryService.GettAllCategoryAsync();
			return View(values);
		}
	}
}
