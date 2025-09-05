using Frontends.DTO.CATALOG.OfferDiscountDTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _OfferDiscountDefaultComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _OfferDiscountDefaultComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/OfferDiscounts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(json);
				return View(values);
			}
			return View();
		}

	}
}
