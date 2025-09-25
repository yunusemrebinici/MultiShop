using Frontends.DTO.CATALOG.BrandDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _VendorDefaultComponentPartial : ViewComponent
	{

		private readonly IBrandService _brandService;

		public _VendorDefaultComponentPartial(IBrandService brandService)
		{
			_brandService = brandService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _brandService.GettAllBrandAsync();
			return View(values);
		}
	}
}
