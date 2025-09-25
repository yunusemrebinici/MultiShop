using Frontends.DTO.CATALOG.ProductImageDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MShop.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class _ProductDetailImageSliderComponentPartial:ViewComponent
	{
		private readonly IProductImageService _productImageService;

		public _ProductDetailImageSliderComponentPartial(IProductImageService productDetailService)
		{
			_productImageService = productDetailService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
		{
			var values= await _productImageService.GetByIdProductImageAsync(id);
			return View(values);
		}
	}
}
