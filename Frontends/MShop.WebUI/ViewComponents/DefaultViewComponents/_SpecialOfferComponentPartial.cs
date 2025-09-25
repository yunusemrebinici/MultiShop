using Frontends.DTO.CATALOG.SpecialOfferDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _SpecialOfferComponentPartial:ViewComponent
	{

		private readonly ISpecialOfferService _specialOfferService;

		public _SpecialOfferComponentPartial(ISpecialOfferService specialOfferService)
		{
			_specialOfferService = specialOfferService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _specialOfferService.GettAllSpecialOfferAsync();
			return View(values);
		}
	}
}
