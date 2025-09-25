﻿using Frontends.DTO.CATALOG.ProductDetailDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class _ProductDetailInformationComponentPartial : ViewComponent
	{
		private readonly IProductDetailService _productDetailService;

		public _ProductDetailInformationComponentPartial(IProductDetailService productDetailService)
		{
			_productDetailService = productDetailService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
		{
			var values = await _productDetailService.GetProductDetailInformation(id);

			return View(values);

		}
	}
}
