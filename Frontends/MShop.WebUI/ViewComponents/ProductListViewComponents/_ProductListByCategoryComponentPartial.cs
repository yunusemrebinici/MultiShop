using Frontends.DTO.CATALOG.ProductDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.ProductListViewComponents
{
	public class _ProductListByCategoryComponentPartial : ViewComponent
	{
		private readonly IProductService _productService;

		public _ProductListByCategoryComponentPartial(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
		{
			var values = await _productService.GetProductsByCategory(id);
			return View(values);
		}
		
	}
}
