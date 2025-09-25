using Frontends.DTO.CATALOG.ProductDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace MShop.WebUI.ViewComponents.ProductListViewComponents
{
	public class _ProductListComponentPartial:ViewComponent
	{
		private readonly IProductService _productService;

		public _ProductListComponentPartial(IProductService productService)
		{
			_productService = productService;
		}

		public async Task <IViewComponentResult>InvokeAsync()
		{
			var values = await _productService.GetAllProductWithCategoryNameAsync();
			return View(values);
		}
	}
}
