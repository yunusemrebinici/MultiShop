using Frontends.DTO.CATALOG.ProductDetailDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class _ProductDetailDescriptionComponentPartial:ViewComponent
	{
		private readonly IProductDetailService _productDetailService;

		public _ProductDetailDescriptionComponentPartial(IProductDetailService productDetailService)
		{
			_productDetailService = productDetailService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
		{
			var values = await _productDetailService.GetProductDetailDescription(id);
			return View(values);
		}
	}
}
