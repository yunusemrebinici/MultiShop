using Frontends.DTO.CATALOG.CategoryDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _NavbarUILayoutComponentPartial:ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public _NavbarUILayoutComponentPartial(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _categoryService.GettAllCategoryAsync();
			return View(values);
		}
	}
}
