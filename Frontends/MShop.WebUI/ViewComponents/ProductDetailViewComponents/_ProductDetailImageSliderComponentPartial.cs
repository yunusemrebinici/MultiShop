using Frontends.DTO.CATALOG.ProductImageDTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class _ProductDetailImageSliderComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _ProductDetailImageSliderComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductImages/GetProductImageById/"+id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultProductImageDto>(json);
				

				return View(values);
			}
			return View();
		}
	}
}
