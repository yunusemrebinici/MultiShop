using Frontends.DTO.CATALOG.FeatureDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _FeatureDefaultComponentPartial:ViewComponent
	{
		private readonly IFeatureService _featureService;

		public _FeatureDefaultComponentPartial(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
		    var values = await _featureService.GettAllFeatureAsync();
			return View(values);
		}
	}
}
