using Frontends.DTO.CATALOG.FeatureSliderDTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _CarouselDefaultComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarouselDefaultComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/FeatureSliders");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(json);
				return View(values);
			}
			return View();
		}
	}
}
