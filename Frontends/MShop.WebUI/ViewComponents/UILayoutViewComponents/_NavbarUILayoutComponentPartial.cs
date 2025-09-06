using Frontends.DTO.CATALOG.CategoryDTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _NavbarUILayoutComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _NavbarUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(json);
				return View(values);
			}
			return View();
		}
	}
}
