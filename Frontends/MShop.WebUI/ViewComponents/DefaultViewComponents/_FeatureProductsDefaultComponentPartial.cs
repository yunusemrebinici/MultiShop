using Frontends.DTO.CATALOG.FeatureProductDTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _FeatureProductsDefaultComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _FeatureProductsDefaultComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/FeatureProducts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureProductDto>>(json);
				return View(values);
			}
			return View();
		}
	}
}
