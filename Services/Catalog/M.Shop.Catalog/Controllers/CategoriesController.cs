using M.Shop.Catalog.Dtos.CategoryDtos;
using M.Shop.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M.Shop.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public async Task<IActionResult> CategoryList()
		{
			return Ok(await _categoryService.GettAllCategoryAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult>GetCategoryById(string id)
		{
			return Ok(await _categoryService.GetByIdCategoryAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult>CreateCategory(CreateCategoryDto categoryDto)
		{
			await _categoryService.CreateCategoryAsync(categoryDto);
			return Ok("Ekleme Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult>UpdateCategory(UpdateCategoryDto categoryDto)
		{
			await _categoryService.UpdateCategoryAsync(categoryDto);
			return Ok("Güncelleme Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult>DeleteCategory(string id)
		{
			await _categoryService.DeleteCategoryAsync(id);
			return Ok("Silme Başarılı");
		}

	}
}
