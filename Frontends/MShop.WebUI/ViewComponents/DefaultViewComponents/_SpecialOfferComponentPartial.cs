using Frontends.DTO.CATALOG.SpecialOfferDTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _SpecialOfferComponentPartial:ViewComponent
	{

		private readonly IHttpClientFactory _httpClientFactory;

		public _SpecialOfferComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/SpecialOffers");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(json);
				return View(values);
			}
			return View();
		}
	}
}
