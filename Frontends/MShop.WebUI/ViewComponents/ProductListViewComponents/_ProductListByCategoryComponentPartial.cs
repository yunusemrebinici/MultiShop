using Frontends.DTO.CATALOG.ProductDTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.ProductListViewComponents
{
	public class _ProductListByCategoryComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _ProductListByCategoryComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/GetProductsByCategory/"+id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<GetProductsByCategoryDto>>(json);
				return View(values);
			}
			return View();
		}
		
	}
}
