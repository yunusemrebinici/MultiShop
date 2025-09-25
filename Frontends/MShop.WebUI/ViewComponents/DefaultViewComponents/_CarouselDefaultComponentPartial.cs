﻿using Frontends.DTO.CATALOG.FeatureSliderDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _CarouselDefaultComponentPartial:ViewComponent
	{
		private readonly IFeatureSliderService _featureSliderService;

		public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
		{
			_featureSliderService = featureSliderService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
		    var values = await _featureSliderService.GetAllFeatureSlidersAsync();
			return View(values);
		}
	}
}
