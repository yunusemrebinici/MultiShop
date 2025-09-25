using Frontends.DTO.CATALOG.FeatureProductDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.FeatureProductServices;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _FeatureProductsDefaultComponentPartial:ViewComponent
	{
		private readonly IFeatureProductService _featureProductService;

		public _FeatureProductsDefaultComponentPartial(IFeatureProductService featureProductService)
		{
			_featureProductService = featureProductService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _featureProductService.GettAllFeatureProductAsync();
			return View(values);
		}
	}
}
