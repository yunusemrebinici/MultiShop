using Frontends.DTO.BASKET;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.BasketServices;
using MShop.WebUI.Services.CatalogServices.ProductServices;

namespace MShop.WebUI.Controllers
{
	public class ShoppingCardController : Controller
	{
		private readonly IBasketService _basketService;
		private readonly IProductService _productService;

		public ShoppingCardController(IBasketService basketService, IProductService productService)
		{
			_basketService = basketService;
			_productService = productService;
		}

		public IActionResult Index()
		{
			return View();
		}

		
		public async Task <IActionResult>RemoveBasket(string id)
		{
			await _basketService.DeleteBasket(id);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> AddBasket(string id)
		{
			var values = await _productService.GetByIdProductAsync(id);
			var items = new BasketItemDto
			{
				ProductId = values.ProductID,
				ProductName = values.ProductName,
				Price = values.ProductPrice,
				Quantity = 1,
				ProductImageUrl = values.ProductImageUrl
			};
			await _basketService.SaveBasket(items);
			return RedirectToAction("Index"); 
			
		}
	}
}
