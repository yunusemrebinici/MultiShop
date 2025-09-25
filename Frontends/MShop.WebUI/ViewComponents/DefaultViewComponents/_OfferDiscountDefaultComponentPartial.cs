using Frontends.DTO.CATALOG.OfferDiscountDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _OfferDiscountDefaultComponentPartial:ViewComponent
	{
		private readonly IOfferDiscountService _offerDiscountService;

		public _OfferDiscountDefaultComponentPartial(IOfferDiscountService offerDiscountService)
		{
			_offerDiscountService = offerDiscountService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _offerDiscountService.GettAllOfferDiscountAsync();
			return View(values);
		}

	}
}
